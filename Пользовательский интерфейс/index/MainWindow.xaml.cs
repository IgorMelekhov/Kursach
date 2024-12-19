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
using System.Timers;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Reflection.Emit;


namespace Пользовательский_интерфейс
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         private SerialPort _serialPort;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string portName = "COM5"; // Убедись, что это правильный номер COM-порта
                _serialPort = new SerialPort(portName, 9600);
                _serialPort.Open();       // Открываем порт
                _serialPort.DataReceived += SerialPort_DataReceived; // Подписываемся на событие получения данных
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to Arduino: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                string receivedData = _serialPort.ReadLine().Trim(); // Читаем строку из порта
                UpdateLabels(receivedData);
            }
        }
        private void UpdateLabels(string input)
        {
            if (input.Length == 6)
            {
                string part1 = input.Substring(0, 2);
                string part2 = input.Substring(2, 2);
                string part3 = input.Substring(4, 2);

                Dispatcher.Invoke(() =>
                {
                    Temperature.Content = part1;
                    Hum.Content = part2;
                    Press.Content = part3;
                });
            }
        }

        private void Info_Click(object sender, MouseButtonEventArgs e)
        {
            PageInfo info = new PageInfo();
            info.Show();
            Close();
        }

        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}

