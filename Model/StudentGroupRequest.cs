using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Student.CRUD.Model
{
    /// <summary>
    /// 修改宿舍
    /// </summary>
    public class UpdateStudentGroupRequest
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
    /// 修改宿舍详情
    /// </summary>
    public class UpdateStudentDetailRequest
    {
        /// <summary>
        /// 宿舍编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public long? StudentBedId { get; set; }

    }
    /// <summary>
    /// 删除宿舍人员
    /// </summary>
    public class DeleteStudentDetail
    {
        /// <summary>
        /// 宿舍编号
        /// </summary>
        public long? StudentGroupId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public long? IsDelete { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public long? StudentNo { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 床位
        /// </summary>
        public long? StudengBedId { get; set; }
    }
}
