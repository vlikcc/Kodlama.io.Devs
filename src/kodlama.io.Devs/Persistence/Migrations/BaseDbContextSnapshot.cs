using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", p =>
            {
                p.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("Id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(p.Property<int>("Id"), 1L, 1);

                p.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("Name");

                p.HasKey("Id");

                p.ToTable("Languages", (string)null);

                p.HasData(
                    new
                    {
                        Id = 1,
                        Name = "C#"
                    },
                    new
                    {
                        Id = 2,
                        Name = "Java"
                    });
            });
#pragma warning restore 612, 618
        }
    }
}
