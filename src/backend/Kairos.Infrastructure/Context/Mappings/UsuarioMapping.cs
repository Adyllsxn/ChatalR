namespace Kairos.Infrastructure.Context.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Tbl_Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.SobreNome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("VARCHAR");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.FotoUrl)
                .IsRequired();

            builder.Property(x => x.PerfilID)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR");

            builder.HasIndex(x => x.Telefone)
                .IsUnique();

            builder.Property(x => x.BI)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR");

            builder.HasIndex(x => x.BI)
                .IsUnique();

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .IsRequired();

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PerfilID)
                .HasConstraintName("FK_Perfil_Usuario")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
