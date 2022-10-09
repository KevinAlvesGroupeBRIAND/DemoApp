using DemoApp.Companies;
using DemoApp.Sites;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DemoApp.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class DemoAppDbContext : AbpDbContext<DemoAppDbContext>
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Site> Sites { get; set; }

    public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Configure your own tables/entities inside here */

        builder.Entity<Company>(b =>
        {
            b.ToTable(DemoAppConsts.DbTablePrefix + nameof(Company), DemoAppConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.Sites)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            b.Property(x => x.Code)
                .IsRequired();

            b.HasIndex(x => x.Code)
                .IsUnique();
        });

        builder.Entity<Site>(b =>
        {
            b.ToTable(DemoAppConsts.DbTablePrefix + nameof(Site), DemoAppConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.Company)
                .WithMany(x => x.Sites)
                .HasForeignKey(x => x.CompanyId);

            b.Property(x => x.Code)
                .IsRequired();

            b.HasIndex(x => x.Code)
                .IsUnique();
        });
    }
}
