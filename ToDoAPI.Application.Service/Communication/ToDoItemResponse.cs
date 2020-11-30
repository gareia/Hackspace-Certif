using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Application.Service.Communication
{
    public class ToDoItemResponse: BaseResponse<ToDoItem>
    {
        public ToDoItemResponse(string message): base(message)
        {

        }
        public ToDoItemResponse(ToDoItem toDoItem): base(toDoItem)
        {

        }
    }
}
