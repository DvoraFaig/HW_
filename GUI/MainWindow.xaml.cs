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

using ObserverSystem;
using GUI.WindowsOfOperations;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMeansObservationOperations blObservation;
        public MainWindow()
        {
            InitializeComponent();
            blObservation = new ObservationList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow_(blObservation).Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSpecificButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSortedButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowMaxButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
