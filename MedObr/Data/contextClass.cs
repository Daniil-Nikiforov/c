using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedObr.Data
{
    public partial class bdEntities
    {
        private static bdEntities _context;
        public static bdEntities GetContext()
        {
            if(_context == null)
                _context = new bdEntities();
            return _context;
        }
    }
}
