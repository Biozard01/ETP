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
        private void Play(object sender, RoutedEventArgs e)
        {
            TextBlock0.Text = "Direction : ";
            TextBlock1.Text = "";
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Text = "Scores : 0";
            TextBlock3.Text = "";
            Arrow.Visibility = Visibility.Hidden;
            RotateTransform rotateTransform = new RotateTransform(0);
            Arrow.RenderTransform = rotateTransform;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            TextBlock0.Text = "Direction : ";
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Text = "Scores : 0";
            TextBlock3.Text = "";
            Arrow.Visibility = Visibility.Hidden;
            RotateTransform rotateTransform = new RotateTransform(0);
            Arrow.RenderTransform = rotateTransform;
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            List<int> arr = new List<int>();
            int points = 0;
            Random random = new Random();
            string picture = "C:\\Users\\arthu\\source\\repos\\ETP\\EffraieTonPote\\arrow.png";
            Arrow.Source = new BitmapImage(new Uri(picture));

            for (int i = 0; i <= 4; i++)
            {
                arr.Add(i);
            }

            int pick = random.Next(1, arr.Count);

            TextBlock3.Text = "Gen Number " + pick;

            /* arrow direction display */

            Arrow.Visibility = Visibility.Visible;

            if (pick == 1)
            {
                RotateTransform rotateTransform = new RotateTransform(-90);
                Arrow.RenderTransform = rotateTransform;

                string sarrowdir = "haut";
                TextBlock0.Text = "Direction : " + sarrowdir;
            }

            else if (pick == 2)
            {
                RotateTransform rotateTransform = new RotateTransform(90);
                Arrow.RenderTransform = rotateTransform;

                string sarrowdir = "bas";
                TextBlock0.Text = "Direction : " + sarrowdir;
            }

            else if (pick == 3)
            {
                RotateTransform rotateTransform = new RotateTransform(180);
                Arrow.RenderTransform = rotateTransform;

                string sarrowdir = "gauche";
                TextBlock0.Text = "Direction : " + sarrowdir;
            }

            else if (pick == 4)
            {
                RotateTransform rotateTransform = new RotateTransform(0);
                Arrow.RenderTransform = rotateTransform;

                string sarrowdir = "droite";
                TextBlock0.Text = "Direction : " + sarrowdir;
            }

            /* key matching */
                
            if (pick == 1 && e.Key == Key.Z)
            {
                TextBlock1.Background = Brushes.Green;
                points++;
                TextBlock2.Text = "Scores : " + points;

            }

            else if (pick == 2 && e.Key == Key.S)
            {
                TextBlock1.Background = Brushes.Green;
                points++;
                TextBlock2.Text = "Scores : " + points;
            }

            else if (pick == 3 && e.Key == Key.Q)
            {
                TextBlock1.Background = Brushes.Green;
                points++;
                TextBlock2.Text = "Scores : " + points;
            }

            else if (pick == 4 && e.Key == Key.D)
            {
                TextBlock1.Background = Brushes.Green;
                points++;
                TextBlock2.Text = "Scores : " + points;
            }

            else
            {
                TextBlock1.Background = Brushes.Red;
                points--;
                TextBlock2.Text = "Scores : " + points;
                RotateTransform rotateTransform = new RotateTransform(0);
                Arrow.RenderTransform = rotateTransform;
                Arrow.Visibility = Visibility.Hidden;
            }
            
        }

    }

    
}
