// <auto-generated />
using Book.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Book.API.Migrations
{
    [DbContext(typeof(BookDataContext))]
    [Migration("20221004134304_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Book.API.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("isdelete");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("Book.API.Models.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("authorid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("isdelete");

                    b.Property<int>("PrintLenght")
                        .HasColumnType("integer")
                        .HasColumnName("printlenght");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Book.API.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("isdelete");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Book.API.Models.Entities.BookEntity", b =>
                {
                    b.HasOne("Book.API.Models.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book.API.Models.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Book.API.Models.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book.API.Models.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
