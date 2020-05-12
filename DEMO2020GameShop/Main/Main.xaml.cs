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
using DEMO2020GameShop.Model;

namespace DEMO2020GameShop.Main
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public static Model.user User { get; set; }

        DispatcherTimer timer = new DispatcherTimer();

        private bool dontClose = false;

        public Main(user user)
        {
            InitializeComponent();
            timer.Tick += this.ExitInWindow;
            User = user;
            timer.Interval = new TimeSpan(0, 15,0);
            RepemberMeEnable();
            RestartTimer();
        }

        private void RepemberMeEnable()
        {
            dontClose = FirstWindow.Helpers.Authhelper.IsRemember();
        }

        private void RestartTimer()
        {
            //timer.Stop();
            if (!dontClose)
            {
                timer.Start();
            }
        }

        private void ExitInWindow(object sender, EventArgs e)
        {
            Helpers.MsgBoxHelper.Info("Вы бездействовали 15 минут");
            Application.Current.Shutdown();
        }

        private void ShowTitle(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                this.Title = page.Title;
            }

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            RestartTimer();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            RestartTimer();
        }
    }
}
