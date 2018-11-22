using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace DoctorClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetPeople();
        }

        private void GetPeople()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:61111/api/patient").Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    var PatientList = JsonConvert.DeserializeObject<IEnumerable<Patient>>(content);

                    Patients.ItemsSource = PatientList;
                }
                else
                {
                    MessageBox.Show("Failed to get patients! " + result.StatusCode);
                }
            }
        }

        private void GridViewColumn_Checked(object sender, RoutedEventArgs e)
        {
            Patients.Items.Remove((Patient)Patients.SelectedItem);
        }
    }
}
