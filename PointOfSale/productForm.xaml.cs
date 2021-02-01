using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for productForm.xaml
    /// </summary>
    public partial class productForm : Page
    {
        public productForm()
        {
            InitializeComponent();
        }
        private int product_ID;
        private void button_click(object sender, RoutedEventArgs e)
        {
            if (submit_btn.Content.ToString() == "SUBMIT")
            {
                if (validateFields())
                {
                    try
                    {
                        Handler.setProduct(prod_Name.Text, int.Parse(prod_Price.Text), prod_Type.Text.ToString());
                        MessageBox.Show("Data Entered Successfully");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Exception Occured with code " + ex.Number + "\n" + ex.Message + " at line number: " + ex.LineNumber + " of " + ex.Procedure);

                    }
                    finally
                    {
                        MainWindow.frame.Source = new System.Uri(@"product.xaml", System.UriKind.RelativeOrAbsolute);
                    }

                }
                else
                {
                    MessageBox.Show("Fields are Empty.");
                }
            }
            else if (submit_btn.Content.ToString() == "UPDATE")
            {
                if (validateFields())
                {
                    try
                    {                        
                        Handler.updateProduct(product_ID, prod_Name.Text, int.Parse(prod_Price.Text), prod_Type.Text.ToString());
                        MessageBox.Show("Data Updated Successfully");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Exception Occured with code " + ex.Number + "\n" + ex.Message + " at line number: " + ex.LineNumber + " of " + ex.Procedure);

                    }
                    finally
                    {
                        MainWindow.frame.Source = new System.Uri(@"product.xaml", System.UriKind.RelativeOrAbsolute);
                    }

                }
                else
                {
                    MessageBox.Show("Fields are Empty.");
                }
            }
        }

        private bool validateFields()
        {
            if (prod_Name.Text != "" && prod_Price.Text != "" && prod_Type.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void FillFields(productModel product)
        {
            prod_Name.Text = product.prod_Name;
            prod_Price.Text = product.price.ToString();
            switch (product.type)
            {
                case "Kitchen":
                    prod_Type.SelectedIndex = 0;
                    break;
                case "Ready Made":
                    prod_Type.SelectedIndex = 1;
                    break;
                default:
                    break;
            }         
            submit_btn.Content = "UPDATE";
            product_ID = product.prod_ID;
        }

    }
}
