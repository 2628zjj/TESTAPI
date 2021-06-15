using ContextRepository;
using EFMethodInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFMethod
{
    public class EFHelper : IEFHelper
    {
        private readonly SchoolContext _context;
        public EFHelper(SchoolContext context)
        {
            _context = context;
        }


        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> funwhere) where T : class
        {
            return _context.Set<T>().Where<T>(funwhere);
        }
    }
}
