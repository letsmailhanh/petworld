﻿using DataAccess.Repository;
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
        }

        private void LoadOrderList()
        {
            lvOrder.ItemsSource = orderRepo.GetOrderList();
        }
    }
}
