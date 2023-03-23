using ProjectPRN221.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectPRN221.ViewModel
{
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Models.Object> _List;
        public ObservableCollection<Models.Object> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        
        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        
        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private Models.Object _SelectedItem;
        public Models.Object SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.Qrcode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.IdUnitNavigation;
                    SelectedSuplier = SelectedItem.IdSuplierNavigation;
                }
            }
        }
        private Unit _SelectedUnit;
        public Unit SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }
        private Suplier _SelectedSuplier;
        public Suplier SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }

        private int _IdUnit;
        public int IdUnit { get => _IdUnit; set { _IdUnit = value; OnPropertyChanged(); } }

        private int _IdSuplier;
        public int IdSuplier { get => _IdSuplier; set { _IdSuplier = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ObjectViewModel()
        {
            List = new ObservableCollection<Models.Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            Suplier = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null || SelectedUnit == null)
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                var Object = new Models.Object() {Id = Guid.NewGuid().ToString(), DisplayName = DisplayName, BarCode = BarCode, Qrcode = QRCode, IdSuplier = SelectedSuplier.Id, IdUnit = SelectedUnit.Id};

                DataProvider.Ins.DB.Objects.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });

            UpdateCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSuplier == null || SelectedUnit == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Object.DisplayName = DisplayName;
                Object.BarCode = BarCode;
                Object.Qrcode = QRCode;
                Object.IdSuplier = SelectedSuplier.Id;
                Object.IdUnit = SelectedUnit.Id;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.DisplayName = DisplayName;
                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i].Id == SelectedItem.Id)
                    {
                        List[i] = new Models.Object() { Id = SelectedItem.Id, DisplayName = SelectedItem.DisplayName, BarCode = SelectedItem.BarCode, Qrcode = SelectedItem.Qrcode, IdSuplier = SelectedItem.IdSuplier, IdUnit = SelectedItem.IdUnit};
                        break;
                    }
                }
            });
        }
    }
}
