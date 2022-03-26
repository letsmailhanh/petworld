using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<Order> orders = orderRepo.GetOrderList().ToList();
            lvOrder.ItemsSource = orders;

            List<statusItem> statusList = new List<statusItem>();
            foreach (Order o in orders)
            {
                switch (o.Status)
                {
                    case 0: statusList.Add(new statusItem("Unconfirmed", "#f5dada", "Red")); break;
                    case 1: statusList.Add(new statusItem("Confirmed", "#fce0c2", "Orange")); break;
                    case 2: statusList.Add(new statusItem("Shipping", "#fcfac0", "Yellow")); break;
                    case 3: statusList.Add(new statusItem("Shipped", "#daf5db", "Green")); break;
                }
            }
            lvStatus.ItemsSource = statusList;
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
                    tbStatus.Foreground = new SolidColorBrush(Colors.Red);
                    btnConfirm.Visibility = Visibility.Visible;
                    break;
                case 1:
                    tbStatus.Text = "Confirmed";
                    tbStatus.Foreground = new SolidColorBrush(Colors.Orange);
                    btnConfirm.Visibility = Visibility.Collapsed;
                    break;
                case 2: 
                    tbStatus.Text = "Shipping"; 
                    tbStatus.Foreground = new SolidColorBrush(Colors.Yellow);
                    btnConfirm.Visibility = Visibility.Collapsed;
                    break;
                case 3: 
                    tbStatus.Text = "Shipped"; 
                    tbStatus.Foreground = new SolidColorBrush(Colors.Green);
                    btnConfirm.Visibility = Visibility.Collapsed;
                    break;
            }

            //Load list product name
            List<Product> products = ordDetailRepo.GetProductListByOrder(selected).ToList();
            lvProductName.ItemsSource = products;

            //Load order date
            tbOrderDate.Text = selected.OrderDate.ToString("MM/dd/yyyy");

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            //Load shipping fee
            tbFreight.Text = selected.Freight.ToString("#,###", cul.NumberFormat);

            //Load total
            tbTotal.Text = orderRepo.CalculateOrderRevenue(selected).ToString("#,###", cul.NumberFormat);

        }

        private void btnConfirmClick(object sender, RoutedEventArgs e)
        {
            //Change order status
            Order selected = (Order)lvOrder.SelectedItem;
            selected.Status = 2;
            btnConfirm.Visibility = Visibility.Hidden;
            tbStatus.Text = "Confirmed";
            LoadOrderList();
        }
    }

    public class statusItem
    {
        public string name { get; set; }
        public string background { get; set; }

        public string foreground { get; set; }

        public statusItem(string name, string background, string foreground)
        {
            this.name = name;
            this.background = background;
            this.foreground = foreground;
        }
    }
}
