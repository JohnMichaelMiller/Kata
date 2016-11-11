using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Kata.DifferentialAbstraction
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetMinimumDifferential();
    }
}

    