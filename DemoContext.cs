using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Student.CRUD.Model
{
    public class DemoContext
    {
        public SqlSugarClient DB { get; set; }
        public DemoContext(){
            Init();
            }
        public void Init()
        {
            DB = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=rm-bp1p6h45ao4wm91940o.mysql.rds.aliyuncs.com;User Id=jusr8pkef6hp;Password=1qaz2wsx3edC;Database=sqlsugartest3;Convert Zero Datetime=True",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            }) ;
        }
    }
}
