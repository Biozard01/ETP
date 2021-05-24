using System;
using System.Windows;
using System.Windows.Media;

namespace EffraieTonPote
{
	class ArrDirect : MainWindow
	{
		/* Determination de la direction de la flèche */
		public void ArrDir()
		{
			/* Affichage des éléments */
			TextBlock0.Visibility = Visibility.Visible;
			TextBlock2.Visibility = Visibility.Visible;
			TextBlock3.Visibility = Visibility.Visible;

			/* Détermin pick */
			Random random = new();
			Application.Current.Properties["Pick"] = random.Next(1, 5);
			int pick = (int)Application.Current.Properties["Pick"];
			TextBlock2.Text = "" + pick;

			switch (pick)
			{
				case 1:
					string sarrowdir = "haut";
					TextBlock0.Text = "Direction : " + sarrowdir;

					RotateTransform rotateTransform = new(-90);
					Arrow.RenderTransform = rotateTransform;
					break;

				case 2:
					sarrowdir = "bas";
					TextBlock0.Text = "Direction : " + sarrowdir;

					rotateTransform = new(90);
					Arrow.RenderTransform = rotateTransform;
					break;

				case 3:
					sarrowdir = "gauche";
					TextBlock0.Text = "Direction : " + sarrowdir;

					rotateTransform = new(180);
					Arrow.RenderTransform = rotateTransform;
					break;

				default:
					sarrowdir = "droite";
					TextBlock0.Text = "Direction : " + sarrowdir;

					rotateTransform = new(0);
					Arrow.RenderTransform = rotateTransform;
					break;
			}
		}
	}
}