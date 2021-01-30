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

namespace Painter
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			IsDraw = false; // в начальный момент перо поднято

			R = 1; // в начале перо самое тонкое

			Color = Brushes.Red; // установить красный цвет
			rbRed.IsChecked = true; // установить радиобаттон
		}

		Brush Color; // цвет пера

		bool IsDraw; // опущено ли перо?

		double R; // толщина линии

		private void cmDown(object sender, MouseButtonEventArgs e)
		{
			IsDraw = true; // опустить перо
		}

		private void cmUp(object sender, MouseButtonEventArgs e)
		{
			IsDraw = false; // поднять перо
		}

		private void cmMove(object sender, MouseEventArgs e)
		{
			if (IsDraw) // если перо опущено
			{
				// проверяем находится ли мышка над холстом
				if ((e.GetPosition(g).X < 0) || (e.GetPosition(g).X > g.Width))
				{
					return;
				}
				if ((e.GetPosition(g).Y < 0) || (e.GetPosition(g).Y > g.Height))
				{
					return;
				}

				// если над холстом, то рисуем точку (эллипс)
				Ellipse O = new Ellipse(); // создать объект точки
				O.Width = R; // установить толщину 
				O.Height = R;
				O.Fill = Color; // текущий цвет
				O.Margin = new Thickness(e.GetPosition(g).X - R / 2, e.GetPosition(g).Y - R / 2, 0, 0); // центр под указателем мышки
				g.Children.Add(O); // добавить на холст
			}
		}

		private void cmClear(object sender, RoutedEventArgs e)
		{
			g.Children.Clear(); // очистить холст
		}

		private void cmRed(object sender, RoutedEventArgs e)
		{
			Color = Brushes.Red; // установить цвет пера
			rColor.Fill = Color; // установить цвет прямоугольника
		}

		private void cmBlue(object sender, RoutedEventArgs e)
		{
			Color = Brushes.Blue; // установить цвет пера
			rColor.Fill = Color; // установить цвет прямоугольника
		}

		private void cmGreen(object sender, RoutedEventArgs e)
		{
			Color = Brushes.Green; // установить цвет пера
			rColor.Fill = Color; // установить цвет прямоугольника
		}

		private void cmSize(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			R = slSize.Value; // установить толщину пера
		}
	}
}
