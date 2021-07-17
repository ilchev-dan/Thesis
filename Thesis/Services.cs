using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Thesis
{
    public static class Services
    {
        public static EquipmentContext context = new();

        /// <summary>
        /// Getting an ObservableCollection of a specific table from the DB
        /// </summary>
        /// <typeparam name="T">Table from the DB</typeparam>
        /// <returns>ObservableCollection tables</returns>
        public static ObservableCollection<T> GetObservableCollection<T>()
        {
            // Defining a table for getting a collection
            if (typeof(T) == typeof(Equipment))
            {
                context.Equipments.Load();

                return context.Equipments.Local.ToObservableCollection() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Event))
            {
                context.Events.Load();

                return context.Events.Local.ToObservableCollection() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(Workplace))
            {
                context.Workplaces.Load();

                return context.Workplaces.Local.ToObservableCollection() as ObservableCollection<T>;
            }
            else if (typeof(T) == typeof(WorkplaceForEvent))
            {
                context.WorkplaceForEvents.Load();

                return context.WorkplaceForEvents.Local.ToObservableCollection() as ObservableCollection<T>;
            }
            else
                return null;
        }

        /// <summary>
        /// Sets the column headers
        /// </summary>
        /// <typeparam name="T">Table from the DB</typeparam>
        public static void ColumnPlaceholder<T>(DataGrid dgTables)
        {
            // Defines a set of columns for a table
            if (typeof(T) == typeof(Equipment))
            {
                dgTables.Columns[0].Visibility = Visibility.Hidden;
                dgTables.Columns[1].Header = "Type";
                dgTables.Columns[2].Header = "Name";
                dgTables.Columns[3].Header = "Technical specifications";
                dgTables.Columns[4].Header = "Unit of measurement";
                dgTables.Columns[5].Header = "Comment";
                dgTables.Columns[6].Visibility = Visibility.Hidden;
            }
            else if (typeof(T) == typeof(Event))
            {
                dgTables.Columns[0].Visibility = Visibility.Hidden;
                dgTables.Columns[1].Header = "Type of event";
                dgTables.Columns[2].Header = "Number of participants";
                dgTables.Columns[3].Header = "Number of experts";
                dgTables.Columns[4].Visibility = Visibility.Hidden;
            }
            else if (typeof(T) == typeof(Workplace))
            {
                dgTables.Columns[0].Visibility = Visibility.Hidden;
                dgTables.Columns[1].Header = "Workplace name";
                dgTables.Columns[2].Visibility = Visibility.Hidden;
            }
            else if (typeof(T) == typeof(WorkplaceForEvent))
            {
                dgTables.Columns[0].Header = "Quantity per place";
                dgTables.Columns[1].Visibility = Visibility.Hidden;
                dgTables.Columns[2].Header = "Events";
                dgTables.Columns[3].Visibility = Visibility.Hidden;
                dgTables.Columns[4].Header = "Workplace";
                dgTables.Columns[5].Visibility = Visibility.Hidden;
                dgTables.Columns[6].Header = "Equipment";
            }
        }
    }
}
