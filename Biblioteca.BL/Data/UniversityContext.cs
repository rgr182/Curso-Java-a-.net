using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Biblioteca.BL.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("server")
        {

        }
    }
}
