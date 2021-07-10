using System.Windows;

namespace Thesis
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

        private void btnEditDB_Click(object sender, RoutedEventArgs e)
        {
            EditorDB editorDBWindow = new EditorDB();
            editorDBWindow.Show();
            Close();
        }

        private void btnEditSheets_Click(object sender, RoutedEventArgs e)
        {
            EditorSheets editorSheetsWindow = new EditorSheets();
            editorSheetsWindow.Show();
            Close();
        }
    }
}
