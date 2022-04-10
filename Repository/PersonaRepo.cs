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
    public class PersonaRepo : IPersona
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonaModel> GetItems()
        {
            IEnumerable<PersonaModel> returnPersona = _context.tbPersona.ToList();
            return returnPersona;
        }

        public PersonaModel Create(PersonaModel persona)
        {
            _context.tbPersona.Add(persona);
            _context.SaveChanges();
            return persona;
        }

        public PersonaModel Edit(PersonaModel persona)
        {
            _context.tbPersona.Update(persona);
            _context.SaveChanges();
            return persona;
        }

        public PersonaModel Delete(PersonaModel persona)
        {
            _context.tbPersona.Remove(persona);
            _context.SaveChanges();
            return persona;
        }
    }
}
