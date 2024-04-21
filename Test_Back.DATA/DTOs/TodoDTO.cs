using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Back.DATA.DTOs
{
    public class TodoDTO
    {
        public long ToDo_FK { get; set; }
        public string? Task { get; set; }


    }
    public class UpsertTodoDTO
    {
        public string? Proc_Option { get; private set; } = "Upsert";
        public long ToDo_FK { get; set; }
        public string? Task { get; set; }


    }
}
