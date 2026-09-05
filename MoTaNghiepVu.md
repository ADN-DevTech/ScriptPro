# Mô tả nghiệp vụ – ScriptProPlus

## Tổng quan

**ScriptProPlus** là công cụ chạy hàng loạt (batch) file script AutoCAD (`.scr`) trên nhiều bản vẽ `.dwg/.dxf` — dùng để tự động hoá việc **xuất PDF hàng loạt**, in ấn, hoặc chạy bất kỳ lệnh AutoCAD nào trên cả loạt file mà không cần mở tay từng bản vẽ.

Kiến trúc gồm 3 project chính:

- **ScriptUI** (WPF, .NET 8) — cửa sổ chính, ribbon menu (New/Load/Save list, Add DWG, Run…).
- **DrawingListUC** (WinForms UserControl) — **chứa toàn bộ nghiệp vụ lõi**, được nhúng vào ScriptUI.
- **ScriptProSetup** — trình cài đặt (WiX/MSI).

## Luồng nghiệp vụ chính

### 1. Tạo/nạp danh sách bản vẽ (Drawing List)

- Người dùng thêm file `.dwg/.dxf` thủ công (`AddDWGFiles`) hoặc quét cả thư mục (`AddDWGFilesFromFolder`, có tuỳ chọn quét đệ quy `searchAllDirectories`).
- Danh sách được lưu/nạp dưới dạng file dự án `.bpl` (định dạng text riêng, có versioning — hiện tại version 3) hoặc nạp từ file `.scp` cũ của ScriptPro gốc.
- Mỗi dòng trong `.bpl` lưu: đường dẫn file DWG + trạng thái checked/skip.

### 2. Cấu hình xử lý (`setOptions` → `OptionsDlg`)

- Đường dẫn **script** `.scr` sẽ chạy trên mỗi bản vẽ.
- Script khởi động (`startUpScript`) chạy 1 lần khi AutoCAD mở lên.
- **Timeout** cho mỗi bản vẽ, **số bản vẽ xử lý trước khi restart AutoCAD** (`_restartDWGCount`) — để tránh rò rỉ bộ nhớ khi chạy hàng trăm file.
- Có thể chỉ định **exe AutoCAD cụ thể** (nhiều version cài song song) hoặc dùng `accoreconsole.exe` (chế độ headless/command-line, không cần giao diện).
- Chế độ chạy trên **bản vẽ trống** (`runWithoutOpen`) — không mở file, chỉ chạy script.
- Diagnostic mode (dừng lại xác nhận sau mỗi bước) để debug script.

### 3. Chạy batch (`runCheckedFiles` / `runSelectedFiles` / `runFailedFiles`)

- Xây danh sách file cần chạy (`ThreadInput._FileInfolist`), khởi động 1 **BackgroundWorker** riêng để không đơ UI.
- **Kết nối AutoCAD qua COM (`startAutoCAD`)**, có 2 kịch bản:
  - Nếu chọn exe cụ thể: kiểm tra đã có tiến trình AutoCAD đó chạy chưa → gắn vào (attach) nếu có, không thì khởi chạy mới và bind qua ProgID theo version (vd `AutoCAD.Application.25.1`).
  - Nếu không chọn: cố gắng gắn vào bất kỳ AutoCAD đang mở, nếu không có thì tạo instance mới (bản mới nhất đã đăng ký COM).
- Cờ `_weOwnTheAcadInstance` đánh dấu ScriptPro có "sở hữu" AutoCAD hay không → chỉ AutoCAD do chính nó khởi chạy mới bị **đóng/kill tự động**; nếu người dùng đã mở sẵn AutoCAD thì ScriptPro chỉ dùng nhờ, không tắt.

### 4. Vòng lặp xử lý từng bản vẽ (`batchProcessThread_DoWork`)

- Với mỗi file: mở bản vẽ (`Documents.Open`) → chờ AutoCAD "quiescent" (rảnh) → gửi lệnh `_.SCRIPT <đường dẫn script>` qua `SendCommand` → đóng bản vẽ không lưu (script tự lo việc save/plot).
- **Từ khoá thay thế trong script** (`<acet:cFolderName>`, `<acet:cBaseName>`, `<acet:cExtension>`, `<acet:cFileName>`, `<acet:cFullFileName>`) — cho phép script tham chiếu tên/đường dẫn file hiện tại (rất hữu ích để đặt tên PDF xuất ra theo tên bản vẽ).
- Hỗ trợ **script lồng nhau** (nested script dùng `call`).
- Có cơ chế **timeout riêng** (`_timeout`, BackgroundWorker phụ) — nếu bản vẽ xử lý quá lâu (AutoCAD treo/crash), tự động coi là fail và tiếp tục file kế.
- Sau mỗi N bản vẽ (`_restartDWGCount`), **AutoCAD tự khởi động lại** để giải phóng tài nguyên.
- Kết quả từng file (thành công/thất bại) cập nhật lên UI (đổi màu dòng, ghi trạng thái) và ghi vào **log file** (`ReportLog`).

### 5. Kết thúc / dừng

- Có thể `stopProcess()` để dừng giữa chừng (cờ `_stopBatchProcess`).
- Khi xong, có thể **chỉ chạy lại các file thất bại** (`runFailedFiles`).
- `writeDWGList` lưu lại kết quả (bao gồm cả option "chỉ lưu danh sách file failed").

## Ví dụ script nghiệp vụ (xuất PDF) — `TestFiles/PlotToPDF.scr`

```lisp
(setq fileName (substr (getvar 'dwgname) 1 (- (strlen (getvar 'dwgname)) 4)))
(setq fileName (strcat (getvar "dwgprefix") filename ".pdf"))
filedia
0
(command "-PLOT" "YES" "MODEL" "Dwg To PDF.pc3" "ANSI expand B (11.00 x 17.00 Inches)"
         "Inches" "Landscape" "NO" "Extents" "Fit" "Center" "Yes" "." "Yes" "" filename "NO" "YES")
filedia
1
```

Lấy tên bản vẽ hiện tại, đổi đuôi thành `.pdf`, tắt hộp thoại file (`filedia 0`), gọi lệnh `-PLOT` với driver ảo **"Dwg To PDF.pc3"** để xuất PDF cùng thư mục, cùng tên với DWG, rồi bật lại `filedia`. Đây chính là script mà ScriptPro chạy lặp lại trên toàn bộ danh sách DWG để xuất PDF hàng loạt.

## Chế độ chạy dòng lệnh (silent/headless)

File `.bpl` có thể truyền làm tham số dòng lệnh (`ScriptUI.exe project.bpl run exit`) để tự động nạp danh sách, chạy ngay và thoát không cần thao tác tay — phù hợp để **lên lịch chạy tự động** (Task Scheduler) xuất PDF định kỳ.
