using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WCT_Temperatur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_berechne_Click(object sender, RoutedEventArgs e)
        {
            double temp;         
            double kmh;
            double wct;
            bool didit = double.TryParse(eingabe_C.Text, out temp);
            bool didit2 = double.TryParse(eingabe_Kmh.Text, out kmh);
            if(!didit || !didit2)
            {
                MessageBox.Show("Wir brauchen hier gültige Eingaben, also Zahlen bitte!");
                eingabe_Kmh.Clear();
                eingabe_C.Clear();
                return;
            }
            if(kmh >= 10 && temp <= 10)
            {
                double kmh2 = Math.Pow(kmh, 0.16);


                wct = (13.12 + (0.6215 * temp)) - (11.37 * kmh2) + ((0.3965 * temp) * kmh2);
                //MessageBox.Show($"Die WindChilTemperatur beträgt {wct:f1}°C");
                ausgabe_WCT.Content = $"{wct:f1}";
                eingabe_C.Clear();
                eingabe_Kmh.Clear();
            }
            else
            {
                MessageBox.Show("Eine Berechnung mit diesen Werten ist nicht möglich. Die Temperatur muss 10° oder niedrieger sein und die Windgeschwindigkeit muss 10 Kmh oder höher sein."); 
                eingabe_C.Clear();
                eingabe_Kmh.Clear();
                return;
            }


        }

        private void beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            eingabe_C.Focus();
        }
    }
}