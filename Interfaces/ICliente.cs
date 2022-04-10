using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Interfaces
{
    public interface ICliente
    {
        IEnumerable<ClienteModel> GetItems();
        ClienteModel GetItem(int? id);
        ClienteModel Create(ClienteModel cliente);
        ClienteModel Edit(ClienteModel cliente);
        ClienteModel Delete(ClienteModel cliente);
    }
}
