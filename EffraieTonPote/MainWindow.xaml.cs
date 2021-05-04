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

            /* Init de la grid (affichage et dissimulation des éléments)*/

            TextBlock0.Visibility = Visibility.Hidden;
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Visibility = Visibility.Hidden;
            TextBlock3.Visibility = Visibility.Hidden;
            
            Start.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;
            
            Arrow.Visibility = Visibility.Hidden; 
            RotateTransform rotateTransform = new(0);
            Arrow.RenderTransform = rotateTransform;

            /* variable global pour les points */

            Application.Current.Properties["Points"] = 0;

            /* timer */
            
            Application.Current.Properties["Time"] = "0";
            string time = (string)Application.Current.Properties["Time"];

            DispatcherTimer timer = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += ElapsedTime;
            timer.Start();

            void ElapsedTime(object sender, EventArgs e)
            {

                if (time == "5")
                {
                    TextBlock1.Text = "ouah";
                }

            }
        }

        /* bouton play on-click */
        private void Play(object sender, RoutedEventArgs e)
        {
            TextBlock0.Visibility = Visibility.Visible;
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Visibility = Visibility.Visible;
            TextBlock3.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Hidden;
            Stop.Visibility = Visibility.Visible;
        }

        /* bouton reset on-click */
        private void Reset(object sender, RoutedEventArgs e)
        {
            TextBlock0.Visibility = Visibility.Hidden;
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Visibility = Visibility.Hidden;
            TextBlock3.Visibility = Visibility.Hidden;

            Start.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;

            Arrow.Visibility = Visibility.Hidden;
            RotateTransform rotateTransform = new(0);
            Arrow.RenderTransform = rotateTransform;
        }
        
        /* événements déclanché par la pression d'une touche */
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            /* affichage des éléments */

            TextBlock0.Visibility = Visibility.Visible;
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Visibility = Visibility.Visible;
            TextBlock3.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Hidden;
            Stop.Visibility = Visibility.Visible;

            Arrow.Visibility = Visibility.Visible;

            /* init des variables */

            int points = (int)Application.Current.Properties["Points"];
            List<int> arr = new();
            Random random = new();

            for (int i = 0; i <= 4; i++)
            {
                arr.Add(i);
            }

            int pick = random.Next(1, arr.Count);

            TextBlock3.Text = "Gen Number " + pick;

            /* path dynamique à faire (va chercher le bon user) */
            string picture = "C:\\Users\\arthu\\source\\repos\\ETP\\EffraieTonPote\\arrow.png";

            Arrow.Source = new BitmapImage(new Uri(picture));

            /* determination de la direction de la flèche */           

            if (pick == 1)
            {
                string sarrowdir = "haut";
                TextBlock0.Text = "Direction : " + sarrowdir;
                
                RotateTransform rotateTransform = new(-90);
                Arrow.RenderTransform = rotateTransform;
            }

            else if (pick == 2)
            {
                string sarrowdir = "bas";
                TextBlock0.Text = "Direction : " + sarrowdir;
                
                RotateTransform rotateTransform = new(90);
                Arrow.RenderTransform = rotateTransform;
            }

            else if (pick == 3)
            {
                string sarrowdir = "gauche";
                TextBlock0.Text = "Direction : " + sarrowdir;
                
                RotateTransform rotateTransform = new(180);
                Arrow.RenderTransform = rotateTransform;
            }

            else if (pick == 4)
            {
                string sarrowdir = "droite";
                TextBlock0.Text = "Direction : " + sarrowdir;
                
                RotateTransform rotateTransform = new(0);
                Arrow.RenderTransform = rotateTransform;
            }

            /* test pour voir si les touche relaché correspondent aux bonne direction de flèches */
                
            if (pick == 1 && e.Key == Key.Z || pick == 2 && e.Key == Key.S || pick == 3 && e.Key == Key.Q || pick == 4 && e.Key == Key.D)
            {
                points++;
                TextBlock2.Text = "Scores : " + points;
                TextBlock1.Background = Brushes.Green;
            } 
            
            else
            {
                points--;
                TextBlock2.Text = "Scores : " + points;

                TextBlock1.Background = Brushes.Red;
                
                /* affichage des éléments */

                Arrow.Visibility = Visibility.Hidden;
                RotateTransform rotateTransform = new(0);
                Arrow.RenderTransform = rotateTransform;

                Start.Visibility = Visibility.Hidden;
                Stop.Visibility = Visibility.Visible;
            }
            
        }

    }

    
}
