namespace Kairos.Infrastructure.Context.Mappings;
public class PerfilMapping : IEntityTypeConfiguration<PerfilEntity>
{
        public void Configure(EntityTypeBuilder<PerfilEntity> builder)
        {
            builder.ToTable("Tbl_Perfil");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("NVARCHAR");
                    
            builder.HasData(
                new PerfilEntity(1, "Administrador"),
                new PerfilEntity(2, "Organizador"),
                new PerfilEntity(3, "Membro")
            );
        }
}
