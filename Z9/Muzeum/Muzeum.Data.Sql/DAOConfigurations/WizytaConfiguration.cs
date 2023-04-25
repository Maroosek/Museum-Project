using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    public class WizytaConfiguration: IEntityTypeConfiguration<Wizyta>
    {
        public void Configure(EntityTypeBuilder<Wizyta> builder)
        {
            builder.Property(c => c.OdwiedzajacyId).IsRequired();
            builder.Property(c => c.DataOdwiedzin).IsRequired();

            builder.HasOne(x => x.Gosc)
                .WithMany(x => x.Wizyty)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OdwiedzajacyId);
            builder.HasOne(x => x.Eksponat)
                .WithMany(x => x.Wizyty)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.EksponatId);

            builder.ToTable("Wizyta");
        }
    }

}