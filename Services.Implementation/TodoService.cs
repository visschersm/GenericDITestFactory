using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TodoService : ITodoService
    {
        public Task<IEnumerable<TView>> GetAsync<TView>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TView>> GetAsync<TView>(Expression<Func<TodoItem, TView>> selectExpression)
        {
            throw new NotImplementedException();
        }
    }
}
