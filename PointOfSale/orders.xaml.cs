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
    /// Interaction logic for orders.xaml
    /// </summary>
    public partial class orders : Page
    {
        public orders()
        {
            InitializeComponent();
            toggle_week.IsChecked = false;
            toggle_day.IsChecked = false;

            day_picker.IsEnabled = false;
            week_start_picker.IsEnabled = false;
            week_end_picker.IsEnabled = false;
        }

        private void day_picker_Loaded(object sender, RoutedEventArgs e)
        {
            day_picker.DisplayDateEnd = DateTime.Now.Date;
        }

        private void week_start_picker_Loaded(object sender, RoutedEventArgs e)
        {
            week_start_picker.DisplayDateEnd = DateTime.Now.Date;
        }

        private void week_end_picker_Loaded(object sender, RoutedEventArgs e)
        {

            week_end_picker.DisplayDateEnd = DateTime.Now.Date;
            week_end_picker.SelectedDate = DateTime.Now;
        }

        private void toggle_week_Click(object sender, RoutedEventArgs e)
        {
            toggle_day.IsChecked = false;           
            day_picker.IsEnabled = false;
           
            week_start_picker.IsEnabled = true;
            week_end_picker.IsEnabled = true;

            if (week_start_picker.SelectedDate == null)
            {
                week_start_picker.SelectedDate = DateTime.Now.AddDays(-7);
            }

        }

        private void toggle_day_Click(object sender, RoutedEventArgs e)
        {
            toggle_week.IsChecked = false;
            week_start_picker.IsEnabled = false;
            week_end_picker.IsEnabled = false;
            day_picker.IsEnabled = true;
            if (day_picker.SelectedDate == null)
            {
                day_picker.SelectedDate = DateTime.Now.Date;
            }

        }

        private void toggle_week_Unchecked(object sender, RoutedEventArgs e)
        {
            week_start_picker.IsEnabled = false;
            week_end_picker.IsEnabled = false;
            week_start_picker.SelectedDate = null;
            week_end_picker.SelectedDate = null;
        }

        private void toggle_day_Unchecked(object sender, RoutedEventArgs e)
        {
            day_picker.IsEnabled = false;
            day_picker.SelectedDate = null;
        }

        private void day_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toggle_day.IsChecked.Value == true)
            {
                DateTime date_end = new DateTime(day_picker.SelectedDate.Value.Year, day_picker.SelectedDate.Value.Month, day_picker.SelectedDate.Value.Day, 23, 59, 59, 998);

                
                List<billModel> bills = Handler.getBills(day_picker.SelectedDate.Value, date_end);
                ordersList.ItemsSource = bills;
                //total_inflow_text.Text = a[0].ToString();
                //total_outflow_text.Text = a[1].ToString();
                //closing_cash_text.Text = handler.getClosingCash(day_picker.SelectedDate.Value);
                //opening_cash_text.Text = handler.getOpeningCash(day_picker.SelectedDate.Value);
                //physical_cash_text.Text = handler.getTotalCashAmount(day_picker.SelectedDate.Value, date_end);
                //cheque_amount_text.Text = handler.getTotalChequeAmount(day_picker.SelectedDate.Value, date_end);
                //cash_diff_text.Text = (int.Parse(total_inflow_text.Text) - int.Parse(total_outflow_text.Text) - int.Parse(physical_cash_text.Text)).ToString();
            }
        }
        private void week_start_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toggle_week.IsChecked.Value == true)
            {
                week_end_picker.DisplayDateStart = week_start_picker.SelectedDate.Value.AddDays(1);
                DateTime date_end = new DateTime(week_end_picker.SelectedDate.Value.Year, week_end_picker.SelectedDate.Value.Month, week_end_picker.SelectedDate.Value.Day, 23, 59, 59, 998);

                List<billModel> bills = Handler.getBills(week_start_picker.SelectedDate.Value, date_end);
                ordersList.ItemsSource = bills;

                //int[] a = handler.getReport(week_start_picker.SelectedDate.Value, date_end);
                //total_inflow_text.Text = a[0].ToString();
                //total_outflow_text.Text = a[1].ToString();
                //opening_cash_text.Text = handler.getOpeningCash(week_start_picker.SelectedDate.Value);
                //physical_cash_text.Text = handler.getTotalCashAmount(week_start_picker.SelectedDate.Value, date_end);
                //cheque_amount_text.Text = handler.getTotalChequeAmount(week_start_picker.SelectedDate.Value, date_end);
                //cash_diff_text.Text = (int.Parse(total_inflow_text.Text) - int.Parse(total_outflow_text.Text) - int.Parse(physical_cash_text.Text)).ToString();
                //closing_cash_text.Text = handler.getClosingCash(week_end_picker.SelectedDate.Value);
            }
        }
        private void week_end_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toggle_week.IsChecked.Value == true)
            {
                week_end_picker.DisplayDateStart = week_start_picker.SelectedDate.Value.AddDays(1);
                DateTime date_end = new DateTime(week_end_picker.SelectedDate.Value.Year, week_end_picker.SelectedDate.Value.Month, week_end_picker.SelectedDate.Value.Day, 23, 59, 59, 998);

                List<billModel> bills = Handler.getBills(week_start_picker.SelectedDate.Value, date_end);
                ordersList.ItemsSource = bills;

                //int[] a = handler.getReport(week_start_picker.SelectedDate.Value, date_end);
                //total_inflow_text.Text = a[0].ToString();
                //total_outflow_text.Text = a[1].ToString();
                //opening_cash_text.Text = handler.getOpeningCash(week_start_picker.SelectedDate.Value);
                //physical_cash_text.Text = handler.getTotalCashAmount(week_start_picker.SelectedDate.Value, date_end);
                //cheque_amount_text.Text = handler.getTotalChequeAmount(week_start_picker.SelectedDate.Value, date_end);
                //cash_diff_text.Text = (int.Parse(total_inflow_text.Text) - int.Parse(total_outflow_text.Text) - int.Parse(physical_cash_text.Text)).ToString();
                //closing_cash_text.Text = handler.getClosingCash(week_end_picker.SelectedDate.Value);
            }
        }
    }
}
