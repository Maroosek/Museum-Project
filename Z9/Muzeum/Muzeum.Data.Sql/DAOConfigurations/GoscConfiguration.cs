using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    public class GoscConfiguration: IEntityTypeConfiguration<Gosc>
    {
        public void Configure(EntityTypeBuilder<Gosc> builder)
        {
            builder.Property(c => c.OdwiedzajacyId).IsRequired();
            builder.Property(c => c.DataOdwiedzin).IsRequired();

            builder.ToTable("Odwiedzajacy");
        }
    }
}