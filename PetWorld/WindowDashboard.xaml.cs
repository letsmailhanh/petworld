using DataAccess.Model;
using DataAccess.Repository;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for WindowDashboard.xaml
    /// </summary>
    public partial class WindowDashboard : Window, INotifyPropertyChanged
    {
        User user;
        IUserRepository userRepo;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        IPetDetailRepository petRepo;
        IOrderRepository orderRepo;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SeriesCollection SeriesCollection { get; set; }
        public AxesCollection AxisYCollection { get; set; }

        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

        public WindowDashboard(User u, IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository, IOrderRepository orderRepository)
        {
            InitializeComponent();
            user = u;
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
            orderRepo = orderRepository;

            LoadChart();

        }
        private void LoadChart()
        {
            DataContext = this;
            int[] orderNum = orderRepo.GetCurrentWeekNumberOrder();
            decimal[] revenue = orderRepo.GetCurrentWeekRevenue();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title="Order",
                    Values = new ChartValues<int>(orderNum),
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<decimal> (revenue),
                    ScalesYAt = 1
                }
            };

            AxisYCollection = new AxesCollection
            {                
                //new Axis{Title="Revenue", /*Foreground = Brushes.Red,*/ MinValue = 0, Position = AxisPosition.RightTop},
                new Axis{Title = "Order", MinValue = 0, Position = AxisPosition.LeftBottom},
                new Axis{Title="Revenue", MinValue = 0, Position = AxisPosition.RightTop},
            };

            Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            //Formatter = value => value.ToString("N");
        }
        private void btnUserClick(object sender, RoutedEventArgs e)
        {
            var userWindow = new WindowUser(userRepo, user);
            userWindow.Show();
            this.Close();
        }

        private void btnProductClick(object sender, RoutedEventArgs e)
        {
            var productWindow = new WindowProduct(user, productRepo, categoryRepo, petRepo);
            productWindow.Show();
            this.Close();
        }

        private void btnOrderClick(object sender, RoutedEventArgs e)
        {
            var orderWindow = new WindowOrder(orderRepo);
            orderWindow.Show();
            this.Close();
        }
    }
}
