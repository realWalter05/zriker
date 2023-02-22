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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public static int timerTime { get; set; }
        public static string message { get; set; }

        DispatcherTimer timer = new DispatcherTimer();

		public MainWindow() {
            InitializeComponent();
            Left = System.Windows.SystemParameters.WorkArea.Width - Width - 40;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height - 40;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            userListTime.PreviewMouseDown += DeleteUserTimeText;
            

            void timer_Tick(object sender, EventArgs e) {
                timerTime--;
                if (timerTime <= 0) {
                    Popup popup = new Popup();
                    popup.Show();
                    timer.Stop();
                }
            }
        }

        public string Message(RichTextBox rtb) {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        public void DisableSelectedTime(object sender, EventArgs e) {
            userListTime.SelectedIndex = -1;
        }

        public void DeleteUserTimeText(object sender, EventArgs e) {
            userTime.Text = "";
        }

        public void StartTimer(object sender, RoutedEventArgs e) {
            if(userTime.Text.All(Char.IsDigit)) {
                timerTime = GetTime(0);
                message = Message(richTextBox);
                timer.Start();
                App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                App.Current.Windows[0].Close();
            } else if (!userTime.Text.All(Char.IsDigit)) {
                userTimeLabel.Content = "Jen čísla";    
                userTimeLabel.Foreground = new SolidColorBrush(Colors.Red);

                userTime.Text = "";
            }
        }

        public int GetTime(int time) {
            if (userTime.Text == "") {
                string stringTime = userListTime.SelectedItem.ToString();
                if (userListTime.SelectedIndex == 0) {
                    time = 5 * 60;
                } else if (userListTime.SelectedIndex == 1) {
                    time = 10 * 60;
                } else if (userListTime.SelectedIndex == 2) {
                    time = 15 * 60;
                } else if (userListTime.SelectedIndex == 3) {
                    time = 30 * 60;
                } else if (userListTime.SelectedIndex == 4) {
                    time = 45 * 60;
                } else if (userListTime.SelectedIndex == 5) {
                    time = 1 * 60 * 60;
                } else if (userListTime.SelectedIndex == 6) {
                    time = 2 * 60 * 60;
                } else if (userListTime.SelectedIndex == 7) {
                    time = 3 * 60 * 60;
                } else if (userListTime.SelectedIndex == 8) {
                    time = 4 * 60 * 60;
                }
            } else {
                time = Int32.Parse(userTime.Text) * 60;
            }
            return time;
        }

        private void userTime_TextInput(object sender, TextCompositionEventArgs e) {

        }
    }
}
