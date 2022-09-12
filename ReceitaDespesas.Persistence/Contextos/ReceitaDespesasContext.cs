using Microsoft.EntityFrameworkCore;
using ReceitaDespesas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaDespesas.Persistence.Contextos
{
    public class ReceitaDespesasContext : DbContext
    {
        
        public ReceitaDespesasContext(DbContextOptions<ReceitaDespesasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //De muitos para muitos (n:n) (m:n) (n:m)
            builder.Entity<ReceitasEDespesas>()
                .HasOne(receitas => receitas.Despesas)
                .WithMany(despesas => despesas.ReceitaDespesas)
                .HasForeignKey(receitas => receitas.DespesasId);
            builder.Entity<ReceitasEDespesas>()
                .HasOne(despesas => despesas.Receita)
                .WithMany(receita => receita.ReceitasDespesas)
                .HasForeignKey(despesas => despesas.ReceitaId);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }
        public DbSet<ReceitasEDespesas> ReceitasEDespesas { get; set; }
    }
}
