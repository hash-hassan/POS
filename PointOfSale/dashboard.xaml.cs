using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Page
    {
        List<productModel> products = Handler.getProducts();
        List<productModel> searchProducts = new List<productModel>();
        ObservableCollection<productModel> addedProducts = new ObservableCollection<productModel>();
        public dashboard()
        {
            InitializeComponent();
          //  List<productModel> products = Handler.getProducts();
            productList.ItemsSource = products;
            entryList.ItemsSource = addedProducts;
        }


        private void searchData(string searchTerm)
        {
            foreach (productModel p in products)
            {
                if (p.prod_ID.ToString().Contains(searchTerm.ToLower()) || p.prod_Name.ToString().ToLower().Contains(searchTerm.ToLower()))
                {
                    searchProducts.Add(p);
                }
            }
        }

        private void nameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchProducts.Clear();
            productList.ItemsSource = null;
            if (nameSearch.Text.Length != 0)
            {
                searchData(nameSearch.Text);
                productList.ItemsSource = searchProducts;
            }
            else
            {
                productList.ItemsSource = products;
            }
        }

        private void zero_Button_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "0";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "3";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "2";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "1";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "6";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "5";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "4";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "9";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "8";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            nameSearch.Text = nameSearch.Text + "7";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            string s = nameSearch.Text;

            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "";
            }

            nameSearch.Text = s;
        }

        private void productList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (productList.SelectedItem != null && !addedProducts.Any(prod => prod.prod_ID == (productList.SelectedItem as productModel).prod_ID))
            {
                addedProducts.Add(productList.SelectedItem as productModel);
            }
            //if (entryList.Items.IndexOf(productList.SelectedItem as productModel) == -1)
            //{
            //}
        }

        private void subQty_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;
            productModel product = item.DataContext as productModel;
            int index = addedProducts.IndexOf(product);
            if (addedProducts[index].quantity > 1)
            {
                addedProducts[index].quantity--;
                addedProducts[index].total = addedProducts[index].quantity * addedProducts[index].price;
                entryList.ItemsSource = null;
                entryList.ItemsSource = addedProducts;
            }
        }

        private void addQty_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;
            productModel product = item.DataContext as productModel;
            int index = addedProducts.IndexOf(product);
            addedProducts[index].quantity++;
            addedProducts[index].total = addedProducts[index].quantity * addedProducts[index].price;
            entryList.ItemsSource = null;
            entryList.ItemsSource = addedProducts;
        }

        
        private void quantity_text_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox item = sender as TextBox;
            if (item.Text.Length == 0)
            {
                item.Text = "1";
            }
            if (e.Key == Key.Enter )
            {
                productModel product = item.DataContext as productModel;
                productModel productFound = null;
                try
                {
                    productFound = addedProducts.Single(prod => prod.prod_ID == product.prod_ID);
                    int index = addedProducts.IndexOf(productFound);
                    addedProducts[index].quantity = int.Parse(item.Text == string.Empty ? "0" : item.Text);
                    addedProducts[index].total = addedProducts[index].quantity * addedProducts[index].price;
                    entryList.ItemsSource = null;
                    entryList.ItemsSource = addedProducts;
                    
                }
                catch (System.InvalidOperationException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;
            productModel product = item.DataContext as productModel;
            productModel productFound = null;
            try
            {
                productFound = addedProducts.Single(prod => prod.prod_ID == product.prod_ID);
                int index = addedProducts.IndexOf(productFound);
                addedProducts.RemoveAt(index);
            }
            catch (System.InvalidOperationException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void quantity_text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void quantity_text_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox item = sender as TextBox;
            productModel product = item.DataContext as productModel;
            productModel productFound = null;
            try
            {
                productFound = addedProducts.Single(prod => prod.prod_ID == product.prod_ID);
                int index = addedProducts.IndexOf(productFound);
                addedProducts[index].quantity = int.Parse(item.Text == string.Empty ? "0" : item.Text);
                addedProducts[index].total = addedProducts[index].quantity * addedProducts[index].price;
                entryList.ItemsSource = null;
                entryList.ItemsSource = addedProducts;
            }
            catch (System.InvalidOperationException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
