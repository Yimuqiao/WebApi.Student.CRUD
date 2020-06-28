using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Student.CRUD.Model
{
    /// <summary>
    /// 查询宿舍
    /// </summary>
    public class GetStudentGroupRequest
    {
        /// <summary>
        /// 宿舍编号
        /// </summary>
        public long? StudentGroupId { get; set; }

        /// <summary>
        /// 宿舍名
        /// </summary>
        public string StudentGroupName { get; set; }
    }

    /// <summary>
    /// 查询宿舍详情
    /// </summary>
    public class GetStudentGroupDetailRequest
    {
        /// <summary>
        /// 宿舍编号
        /// </summary>
        [Required]
        public long? StudentGroupId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public long? StudentNo { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public long? IsDelete { get; set; }
    }
    /// <summary>
    /// 添加宿舍
    /// </summary>
    public class AddStudentGroupRequest
    {
        /// <summary>
        /// 宿舍编号
        /// </summary>
        [Required]
        public long? StudentGroupId { get; set; }

        /// <summary>
        /// 宿舍名
        /// </summary>
        [Required]
        public string StudentGroupName { get; set; }
    }
    /// <summary>
    /// 添加宿舍详情
    /// </summary>
    public class AddStudentGroupDetailRequest
    {
        /// <summary>
        /// 宿舍id
        /// </summary>
        [Required]
        public long? StudentGroupId
        {
            get;set;
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        public string StudentName { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        public long? StudentNo { get; set; }
        /// <summary>
        /// 床位号
        /// </summary>
        [Required]
        public long? StudentBedId { get; set; }


    }
}
