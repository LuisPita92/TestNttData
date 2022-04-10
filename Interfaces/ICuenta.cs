using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Interfaces
{
    public interface ICuenta
    {
        IEnumerable<CuentaModel> GetItems(int? tipoCuentaId = 0);
        CuentaModel GetItem(int? id);
        CuentaModel Create(CuentaModel cuenta);
        CuentaModel Edit(CuentaModel cuenta);
        CuentaModel Delete(CuentaModel cuenta); 
    }
}
