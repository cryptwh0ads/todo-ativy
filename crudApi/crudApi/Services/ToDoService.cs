using System;
using System.Linq;
using System.Text;
using crudApi.Models;
using crudApi.Data;
using crudApi.Repositories;

namespace crudApi.Services
{
    public class ToDoService : Service<ToDo, CrudApiContext, ToDoRepository>
    {
        public ToDoService(
            CrudApiContext context,
            ToDoRepository baseRepository
            ) : base(context, baseRepository){}


    }
}
