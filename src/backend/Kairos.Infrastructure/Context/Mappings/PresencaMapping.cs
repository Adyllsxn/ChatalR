namespace Kairos.Infrastructure.Context.Mappings;
public class PresencaMapping : IEntityTypeConfiguration<PresencaEntity>
{
        public void Configure(EntityTypeBuilder<PresencaEntity> builder)
        {
                builder.ToTable("Tbl_Presenca");
                builder.HasKey(x => x.Id);

                builder.Property(x => x.UsuarioID).
                        IsRequired(true);
                
                builder.Property(x => x.EventoID).
                        IsRequired(true);
                
                builder.Property(x => x.DataHoraCheckin).
                        IsRequired(true);

                builder.HasOne(x => x.Evento).WithMany(x => x.Presencas).HasForeignKey(x => x.EventoID).HasConstraintName("FK_Evento_Presenca").OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(x => x.Usuario).WithMany(x => x.Presencas).HasForeignKey(x => x.UsuarioID).HasConstraintName("FK_Usuario_Presenca").OnDelete(DeleteBehavior.NoAction);
        }
}
