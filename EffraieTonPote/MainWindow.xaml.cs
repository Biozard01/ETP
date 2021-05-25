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
		}

		/* Bouton play on-click */
		private void Start(object sender, RoutedEventArgs e)
		{
			/* Path dynamique à faire (va chercher le bon user) */
            string picture = "Assets\\arrow.png";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory.Replace("\\bin\\Debug\\net5.0-windows", ""), picture);

            Arrow.Source = new BitmapImage(new Uri(path));

			/* Variable global pour les points */
			Application.Current.Properties["Points"] = 0;

			/* Affichage des éléments */
			Play.Visibility = Visibility.Hidden;
			Arrow.Visibility = Visibility.Visible;

			/* Determination de la direction de la flèche*/
			ArrDirect arrDirect = new ArrDirect();
			arrDirect.ArrDir();

			/* Événements déclanché par la pression d'une touche */
			KeyHandling keyHandling = new KeyHandling();
			KeyUp += keyHandling.KeyHandler;
		}
	}
}