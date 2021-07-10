using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thesis
{
    /// <summary>
    /// Defines the "Equipment" table in the DB
    /// </summary>
    public class Equipment
    {
        //Creating fields in the database
        public int EquipmentId { get; set; }
        public string NameEquip { get; set; }
        public string DescriptionEquip { get; set; }
        public int UnitEquip { get; set; }
        public string Comment { get; set; }

        //Creating a one-to-many relationship with the "WorkplaceForEvent" table
        public virtual ICollection<WorkplaceForEvent> WorkplaceForEvents { get; private set; } = new ObservableCollection<WorkplaceForEvent>();

    }
}
