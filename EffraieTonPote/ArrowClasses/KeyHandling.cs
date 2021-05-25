using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EffraieTonPote
{
	 class KeyHandling : MainWindow
	{
		/* Événements déclanché par la pression d'une touche */
		public void KeyHandler(object sender, KeyEventArgs e)
		{
			/*Determination de la direction de la flèche*/
			new ArrDirect();
			
			Console.WriteLine("key");

			/* Test pour voir si les touche relaché correspondent aux bonne direction de flèches */
			int pick = (int)Application.Current.Properties["Pick"];
			int points = (int)Application.Current.Properties["Points"];

			Console.WriteLine(pick);
			Console.WriteLine(points);

			if (pick == 1 && e.Key == Key.Up || pick == 2 && e.Key == Key.Down || pick == 3 && e.Key == Key.Left || pick == 4 && e.Key == Key.Right)
			{
				Console.WriteLine(pick);
				points++;
				Application.Current.Properties["Points"] = points;
				TextBlock0.Text = "Scores : " + points;
				TextBlock1.Background = Brushes.LightGreen;
			}

			else
			{
				Console.WriteLine(pick);
				Application.Current.Properties["Points"] = 0;
				TextBlock0.Text = "Scores : " + points;
				TextBlock1.Background = Brushes.LightSalmon;
				
				//System.Environment.Exit(1);
			}
		}
	}
}