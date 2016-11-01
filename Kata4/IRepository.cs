using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Kata4
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<IItem> GetMinimumDifferential();
        void AddLine(int lineCount, string line);
    }
}

    