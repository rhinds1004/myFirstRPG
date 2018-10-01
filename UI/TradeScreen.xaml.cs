using Engine.Models;
using Engine.ViewModels;
using System.Windows;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// Allows the player to interact with traders within the game.
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSession Session => DataContext as GameSession; //casting the DataContent object as a GameSession object. Used to reference player stuff
        public TradeScreen()
        {
            InitializeComponent();
        }

        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player

            if(item != null)
            {
                Session.CurrentPlayer.Gold += item.Price;
                Session.CurrentTrader.AddItemToInventory(item);
                Session.CurrentPlayer.RemoveItemFromInventory(item);
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player

            if (item != null)
            {
                if (Session.CurrentPlayer.Gold >= item.Price)
                {
                    Session.CurrentPlayer.Gold -= item.Price;
                    Session.CurrentTrader.RemoveItemFromInventory(item);
                    Session.CurrentPlayer.AddItemToInventory(item);
                }
                else
                {
                    MessageBox.Show("You do not have enough gold.");
                }
            }
        }

        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnClick_SellAll(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player
         
           
            if (item != null)
            {
             
                for(int i = Session.CurrentPlayer.Inventory.Count - 1; i > 0; i--)
                {
                    if(Session.CurrentPlayer.Inventory[i].Name == item.Name)
                    {
                        Session.CurrentPlayer.Gold += Session.CurrentPlayer.Inventory[i].Price;
                        Session.CurrentTrader.AddItemToInventory(Session.CurrentPlayer.Inventory[i]);
                        Session.CurrentPlayer.RemoveItemFromInventory(Session.CurrentPlayer.Inventory[i]);
                    }
                }

              
            }
        }
            
    }
}
