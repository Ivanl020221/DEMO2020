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
using DEMO2020GameShop.Helpers;

namespace DEMO2020GameShop.FirstWindow
{
    /// <summary>
    /// Interaction logic for Registraton.xaml
    /// </summary>
    public partial class Registraton : Page
    {
        Model.DEMO2020Entities context = new Model.DEMO2020Entities();

        public Registraton()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegUser(object sender, RoutedEventArgs e)
        {
            Helpers.Authhelper authhelper = new Helpers.Authhelper();
            if (Helpers.Validation.ValidationUser(
                Pass.Text,
                email.Text,
                date.SelectedDate.Value,
                FirstName.Text,
                LastName.Text))
            {
                if (context.user.Where(i =>i.Login == email.Text).Count() <1)
                {
                    context.user.Add(
                  new Model.user
                  {
                      Login = email.Text,
                      Password = Helpers.Encrypt.EncryptData(Pass.Text),
                      FistName = FirstName.Text,
                      LastName = LastName.Text,
                      MiddleName = MiddleName.Text,
                      DateOfBirth = date.SelectedDate
                  });
                    context.SaveChanges();
                    MsgBoxHelper.Info("Пользователь добавлен");
                    NavigationService.GoBack();
                }
                else
                {
                    MsgBoxHelper.Error("Пользователь уже существует");
                }
            }
            else
            {
                MsgBoxHelper.Warning("Не все поля заполнены");
            }
        }
    }
}
