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
        IOrderDetailRepository ordDetailRepo;
        public WindowOrder(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            InitializeComponent();
            orderRepo = orderRepository;
            ordDetailRepo = orderDetailRepository;

            LoadOrderList();

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

        private void btnBackClick(object sender, RoutedEventArgs e)
        {

        }

        private void lvOrderSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            //Load list product in order
            Order selected = (Order)lvOrder.SelectedItem;
            List<OrderDetail> list = ordDetailRepo.GetOrderDetailListByOrder(selected).ToList();
            lvOrderDetail.ItemsSource = list;

            //Load order status
            int status = selected.Status;
            switch (status)
            {
                case 0: 
                    tbStatus.Text = "Uncomfirmed"; 
                    tbStatus.Background = new SolidColorBrush(Colors.Red); 
                    break;
                case 1:
                    tbStatus.Text = "Confirmed";
                    tbStatus.Background = new SolidColorBrush(Colors.Orange);
                    break;
                case 2: 
                    tbStatus.Text = "Shipping"; 
                    tbStatus.Background = new SolidColorBrush(Colors.Yellow); 
                    break;
                case 3: 
                    tbStatus.Text = "Shipped"; 
                    tbStatus.Background = new SolidColorBrush(Colors.Green);
                    
                    break;
            }

            //Load order date

            //Load shipping fee
            tbFreight.Text = selected.Freight.ToString("#.##");

            //Load total
            tbTotal.Text = orderRepo.CalculateOrderRevenue(selected).ToString("#.##");

        }

        private void btnConfirmClick(object sender, RoutedEventArgs e)
        {
            //Change order status
        }
    }
}
