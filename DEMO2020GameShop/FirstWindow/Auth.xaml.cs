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
using DEMO2020GameShop.FirstWindow.Helpers;
using DEMO2020GameShop.Helpers;
namespace DEMO2020GameShop.FirstWindow
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

        DispatcherTimer timerLock = new DispatcherTimer();

        /// <summary>
        /// Свойсво для хранения данных пользователя 
        /// </summary>

        DEMO2020GameShop.Model.DEMO2020Entities context = new DEMO2020Entities();
        Authhelper Help = new Authhelper();
        Capch capch = new Capch();
        SaveUserLogHelper SaveUserLog = new SaveUserLogHelper();
        UserLockHelper LockHelper = new UserLockHelper();
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Auth()
        {   
            InitializeComponent();
            SetCapchText();
            Login.ItemsSource = SaveUserLog.GetAllUser();
            timer.Tick += this.LogIn;
            timer.Interval = new TimeSpan(0, 0,0,0,1);
            timerLock.Tick += this.Unlock;
            timerLock.Interval = new TimeSpan(0, 0, 0, 5);
            timer.Start();
        }

        private void Unlock(object sender, EventArgs e)
        {
            this.IsEnabled = true;
            timerLock.Stop();
        }

        private void LogIn(object sender, EventArgs e)
        {
            Authapp();
            timer.Stop();
        }

        private void Authapp()
        {
            //foreach (var usercrt in context.user)
            //{
            //    usercrt.Password = Encrypt.EncryptData(usercrt.Password); 
            //}
            context.SaveChanges();
            var user = Help.AuthSaveUser();
            if(user != null)
            {
                Main.Main main = new Main.Main(user);
                main.Show();
                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.Hide();
            }    
        }

        private void SetCapchText()
        {
            capchShow.Text = capch.GenerateCapch();
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogInSystem(object sender, RoutedEventArgs e)
        {
            if (capch.CapchText == CapchText.Text)
            {

                var user = Help.Auth(Login.Text, Pass.Text);
                if (user != null)
                {
                    if (SaveMe.IsChecked.Value)
                    {
                        Help.AuthCreateFile(Login.Text, Pass.Text);
                    }
                    LockHelper.DeleteLock(Login.Text);
                    SaveUserLog.SaveUser(user.Login);
                    Main.Main main = new Main.Main(user);
                    main.Show();
                    MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.Close();

                }
                else
                {
                    if (LockHelper.IsUserLock(Login.Text))
                    {
                        this.IsEnabled = false;
                        timerLock.Start();
                    }
                    else
                    {
                        LockHelper.IncrementLockUser(Login.Text);
                    }
                    MsgBoxHelper.Warning("Такого пользователя нет");
                }
            }
            else
            {
                MsgBoxHelper.Warning("Капча введена не верно");
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            SetCapchText();
        }

        private void GoToReg(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registraton());
        }
    }
}
