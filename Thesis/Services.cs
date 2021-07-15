using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            //Определение таблицы для получиний коллекции
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
    }
}
