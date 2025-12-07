using Icarus_Drone_Service_Application.Models;
using Icarus_Drone_Service_Application.ViewModels;
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

namespace Icarus_Drone_Service_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DronesMainView.Loaded += (s, e) => UpdateDronesMainWidths();
            DronesMainView.SizeChanged += (s, e) => UpdateDronesMainWidths();
        }

        private void UpdateDronesMainWidths()
        {
            double totalWidth = DronesMainView.ActualWidth - 20;
            if (totalWidth <= 0) return;

            double unit = totalWidth / 13;

            ColServiceTag.Width = 1 * unit;
            ColClientName.Width = 2 * unit;
            ColDroneModel.Width = 2 * unit;
            ColServiceProblem.Width = 6 * unit;
            ColServiceCost.Width = 2 * unit;
        }

        // 6.12 ::
        // 6.13 ::
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Only clear if user clicked outside the ListView
            if (!DronesMainView.IsMouseOver && 
                !DronesFinishedBox.IsMouseOver &&
                !DroneInformationHelper.IsMouseOver)
                ((MainViewModel)DataContext).SelectedDrone = null;
        }

        // 6.16 ::
        private void DronesFinishedBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DronesFinishedBox.SelectedItem is Drone)
            {
                ((MainViewModel)DataContext).DeleteDroneFromFinishedList();
            }
        }
    }
}