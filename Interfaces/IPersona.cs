using ntt.data.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ntt.data.test.luis.pita.Interfaces
{
    public interface IPersona
    {
        IEnumerable<PersonaModel> GetItems();
        PersonaModel Create(PersonaModel cliente);
        PersonaModel Edit(PersonaModel cliente);
        PersonaModel Delete(PersonaModel cliente);
    }
}
