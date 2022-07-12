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
using ObserverSystem;


namespace GUI.WindowsOfOperations
{
    /// <summary>
    /// Interaction logic for AddWindow_.xaml
    /// </summary>
    public partial class AddWindow_ : Window
    {
        IMeansObservationOperations bl;
        public AddWindow_(IMeansObservationOperations im)
        {
            InitializeComponent();
            bl = im;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int vision = int.Parse(visionBox.Text), type = int.Parse(typeBox.Text);
                double range = double.Parse(rangeBox.Text);
                bl.AddObserver(type, range, vision);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Input not correct. Please try again");
            }
        }
    }
}
