using ProjectPRN221.Models;
using ProjectPRN221.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectPRN221.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand LoadedWindowCommand{ get; set; }

        public MainViewModel()
        {
            #region Show window Command
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UnitWindow wd = new UnitWindow();
                wd.ShowDialog();
            });
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SuplierWindow wd = new SuplierWindow();
                wd.ShowDialog();
            });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerWindow wd = new CustomerWindow();
                wd.ShowDialog();
            });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ObjectWindow wd = new ObjectWindow();
                wd.ShowDialog();
            });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UserWindow wd = new UserWindow();
                wd.ShowDialog();
            });;
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputWindow wd = new InputWindow();
                wd.ShowDialog();
            });;
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OutputWindow wd = new OutputWindow();
                wd.ShowDialog();
            });
            #endregion

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                {
                    return;
                }
                Isloaded = true;
                LoginWindow loginWindow = new LoginWindow();

                if (loginWindow.DataContext == null)
                {
                    return;
                }
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLoggedIn)
                {
                    p.Show();
                    LoadTonKho();
                }
                else
                {
                    p.Close();
                }
            });

            void LoadTonKho()
            {
                TonKhoList = new ObservableCollection<TonKho>();

                var objectList = DataProvider.Ins.DB.Objects.ToList();
                int i = 1;
                foreach (var item in objectList)
                {
                    var inputList = DataProvider.Ins.DB.InputInfos.Where(p => p.IdObject == item.Id).ToList();
                    var outputList = DataProvider.Ins.DB.OutputInfos.Where(p => p.IdObject == item.Id).ToList();

                    int sumInput = 0;
                    int sumOutput = 0;

                    if (inputList != null && inputList.Count() > 0)
                    {
                        sumInput = (int)inputList.Sum(p => p.Count);
                    }
                    if (outputList != null && outputList.Count() > 0)
                    {
                        sumOutput = (int)outputList.Sum(p => p.Count);
                    }

                    TonKho tonKho= new TonKho();
                    tonKho.STT = i;
                    tonKho.Count = sumInput - sumOutput;
                    tonKho.Object = item;

                    TonKhoList.Add(tonKho);
                    i++;
                }
            }
        }
    }
}
