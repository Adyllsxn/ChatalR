namespace Kairos.Infrastructure.Context.Mappings
{
    public class BlogMapping : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.ToTable("Tbl_Blog");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioID)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Conteudo)
                .IsRequired();

            builder.Property(x => x.ImagemCapaUrl)
                .IsRequired();

            builder.Property(x => x.DataPublicacao)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioID)
                .HasConstraintName("FK_Usuario_Blog")
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasOne(x => x.Usuario).WithMany(x => x.Blogs).HasForeignKey(x => x.UsuarioID).HasConstraintName("FK_Usuario_Blog").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
