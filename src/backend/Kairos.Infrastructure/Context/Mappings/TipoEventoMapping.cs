namespace Kairos.Infrastructure.Context.Mappings;
public class TipoEventoMapping : IEntityTypeConfiguration<TipoEventoEntity>
{
        public void Configure(EntityTypeBuilder<TipoEventoEntity> builder)
        {
            builder.ToTable("Tbl_TipoEvento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("NVARCHAR");
            builder.HasData(
                new TipoEventoEntity(1, "Culto"),
                new TipoEventoEntity(2, "Vigília")
            );
        }
}
