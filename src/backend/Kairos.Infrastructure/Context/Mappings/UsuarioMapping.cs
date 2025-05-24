namespace Kairos.Infrastructure.Context.Mappings;
public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
{
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
                builder.ToTable("Tbl_Usuario");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).
                        IsRequired(true).
                        HasMaxLength(50).

                        HasColumnType("VARCHAR");
                builder.Property(x => x.SobreNome).
                        IsRequired(true).
                        HasMaxLength(50).
                        HasColumnType("VARCHAR");

                builder.Property(x => x.Email).
                        IsRequired(true).
                        HasMaxLength(250).
                        HasColumnType("VARCHAR");
                
                builder.Property(x => x.PerfilID).
                        IsRequired(true);
                
                builder.Property(x => x.DataCadastro).
                        IsRequired(true);
                builder.Property(x => x.IsActive).
                        IsRequired(true);

                builder.HasOne(x => x.Perfil).WithMany(x => x.Usuarios).HasForeignKey(x => x.PerfilID).HasConstraintName("FK_Perfil_Usuario").OnDelete(DeleteBehavior.NoAction);
        }
}
