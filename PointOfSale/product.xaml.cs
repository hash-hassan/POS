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
    /// Interaction logic for product.xaml
    /// </summary>
    public partial class product : Page
    {
        public product()
        {
            InitializeComponent();
            List<productModel> products = Handler.getProducts();
            productList.ItemsSource = products; 
        }

        private void btn_prodAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Source = new Uri(@"productForm.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            productForm updateForm = new productForm();
            Button button = sender as Button;
            productModel product = button.DataContext as productModel;
            updateForm.FillFields(product);
            MainWindow.frame.Navigate(updateForm);
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you really want to delete this product?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Button button = sender as Button;
                    productModel product = button.DataContext as productModel;
                    int x = Handler.deleteProduct(product.prod_ID);
                    if (x != 0)
                    {
                        MessageBox.Show("Product Deleted Successfully");
                        
                    }

                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
