using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DwgExportManager.Models
{
    // Mot dong trong luoi: 1 file DWG/DXF + tab (Model/Layout) duoc chon de xuat
    public class DwgFileItem : INotifyPropertyChanged
    {
        public string FileName { get; set; }

        public string FullPath { get; set; }

        // Danh sach "Model" + cac Layout doc duoc tu file, de do vao ComboBox
        public ObservableCollection<string> AvailableTabs { get; } = new ObservableCollection<string>();

        private string _selectedTab = "Model";
        public string SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;
                    OnPropertyChanged(nameof(SelectedTab));
                }
            }
        }

        // Kho anh (paper size) rieng cho xuat PNG cua dong nay, vd "1600 x 1280 Pixels"
        // - phai trung ten mot media size da dang ky trong "PublishToWeb PNG.pc3" tren may.
        private string _pngPaperSize = "1600 x 1280 Pixels";
        public string PngPaperSize
        {
            get => _pngPaperSize;
            set
            {
                if (_pngPaperSize != value)
                {
                    _pngPaperSize = value;
                    OnPropertyChanged(nameof(PngPaperSize));
                }
            }
        }

        private string _status = "";
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
