namespace Kairos.Infrastructure.Context.Mappings;
public class EventoMapping : IEntityTypeConfiguration<EventoEntity>
{
        public void Configure(EntityTypeBuilder<EventoEntity> builder)
        {
                builder.ToTable("Tbl_Evento");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Titulo).
                        IsRequired(true).
                        HasMaxLength(100).
                        HasColumnType("VARCHAR");

                builder.Property(x => x.Descricao).
                        IsRequired(true);

                builder.Property(x => x.DataHoraInicio).
                        IsRequired(true);

                builder.Property(x => x.DataHoraFim).
                        IsRequired(true);
                
                builder.Property(x => x.Local).
                        IsRequired(true).
                        HasMaxLength(250).
                        HasColumnType("VARCHAR");
                
                builder.Property(x => x.TipoEventoID).
                        IsRequired(true);

                builder.Property(x => x.UsuarioID).
                        IsRequired(true);

                builder.Property(x => x.StatusAprovacao).
                        IsRequired(true);

                builder.Property(x => x.ImagemUrl).
                        IsRequired(true);
                
                builder.HasOne(x => x.TipoEvento).WithMany(x => x.Eventos).HasForeignKey(x => x.TipoEventoID).HasConstraintName("FK_TipoEvento_Eventos").OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(x => x.Usuario).WithMany(x => x.Eventos).HasForeignKey(x => x.UsuarioID).HasConstraintName("FK_Usuario_Eventos").OnDelete(DeleteBehavior.NoAction);
        }
}
