namespace Kairos.Infrastructure.Context.Mappings;
public class SugestaoMapping : IEntityTypeConfiguration<SugestaoEntity>
{
        public void Configure(EntityTypeBuilder<SugestaoEntity> builder)
        {
                builder.ToTable("Tbl_Sugestao");
                builder.HasKey(x => x.Id);

                builder.Property(x => x.UsuarioID).
                        IsRequired(true);

                builder.Property(x => x.EventoID).
                        IsRequired(true);

                builder.Property(x => x.Conteudo).
                        IsRequired(true);

                builder.Property(x => x.DataEnvio).
                        IsRequired(true);

                builder.Property(x => x.StatusSugestao).
                        IsRequired(true);
                
                builder.HasOne(x => x.Evento).WithMany(x => x.Sugestoes).HasForeignKey(x => x.EventoID).HasConstraintName("FK_Evento_Sugestao").OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(x => x.Usuario).WithMany(x => x.Sugestoes).HasForeignKey(x => x.UsuarioID).HasConstraintName("FK_Usuario_Sugestao").OnDelete(DeleteBehavior.NoAction);
        }
}
