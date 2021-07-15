using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Thesis
{
    /// <summary>
    /// Interaction logic for EditorDB.xaml
    /// </summary>
    public partial class EditorDB : Window
    {

        private readonly EquipmentContext _context = new();

        private CollectionViewSource equipmentViewSource;

        public EditorDB()
        {
            InitializeComponent();
            equipmentViewSource = (CollectionViewSource)FindResource(nameof(equipmentViewSource));
        }

        private void itemBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Equipments.Load();
            equipmentViewSource.Source = _context.Equipments.Local.ToObservableCollection();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                // Determines which button is pressed
                if (menuItem == itemEquipment)
                {
                    equipmentViewSource.Source = Services.GetObservableCollection<Equipment>();
                    Title = "Editing a database(Table \"Equipment\")";
                }
                else if (menuItem == itemEvent)
                {
                    equipmentViewSource.Source = Services.GetObservableCollection<Event>();
                    Title = "Editing a database(Table \"Event\")";
                }
                else if (menuItem == itemWorkplace)
                {
                    equipmentViewSource.Source = Services.GetObservableCollection<Workplace>();
                    Title = "Editing a database(Table \"Workplace\")";
                }
                else if (menuItem == itemWorkplaceForEvent)
                {
                    equipmentViewSource.Source = Services.GetObservableCollection<WorkplaceForEvent>();
                    Title = "Editing a database(Table \"Workplace of the event\")";
                }

                // Updates the DataGrid
                dgTables.Items.Refresh();
            }
        }

        private void itemSave_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            dgTables.Items.Refresh();
        }
    }
}
