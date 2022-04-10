using Microsoft.EntityFrameworkCore;
using ntt.data.test.luis.pita.Data;
using ntt.data.test.luis.pita.Interfaces;
using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Repository
{
    public class TipoCuentaRepo : ITipoCuenta
    {
        private readonly ApplicationDbContext _context;

        public TipoCuentaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TipoCuentaModel> GetItems()
        {
            IEnumerable<TipoCuentaModel> returnTipoCuenta = _context.tbTipoCuenta.ToList();
            return returnTipoCuenta;
        }

    }
}
