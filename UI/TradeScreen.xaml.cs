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
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player

            if(groupedInventoryItem != null)
            {
                Session.CurrentPlayer.ReceiveGold(groupedInventoryItem.Item.Price);
                Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player

            if (groupedInventoryItem != null)
            {
                if (Session.CurrentPlayer.Gold >= groupedInventoryItem.Item.Price)
                {
                    Session.CurrentPlayer.SpendGold(groupedInventoryItem.Item.Price);
                    Session.CurrentTrader.RemoveItemFromInventory(groupedInventoryItem.Item);
                    Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
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
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem; //gets the item that sent the click event.. in this case the row in the datagrid click by the player


            if (groupedInventoryItem != null)
            {
                              for (int i =groupedInventoryItem.Quantity; i > 0; i--)
                    {

                        Session.CurrentPlayer.ReceiveGold(groupedInventoryItem.Item.Price);
                            Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
                            Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
                        
                    }

                }
            }
        }

    }

