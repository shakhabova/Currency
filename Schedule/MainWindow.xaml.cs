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
        }

        private async void Init()
        {
            var parser = new Parser();
            var curr = await parser.GetCurrency();
            curr = curr.Select(s =>
            {
                s.IsChecked = SelectedCodes.Contains(s.Code);
                return s;
            }).ToList();

            Listview.ItemsSource = curr.Where(c => c.IsChecked);

            Listview2.ItemsSource = curr;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedCodes = (Listview2.ItemsSource as IEnumerable<Currencies>).Where(p => p.IsChecked).Select(s => s.Code);
            Init();
        }
    }
}
