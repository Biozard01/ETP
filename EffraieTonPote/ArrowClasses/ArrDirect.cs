using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace EffraieTonPote
{
	class ArrDirect : MainWindow
	{
		/* Determination de la direction de la flèche */
		public ArrDirect()
		{
			Console.WriteLine("arr1");

			/* Affichage des éléments */
			TextBlock0.Visibility = Visibility.Visible;
			
			Console.WriteLine("arr2");
			/* Détermin pick */

			Random random = new();
			Application.Current.Properties["Pick"] = random.Next(1, 5);
			int pick = (int)Application.Current.Properties["Pick"];

			Console.WriteLine(pick);

			switch (pick)
			{
				case 1:
					RotateTransform rotateTransform = new(-90);
					Arrow.RenderTransform = rotateTransform;
					break;

				case 2:
					rotateTransform = new(90);
					Arrow.RenderTransform = rotateTransform;
					break;

				case 3:
					rotateTransform = new(180);
					Arrow.RenderTransform = rotateTransform;
					break;

				default:
					rotateTransform = new(0);
					Arrow.RenderTransform = rotateTransform;
					break;
			}
		}
	}
}