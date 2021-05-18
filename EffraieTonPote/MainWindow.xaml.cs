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

            Arrow.Visibility = Visibility.Hidden;
            RotateTransform rotateTransform = new(0);
            Arrow.RenderTransform = rotateTransform;
        }

        /* événements déclanché par la pression d'une touche */
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            int pick = (int)Application.Current.Properties["Pick"];
            int points = (int) Application.Current.Properties["Points"];
            
            /* affichage des éléments */

            Arrow.Visibility = Visibility.Visible;

            /* determination de la direction de la flèche */
            Picker();
            ArrDir();

            /* Test pour voir si les touche relaché correspondent aux bonne direction de flèches */
            if (pick == 1 && e.Key == Key.Z || pick == 2 && e.Key == Key.S || pick == 3 && e.Key == Key.Q ||
                pick == 4 && e.Key == Key.D)
             {
                 points++; 
                 Application.Current.Properties["Points"] = points; 
                 TextBlock2.Text = "Scores : " + points; 
                 TextBlock1.Background = Brushes.LightGreen;
             }

            else
            {
                /* Reset de points */
                points = 0;
                Application.Current.Properties["Points"] = 0;
                TextBlock2.Text = "Scores : " + points;
                TextBlock1.Background = Brushes.Red;

                /* Affichage des éléments */
                TextBlock0.Visibility = Visibility.Hidden;
                TextBlock2.Visibility = Visibility.Hidden;
                TextBlock3.Visibility = Visibility.Hidden;

                Arrow.Visibility = Visibility.Hidden;
                RotateTransform rotateTransform = new(0);
                Arrow.RenderTransform = rotateTransform;

                KeyUp -= KeyHandler;
            }
        }

        /* Bouton play on-click */
        private void Play(object sender, RoutedEventArgs e)
        {
            /* Path dynamique à faire (va chercher le bon user) */
            string picture = "C:\\Users\\arthu\\source\\repos\\ETP\\EffraieTonPote\\arrow.png";

            Arrow.Source = new BitmapImage(new Uri(picture));

            /* Variable global pour les points */
            Application.Current.Properties["Points"] = 0;

            /* Affichage des éléments */
            TextBlock0.Visibility = Visibility.Visible;
            TextBlock1.Background = Brushes.LightBlue;
            TextBlock2.Visibility = Visibility.Visible;
            TextBlock3.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Hidden;

            Arrow.Visibility = Visibility.Visible;
            
            /* Determination de la direction de la flèche */
            Picker();
            ArrDir();

            /* Événements déclanché par la pression d'une touche */
            KeyUp += KeyHandler;
        }

        /* Determination de la direction de la flèche */
        private void ArrDir()
        {
            int pick = (int)Application.Current.Properties["Pick"];

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
        }

        /* Random picker */
        private void Picker()
        {
            List<int> arr = new();
            Random random = new();

            for (int i = 0; i <= 4; i++)
            {
                arr.Add(i);
            }

            Application.Current.Properties["Pick"] = random.Next(1, arr.Count);
            int pick = (int)Application.Current.Properties["Pick"];
        }

        /* Timer */
        private void Timer()
        {
            Application.Current.Properties["Time"] = "0";
        }
    }
}
