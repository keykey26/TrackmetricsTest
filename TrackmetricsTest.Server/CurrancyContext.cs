using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class CurrencyConversionContext : DbContext
{
    private readonly DbConnection _connection;

    public CurrencyConversionContext(DbContextOptions<CurrencyConversionContext> options) : base(options)
    {
       _connection = RelationalOptionsExtension.Extract(options).Connection!;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrencyConversion>(entity =>
        {
            entity.ToTable("CurrencyConversion");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            entity.Property(e => e.Conversion)
                    .IsRequired();

            var GBPtoUSD = new CurrencyConversion("GBP-USD", 1.2426m);
            GBPtoUSD.Id = 1;

            var GBPtoAUD = new CurrencyConversion("GBP-AUD", 1.9752m);
            GBPtoAUD.Id = 2;

            var GBPtoEUR = new CurrencyConversion("GBP-EUR", 1.2009m);
            GBPtoEUR.Id = 3;

            modelBuilder.Entity<CurrencyConversion>()
                    .HasData(GBPtoUSD, GBPtoAUD, GBPtoEUR);
        });
    }


    public override void Dispose()
    {
        _connection.Dispose();

        base.Dispose();
    }
}