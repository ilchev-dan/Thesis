namespace Thesis
{
    /// <summary>
    /// Defines the "WorkplaceForEvent" table in the DB
    /// </summary>
    public class WorkplaceForEvent
    {
        //Creating fields in the database
        public int CountPerPlace { get; set; }

        //Creating Foreign Keys
        public int EventId { get; set; } //Foreign Key
        public virtual Event Event { get; set; } //Navigation property

        public int WorkplaceId { get; set; }
        public virtual Workplace Workplace { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
