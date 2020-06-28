using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using SqlSugar;

namespace WebApi.Student.CRUD.Model
{
    /// <summary>
    /// 宿舍表
    /// </summary>
    [SugarTable("student_group")]   
    public class Student_Group
    {
        [SugarColumn(IsPrimaryKey =true)]
        //宿舍id
        public long? StudentGroupId { get; set; }
        //宿舍名
        public String StudentGroupName { get; set; }
        //是否删除
        public long? IsDelete { get; set; }
    }

    /// <summary>
    /// 请求模型
    /// </summary>
    public class DeleteStudentGroupRequest
    {
        /// <summary>
        /// id
        /// </summary>
        public long? StudentGroupId { get; set; }
        public String StudentGroupName { get; set; }
        public long? IsDelete { get; set; }
    }
}
