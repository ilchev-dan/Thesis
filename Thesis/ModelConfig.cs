using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Thesis
{
    /// <summary>
    /// Configuration for creating the "Equipment" table
    /// </summary>
    public class EquipmentConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            //Setting the Primary Key
            builder.HasKey(key => key.EquipmentId);
        }
    }

    /// <summary>
    /// Configuration for creating the "Workplace" table
    /// </summary>
    public class WorkplaceConfig : IEntityTypeConfiguration<Workplace>
    {
        public void Configure(EntityTypeBuilder<Workplace> builder)
        {
            builder.HasKey(key => key.WorkplaceId);
        }
    }

    /// <summary>
    /// Configuration for creating the "Event" table
    /// </summary>
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(key => key.EventId);
        }
    }

    /// <summary>
    /// Configuration for creating the "WorkplaceForEvent" table
    /// </summary>
    public class WorkplaceForEventConfig : IEntityTypeConfiguration<WorkplaceForEvent>
    {
        public void Configure(EntityTypeBuilder<WorkplaceForEvent> builder)
        {
            //Setting a composite Primary Key
            builder.HasKey(key => new { key.EquipmentId, key.EventId, key.WorkplaceId});
        }
    }
}
