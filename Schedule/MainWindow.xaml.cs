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
        public List<Currencies> Currencies { get; set; } = new List<Currencies>();
        public MainWindow()
        {
            InitializeComponent();
            Currencies.Add(new Schedule.Currencies
            {
                Code = "USD",
                Count = 1,
                Name = "Доллар США",
                Currency = 73.2056,
                Changes = -0.7242
            });
            Listview.ItemsSource = Currencies;
        }
    }
}
