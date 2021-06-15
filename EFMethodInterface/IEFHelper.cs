using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFMethodInterface
{
    public interface IEFHelper
    {
        IEnumerable<T> Query<T>(Expression<Func<T, bool>> funwhere) where T : class;
    }
}
