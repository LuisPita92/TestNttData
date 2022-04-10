using Microsoft.EntityFrameworkCore;
using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PersonaModel> tbPersona { get; set; }
        public DbSet<ClienteModel> tbCliente { get; set; }
        public DbSet<TipoCuentaModel> tbTipoCuenta { get; set; }
        public DbSet<CuentaModel> tbCuenta { get; set; }
        public DbSet<MovimientoModel> tbMovimiento { get; set; }
    }
}
