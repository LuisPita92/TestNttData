using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Interfaces
{
    public interface ITipoCuenta
    {
        IEnumerable<TipoCuentaModel> GetItems();
    }
}
