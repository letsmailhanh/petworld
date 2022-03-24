using DataAccess.Model;
using DataAccess.Repository;
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
using System.Windows.Shapes;

namespace PetWorld
{
    /// <summary>
    /// Interaction logic for WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        IOrderRepository orderRepo;
        public WindowOrder(IOrderRepository orderRepository)
        {
            InitializeComponent();
            orderRepo = orderRepository;

            LoadOrderList();

            //Set default date for datepicker
            dpkFrom.SelectedDate = DateTime.Today;
            dpkTo.SelectedDate = DateTime.Today;

            tbMessage.Visibility = Visibility.Collapsed;
        }

        private void LoadOrderList()
        {
            lvOrder.ItemsSource = orderRepo.GetOrderList();
            //for (int i = 0; i < lvOrder.Items.Count; i++)
            //{
            //    Order o = (Order)lvOrder.Items[i];
                
            //    string status;
            //    if(o.Status == 0)
            //    {
            //        status = "Unconfirmed";
            //    }else if(o.Status == 1)
            //    {
            //        status = "Confirmed";
            //    }
            //    else if (o.Status == 2)
            //    {
            //        status = "Shipping";
            //    }
            //    else if (o.Status == 3)
            //    {
            //        status = "Shipped";
            //    }
            //    else
            //    {
            //        status = "Undefined";
            //    }
            //    MessageBox.Show(status);
            //}
        }

        private void cbOrderByChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbStatusChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string status = cbStatus.SelectedValue.ToString();
                MessageBox.Show(status);
                List<Order> orders = orderRepo.GetOrderListByStatus(status).ToList();
                checkList(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Order status");
            }
        }

        private void checkList(List<Order> list)
        {
            if (list.Count != 0)
            {
                lvOrder.Visibility = Visibility.Visible;
                lvOrder.ItemsSource = list;
                tbMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbMessage.Visibility = Visibility.Visible;
                tbMessage.Text = "No matching item!";
                lvOrder.Visibility = Visibility.Hidden;
            }
        }
        private void dpkFromChange(object sender, SelectionChangedEventArgs e)
        {
            List<Order> orders;
            try
            {
                DateTime fromDate = (DateTime)dpkFrom.SelectedDate;
                DateTime toDate = (DateTime)dpkTo.SelectedDate;
                orders = orderRepo.GetOrderListInPeriod(fromDate, toDate).ToList();
                checkList(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select date");
            }
        }

        private void dpkToChange(object sender, SelectionChangedEventArgs e)
        {
            List<Order> orders;
            try
            {
                DateTime fromDate = (DateTime)dpkFrom.SelectedDate;
                DateTime toDate = (DateTime)dpkTo.SelectedDate;
                orders = orderRepo.GetOrderListInPeriod(fromDate, toDate).ToList();
                checkList(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select date");
            }
        }
    }
}
