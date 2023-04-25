using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    public class SerwisConfiguration: IEntityTypeConfiguration<Serwis>
    {
        public void Configure(EntityTypeBuilder<Serwis> builder)
        {

            builder.Property(c => c.SerwisId).IsRequired();
            builder.Property(c => c.NazwaEksponatu).IsRequired();
            builder.Property(c => c.DataOtrzymania).IsRequired();
            builder.Property(c => c.DataZwrotu).IsRequired();

            builder.HasOne(x => x.Eksponat)
                .WithMany(x => x.Serwisy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.EksponatId);
            builder.HasOne(x => x.Pracownik)
                .WithMany(x => x.Serwisy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PracownikId);

            builder.ToTable("Serwis");
        }
    }

}