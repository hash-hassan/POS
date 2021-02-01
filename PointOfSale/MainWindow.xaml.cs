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

namespace PointOfSale
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame;
        

        public MainWindow()
        {
          InitializeComponent();
        }

        private void frame_main_Loaded(object sender, RoutedEventArgs e)
        {
            frame = this.frame_main;
        }

        private void btn_prod_Click(object sender, RoutedEventArgs e)
        {
            frame_main.Source = new System.Uri(@"product.xaml", System.UriKind.RelativeOrAbsolute);
        }

        private void btn_order_Click(object sender, RoutedEventArgs e)
        {
            frame_main.Source = new System.Uri(@"orders.xaml", System.UriKind.RelativeOrAbsolute);
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            frame_main.Source = new System.Uri(@"report.xaml", System.UriKind.RelativeOrAbsolute);
        }

        private void btn_dash_Click(object sender, RoutedEventArgs e)
        {
            frame_main.Source = new System.Uri(@"dashboard.xaml", System.UriKind.RelativeOrAbsolute);
        }


    }
}
