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
        private CollectionViewSource equipmentViewSource;

        public EditorDB()
        {
            InitializeComponent();

            equipmentViewSource = (CollectionViewSource)FindResource(nameof(equipmentViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            equipmentViewSource.Source = Services.GetObservableCollection<Equipment>();

            Services.ColumnPlaceholder<Equipment>(dgTables);

            Title = "Editing the DB(Table \"Equipment\")";
        }

        private void itemSave_Click(object sender, RoutedEventArgs e)
        {
            Services.context.SaveChanges();
            dgTables.Items.Refresh();
        }

        private void itemBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbRes = MessageBox.Show("Save changes before exiting?", "Changing the DB", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (mbRes == MessageBoxResult.Yes)
                Services.context.SaveChanges();
            else if (mbRes == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        /// <summary>
        /// Event handler for the "Edit" menu buttons"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = (MenuItem)sender;

            if (MessageBox.Show("Save changes before exiting?", "Changing the DB", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Services.context.SaveChanges();

            // Determines which button is pressed
            if (btn == itemEquipment)
            {
                equipmentViewSource.Source = Services.GetObservableCollection<Equipment>();
                Services.ColumnPlaceholder<Equipment>(dgTables);
                Title = "Editing the DB(Table \"Equipment\")";
            }
            else if (btn == itemEvent)
            {
                equipmentViewSource.Source = Services.GetObservableCollection<Event>();
                Services.ColumnPlaceholder<Event>(dgTables);
                Title = "Editing the DB(Table \"Event\")";
            }
            else if (btn == itemWorkplace)
            {
                equipmentViewSource.Source = Services.GetObservableCollection<Workplace>();
                Services.ColumnPlaceholder<Workplace>(dgTables);
                Title = "Editing the DB(Table \"Workplace\")";
            }
            else if (btn == itemWorkplaceForEvent)
            {
                equipmentViewSource.Source = Services.GetObservableCollection<WorkplaceForEvent>();
                Services.ColumnPlaceholder<WorkplaceForEvent>(dgTables);
                Title = "Editing the DB(Table \"Workplace for Event\")";
            }

            // Updates the DataGrid
            dgTables.Items.Refresh();
        }
    }
}