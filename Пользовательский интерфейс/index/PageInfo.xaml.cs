﻿using System;
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

namespace Пользовательский_интерфейс
{
    /// <summary>
    /// Логика взаимодействия для PageInfo.xaml
    /// </summary>
    public partial class PageInfo : Window
    {
        public PageInfo()
        {
            InitializeComponent();
        }

        private void Click_Back(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

    }
}
