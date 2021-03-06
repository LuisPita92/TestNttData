using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Interfaces
{
    public interface IMovimiento
    {
        IEnumerable<MovimientoModel> GetItems();
        IEnumerable<MovimientoModel> GetItemReporte(ReporteModel reporte);
        MovimientoModel Create(MovimientoModel cuenta);
        MovimientoModel Edit(MovimientoModel cuenta);
        MovimientoModel Delete(MovimientoModel cuenta); 
    }
}
