using Microsoft.EntityFrameworkCore;
using System.Windows;
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

        private void itemSave_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            hereDataGrid.Items.Refresh();
        }
    }
}
