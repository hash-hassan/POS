using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class Handler
    {
        static SqlConnection connection = new SqlConnection(PointOfSale.Properties.Settings.Default.prounthaDBConnectionString);

        public static int setProduct(string name, int price, string type)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("setProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //Adding input parameters
                cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.AddWithValue("@price", SqlDbType.Money).Value = price;
                cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
              
                ////Adding output parameter
                //cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;

                int rowNum = cmd.ExecuteNonQuery();

                ////Getting value of output parameter
                //int r_id = Convert.ToInt32(cmd.Parameters["@NewId"].Value);

                //connection.Close();
                return rowNum;
            }
            catch (SqlException e)
            {
                System.Windows.MessageBox.Show("SQL Exception Occured with code " + e.Number + "\n" + e.Message + " at line number: " + e.LineNumber + " of " + e.Procedure);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<productModel> getProducts()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("getProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                List<productModel> products = new List<productModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    products.Add(new productModel(dt.Rows[i][1].ToString(), int.Parse(dt.Rows[i][0].ToString()), float.Parse(dt.Rows[i][2].ToString()), dt.Rows[i][3].ToString()));

                }

                return products;
            }
            catch (SqlException e)
            {
                System.Windows.MessageBox.Show("SQL Exception Occured with code " + e.Number + "\n" + e.Message + " at line number: " + e.LineNumber + " of " + e.Procedure);
                return new List<productModel>();
            }
            finally
            {
                connection.Close();
            }
        }

        public static int updateProduct(int id, string name, int price, string type)
        {
            try
            {
                int result = 0;
                connection.Open();
                SqlCommand cmd = new SqlCommand("update_product", connection);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.AddWithValue("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                //connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                System.Windows.MessageBox.Show("SQL Exception Occured with code " + e.Number + "\n" + e.Message + " at line number: " + e.LineNumber + " of " + e.Procedure);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int deleteProduct(int prod_ID)
        {
            try
            {
                int result = 0;
                connection.Open();
                SqlCommand cmd = new SqlCommand("del_product", connection);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = prod_ID;
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                //connection.Close();

                return result;
            }
            catch (SqlException e)
            {
                System.Windows.MessageBox.Show("SQL Exception Occured with code " + e.Number + "\n" + e.Message + " at line number: " + e.LineNumber + " of " + e.Procedure);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<billModel> getBills(DateTime date1, DateTime date2)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("getBills", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date1", SqlDbType.DateTime).Value = date1;
                cmd.Parameters.AddWithValue("@date2", SqlDbType.DateTime).Value = date2;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                List<billModel> products = new List<billModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    products.Add(new billModel(long.Parse(dt.Rows[i][0].ToString()), float.Parse(dt.Rows[i][1].ToString()), DateTime.Parse(dt.Rows[i][2].ToString()), dt.Rows[i][3].ToString(), float.Parse(!(dt.Rows[i][4].ToString() == "") ? dt.Rows[i][4].ToString() : "0.0")));
                }

                return products;
            }
            catch (SqlException e)
            {
                System.Windows.MessageBox.Show("SQL Exception Occured with code " + e.Number + "\n" + e.Message + " at line number: " + e.LineNumber + " of " + e.Procedure);
                return new List<billModel>();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
