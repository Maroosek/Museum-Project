using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    public class PracownikConfiguration: IEntityTypeConfiguration<DAO.Pracownik>
    {
        public void Configure(EntityTypeBuilder<DAO.Pracownik> builder)
        {
            builder.Property(c => c.PracownikId).IsRequired();
            builder.Property(c => c.ImieP).IsRequired();
            builder.Property(c => c.NazwiskoP).IsRequired();
            builder.Property(c => c.Pesel).IsRequired();
            builder.Property(c => c.DataZatrudnienia).IsRequired();
            builder.Property(c => c.DataUrodzin).IsRequired();

            builder.ToTable("Pracownik");
        }
    }

}