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
using DEMO2020GameShop.Model;

namespace DEMO2020GameShop.Main.Shop
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        Model.DEMO2020Entities context = new Model.DEMO2020Entities();

        public Shop()
        {
            InitializeComponent();
            var game = context.game.ToList()
                .Select(i =>
                new GameRegionPrice
                {
                    Game = i,
                    Price = i.regionGame.Where(g => g.region == Main.User.Region).FirstOrDefault().price,
                    Limit = Helpers.GameAge.IsAgeComplete(Main.User.DateOfBirth.Value,
                    i.regionGame.Where(g => g.region == Main.User.Region).FirstOrDefault().ageLimit1)
                });
            GameList.ItemsSource = game;
        }

        private class GameRegionPrice
        {
            public game Game { get; set; }
            public decimal Price { get; set; }
            public bool Limit { get; set; }

        }

        private void ShowGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GameList.SelectedItem.ToString());
            if (GameList.SelectedItem is GameRegionPrice game)
            {
            }
        }
    }



}
