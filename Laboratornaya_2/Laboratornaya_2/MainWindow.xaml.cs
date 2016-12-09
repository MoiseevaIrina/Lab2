using Laboratornaya_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Laboratornaya_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void begin_program_Click(object sender, RoutedEventArgs e)
        {
            Client.PrintFn = Print;

            int count;

            if (Int32.TryParse(countFiles.Text, out count))
            {
                for(int i = 1; i<= count;i++)
                Client.GetInfoFromServer(new Server(i));
            }
        }

        public void Print(string text)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate { outputConsole.Text += text; }));
        }
    }
}
