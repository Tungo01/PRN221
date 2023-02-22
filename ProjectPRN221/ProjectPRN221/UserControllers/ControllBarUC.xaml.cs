using ProjectPRN221.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPRN221.UserControllers
{
    /// <summary>
    /// Interaction logic for ControllBarUC.xaml
    /// </summary>
    public partial class ControllBarUC : UserControl
    {
        public ControlBarViewModel ViewModel { get; set; }
        public ControllBarUC()
        {
            InitializeComponent();
            ViewModel = new ControlBarViewModel();
            this.DataContext = ViewModel;
        }

    }
}
