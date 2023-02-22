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
using System.Windows.Threading;

namespace Zriker {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Popup : Window {

        public Popup() {
            InitializeComponent();
            Left = System.Windows.SystemParameters.WorkArea.Width - Width - 20;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height - 20;
            App.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            message.Text = MainWindow.message;
        }
    }
}
