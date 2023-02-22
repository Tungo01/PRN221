using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectPRN221.ViewModel
{
    public class ControlBarViewModel :BaseViewModel
    {
        #region
        public ICommand CloseCommand { get; set; }
        #endregion

        public ControlBarViewModel() 
        {
            CloseCommand = new RelayCommand<UserControl>(p => { return p == null ? false : true; }, p => {
                GetWindowParent(p); 
            });
        }

        void GetWindowParent( UserControl p)
        {

        }
    }
}
