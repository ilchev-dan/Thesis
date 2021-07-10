using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thesis
{
    /// <summary>
    /// Defines the "Workplace" table in the DB
    /// </summary>
    public class Workplace
    {
        //Creating fields in the database
        public int WorkplaceId { get; set; }
        public string NameWorkplace { get; set; }

        //Creating a one-to-many relationship with the "WorkplaceForEvent" table
        public virtual ICollection<WorkplaceForEvent> WorkplaceForEvents { get; private set; } = new ObservableCollection<WorkplaceForEvent>();
    }
}
