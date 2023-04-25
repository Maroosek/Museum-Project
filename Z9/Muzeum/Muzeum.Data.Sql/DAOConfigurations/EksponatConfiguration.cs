using Muzeum.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muzeum.Data.Sql.DAOConfigurations
{
    //Klasa konfiguracyjna encji Category
    //należy zaimplementować (generyczny) interfejs IEntityTypeConfiguration i jako parametr przekazać 
    public class EksponatConfiguration: IEntityTypeConfiguration<Eksponat>
    {
        public void Configure(EntityTypeBuilder<Eksponat> builder)
        {
            builder.Property(c => c.EksponatId).IsRequired();    
            builder.Property(c => c.NazwaEksponatu).IsRequired();

            builder.HasOne(x => x.Magazyn)
                .WithMany(x => x.Eksponaty)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.MagazynId);
            

            builder.ToTable("Eksponat");
        }
    }

}