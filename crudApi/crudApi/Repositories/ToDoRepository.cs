using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudApi.Models;
using crudApi.Common;
namespace crudApi.Repositories
{
    public class ToDoRepository : Repository<ToDo, DbContext>
    {
        public ToDoRepository(DbContext context) :  base(context)
        {
        }
    }
}
