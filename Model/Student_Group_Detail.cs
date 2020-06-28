using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using SqlSugar;

namespace WebApi.Student.CRUD.Model
{
    /// <summary>
    /// 宿舍详情表
    /// </summary>
    [SugarTable("student_group_detail")]
    public class Student_Group_Detail
    {
        
        [SugarColumn(IsPrimaryKey =true)]
        //序号，自增长
        public long Id { get; set; }
        //宿舍id
        public long? StudentGroupId { get; set; }
        //床位号
        public long? StudentBedId { get; set; }
        //学号
        public long? StudentNo { get; set; }
        //学生姓名
        public String StudentName { get; set; }
        //是否删除
        public long? IsDelete { get; set; }

    }
    public class DeleteStudentGroupDetailRequest
    {
        public long? StudentGroupId { get; set; }
        public long? StudentBedId { get; set; }
        public long? StudentNo { get; set; }
        public String StudentName { get; set; }
        
    }
}
