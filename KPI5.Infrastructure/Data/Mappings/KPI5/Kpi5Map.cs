using Microsoft.EntityFrameworkCore;
using KPI5.Domain.Entities.KPI5;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KPI5.Infrastructure.Data.Mappings.KPI5;

public class Kpi5Map : IEntityTypeConfiguration<Kpi5Entity>
{
    public void Configure(EntityTypeBuilder<Kpi5Entity> builder)
    {
        // Tabel
        builder.ToTable("KpisDB");

        // PK
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id);
        
        // Properties
        builder.Property(x => x.Circle)
            .HasColumnName("Circle")
            .HasColumnType("VARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Kpi)
            .HasColumnName("Kpi")
            .HasColumnType("VARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Periodicity)
            .HasColumnName("Periodicity")
            .HasColumnType("VARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Range)
            .HasColumnName("Range")
            .HasColumnType("VARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.PeriodYear)
            .HasColumnName("PeriodYear")
            .HasColumnType("INT")
            .HasMaxLength(4);
        
        builder.Property(x => x.PeriodMonth)
            .HasColumnName("PeriodMonth")
            .HasColumnType("INT")
            .HasMaxLength(2);

        builder.Property(x => x.Value)
            .HasColumnName("Value")
            .HasColumnType("DECIMAL");
    }
}