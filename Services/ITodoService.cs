using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TView>> GetAsync<TView>();
        Task<IEnumerable<TView>> GetAsync<TView>(Expression<Func<TodoItem, TView>> selectExpression);
    }
}
