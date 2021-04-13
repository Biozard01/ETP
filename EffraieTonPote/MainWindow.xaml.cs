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

namespace EffraieTonPote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            List<int> arr = new List<int>();

            /* list for the arrow direction init */
            for (int i = 0; i < 5; i++)
            {
                Random random = new Random();
                int pick = random.Next(1, 5);
                arr.Add(pick);
            }


            foreach (var i in arr)
            {
                int points = 0;

                TextBlock3.Text = "Gen Number " + arr[i];

                /* arrow direction display */

                if (i == 1)
                {
                    string sarrowdir = "up";
                    TextBlock0.Text = "Direction : " + sarrowdir;
                }

                else if (i == 2)
                {
                    string sarrowdir = "down";
                    TextBlock0.Text = "Direction : " + sarrowdir;
                }

                else if (i == 3)
                {
                    string sarrowdir = "left";
                    TextBlock0.Text = "Direction : " + sarrowdir;
                }

                else if (i == 4)
                {
                    string sarrowdir = "right";
                    TextBlock0.Text = "Direction : " + sarrowdir;
                }

                /* key matching */
                
                if (i == 1 && e.Key == Key.Z)
                {
                    TextBlock1.Text = "good up";
                    points++;
                    TextBlock2.Text = "Scores : " + points;

                }

                else if (i == 2 && e.Key == Key.S)
                {
                    TextBlock1.Text = "good down";
                    points++;
                    TextBlock2.Text = "Scores : " + points;
                }

                else if (i == 3 && e.Key == Key.Q)
                {
                    TextBlock1.Text = "good left";
                    points++;
                    TextBlock2.Text = "Scores : " + points;
                }

                else if (i == 4 && e.Key == Key.D)
                {
                    TextBlock1.Text = "good right";
                    points++;
                    TextBlock2.Text = "Scores : " + points;
                }

                else
                {
                    TextBlock1.Text = "bad";
                    points = 0;
                    TextBlock2.Text = "Scores : " + points;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock0.Text = "Direction : ";
            TextBlock1.Text = "";
            TextBlock2.Text = "Scores : 0";
            TextBlock3.Text = "";
            TextBlock4.Text = "";
        }
    }

    
}
