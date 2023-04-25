using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    public class MagazynConfiguration: IEntityTypeConfiguration<Magazyn>
    {
        public void Configure(EntityTypeBuilder<Magazyn> builder)
        {
            builder.Property(c => c.NazwaEksponatu).IsRequired();
            builder.Property(c => c.DataOtrzymania).IsRequired();
            builder.Property(c => c.EksponatId).IsRequired();

            builder.ToTable("Magazyn");
        }
    }

}