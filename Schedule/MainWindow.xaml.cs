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

namespace Schedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IEnumerable<string> SelectedCodes { get; set; } = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Init();
            drawCanvas();
        }

        private async void Init()
        {
            Button.IsEnabled = false;
            Listview.Visibility = Visibility.Hidden;
            Listview2.Visibility = Visibility.Hidden;
            canvas2.Visibility = Visibility.Visible;
            var parser = new Parser();
            var curr = await parser.GetCurrency();
            curr = curr.Select(s =>
            {
                s.IsChecked = SelectedCodes.Contains(s.Code);
                return s;
            }).ToList();

            Listview.ItemsSource = curr.Where(c => c.IsChecked);

            Listview2.ItemsSource = curr;

            canvas2.Visibility = Visibility.Hidden;
            Listview.Visibility = Visibility.Visible;
            Listview2.Visibility = Visibility.Visible;
            Button.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedCodes = (Listview2.ItemsSource as IEnumerable<Currencies>).Where(p => p.IsChecked).Select(s => s.Code);
            Init();
        }

        void drawCanvas()
        {
            for (int i = 0; i < 12; i++)
            {
                Line line = new Line()
                {
                    X1 = 50,
                    X2 = 50,
                    Y1 = 0,
                    Y2 = 20,
                    StrokeThickness = 5,
                    Stroke = Brushes.Gray,
                    Width = 100,
                    Height = 100
                };
                line.VerticalAlignment = VerticalAlignment.Center;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.RenderTransformOrigin = new Point(.5, .5);
                line.RenderTransform = new RotateTransform(i * 30);
                line.Opacity = (double)i / 12;

                canvas1.Children.Add(line);

            }
        }
    }
}
