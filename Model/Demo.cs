using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;

namespace WebApi.Student.CRUD.Model
{
    [SugarTable("test1")]
    public class Demo
    {
        public String id { get; set; }
        public String Tel { get; set;}
        public String sex { get; set; }

    }
}
