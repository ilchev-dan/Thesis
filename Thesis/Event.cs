using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thesis
{
    /// <summary>
    /// Defines the "Event" table in the DB
    /// </summary>
    public class Event
    {
        //Creating fields in the database
        public int EventId { get; set; }
        public string TypeEvent { get; set; }
        public int NumberParticipants { get; set; }
        public int NumberExperts { get; set; }

        //Creating a one-to-many relationship with the "WorkplaceForEvent" table
        public virtual ICollection<WorkplaceForEvent> WorkplaceForEvents { get; private set; } = new ObservableCollection<WorkplaceForEvent>();
    }
}
