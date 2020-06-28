using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using WebApi.Student.CRUD.Model;

namespace WebApi.Student.CRUD.Controllers
{
    [AllowAnonymous]
    public class DemoController : BaseController
    {
        private readonly DemoContext _demoContext;

        public DemoController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        /// <summary>
        /// 宿舍查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList(GetStudentGroupRequest request)
        {

            //查询宿舍
            List<Student_Group> studentGroup = _demoContext.DB.Queryable<Student_Group>().Where(it => it.IsDelete == 0).ToList();
            //var json = new
            //{
            //    code = 0,
            //    msg = "",
            //    count = studentGroup.Count,
            //    data = studentGroup
            //};
            //判断宿舍是否存在
            if (studentGroup.Count != 0)
            {
                //查询成功
                return Success(studentGroup, studentGroup.Count);
                //return Success(studentGroup);
                //return Ok(json);
            }
            //查询失败
            //return Failure(ResultCode.PARAM_IS_BANK);
            return Failure(ResultCode.PARAM_IS_BANK);
        }

        /// <summary>
        /// 查询宿舍详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStudentGroupDetail(GetStudentGroupDetailRequest request)
        {
            //宿舍编号参数校验
            if (!request.StudentGroupId.HasValue)
            {
                //宿舍编号为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            Student_Group_Detail studentGroupDetail = new Student_Group_Detail();
            studentGroupDetail.StudentGroupId = request.StudentGroupId;

            //按照宿舍id进行条件查询
            List<Student_Group_Detail> student_Group_Detail = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.StudentGroupId == studentGroupDetail.StudentGroupId && it.IsDelete == 0).ToList();
            //判断是否查询到
            if (student_Group_Detail == null)
            {
                //没有查询到
                return Failure(ResultCode.PARAM_TYPE_BIND_ERROR);
            }


            /*return "";*///aop
            //var json = new
            //{
            //    code = 0,
            //    msg = "",
            //    count=student_Group_Detail.Count,
            //    data = student_Group_Detail

            //};
            //查询成功
            return Success(student_Group_Detail, student_Group_Detail.Count);

        }

        /// <summary>
        /// 添加宿舍
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddStudentGroup(AddStudentGroupRequest request)
        {
            //宿舍id参数校验
            if (!request.StudentGroupId.HasValue)
            {
                //宿舍编号为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            //宿舍名参数校验
            if (string.IsNullOrEmpty(request.StudentGroupName))
            {
                //宿舍名为空
                return Failure(ResultCode.PARAM_NOT_COMPLETE);
            }

            //判断宿舍id是否重复
            var studentgroup = _demoContext.DB.Queryable<Student_Group>().InSingle(request.StudentGroupId.Value);
            if (studentgroup != null)
            {
                //宿舍编号重复
                return Failure(ResultCode.PARAM_NO_COMPLETE);
            }

            //判断宿舍名是否重复
            var studentGroupName = _demoContext.DB.Queryable<Student_Group>().InSingle(request.StudentGroupName);
            if (studentGroupName != null)
            {
                //宿舍名重复
                return Failure(ResultCode.PARAM_NAME_COMPLETE);
            }

            Student_Group studentGroup = new Student_Group();
            studentGroup.StudentGroupId = request.StudentGroupId.Value;
            studentGroup.StudentGroupName = request.StudentGroupName;
            studentGroup.IsDelete = 0;

            int count = _demoContext.DB.Insertable(studentGroup).ExecuteReturnIdentity();

            //添加宿舍
            return count > 0 ? Success() : Failure(ResultCode.SYSTEM_INNER_ERROR);
        }
        /// <summary>
        /// 添加宿舍详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddStudent(AddStudentGroupDetailRequest request)
        {

            //宿舍id参数校验
            if (!request.StudentGroupId.HasValue)
            {
                //宿舍编号为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            //学生姓名参数校验
            if (request.StudentName == "")
            {
                //学生姓名为空
                return Failure(ResultCode.PARAM_STUDENTNAME_BANK);
            }
            //学号参数校验
            if (!request.StudentNo.HasValue)
            {
                //学号为空
                return Failure(ResultCode.PARAM_STUDENTNO_BANK);
            }

            Student_Group_Detail studentGroupDetail = new Student_Group_Detail();
            studentGroupDetail.StudentBedId = request.StudentBedId;
            studentGroupDetail.StudentGroupId = request.StudentGroupId;
            studentGroupDetail.StudentNo = request.StudentNo;
            studentGroupDetail.StudentName = request.StudentName;



            //判断学号
            var studentNo = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.StudentGroupId == studentGroupDetail.StudentGroupId && it.StudentNo == studentGroupDetail.StudentNo).ToList();
            if (!studentGroupDetail.StudentNo.HasValue)
            {
                //该学号学生已在宿舍
                return Failure(ResultCode.PARAM_STUDENT_NOBANK);
            }
            //床号参数校验
            if (!studentGroupDetail.StudentBedId.HasValue)
            {
                //床号不可以为空
                return Failure(ResultCode.PARAM_STUDENTBED_BANK);
            }
            //判断床号是否重复
            var command = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.StudentGroupId == studentGroupDetail.StudentGroupId && it.StudentBedId == studentGroupDetail.StudentBedId).ToList();
            if (command.Count == 0)
            {
                //isDelete：0(未删除)isDelete:1(已删除)
                studentGroupDetail.IsDelete = 0;
                //添加宿舍人员
                bool addDormitoryDetail = _demoContext.DB.Insertable(studentGroupDetail).ExecuteCommandIdentityIntoEntity();
                //判断是否添加进入
                if (addDormitoryDetail == true)
                {
                    //添加成功
                    return Success();
                }
                //添加失败
                return Failure(ResultCode.SYSTEM_INNER_ERROR);

            }
            //宿舍已存在，无法添加
            return Failure(ResultCode.SYSTEM_INNER_ERROR);


        }

        /// <summary>
        /// 修改宿舍
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateStuGroup(UpdateStudentGroupRequest request)
        {
            //宿舍id参数校验
            if (!request.StudentGroupId.HasValue)
            {
                //宿舍编号为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            //宿舍名参数校验
            if (request.StudentGroupName == "")
            {
                //宿舍名为空
                return Failure(ResultCode.PARAM_NOT_COMPLETE);
            }
            Student_Group studentGroup = new Student_Group();
            studentGroup.StudentGroupId = request.StudentGroupId;
            studentGroup.StudentGroupName = request.StudentGroupName;

            //查询宿舍名
            var studentgroupName = _demoContext.DB.Queryable<Student_Group>().InSingle(studentGroup.StudentGroupName);
            //判断是否可以查询到
            if (studentgroupName == null)
            {
                //修改宿舍
                int command = _demoContext.DB.Updateable(studentGroup).UpdateColumns(usg => new { usg.StudentGroupName }).ExecuteCommand();
                //判断更新语句是否执行完成
                if (command == 1)
                {
                    //修改成功
                    return Success();
                }
                else
                {
                    //修改失败
                    return Failure(ResultCode.SYSTEM_INNER_ERROR);
                }
            }
            //宿舍名重复
            return Failure(ResultCode.PARAM_NAME_COMPLETE);

        }
        /// <summary>
        /// 修改宿舍人员
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateStudent(UpdateStudentDetailRequest request)
        {
            //学号参数校验

            if (!request.StudentBedId.HasValue)
            {
                //学号不可以为空
                return Failure(ResultCode.PARAM_STUDENTNO_BANK);
            }
            Student_Group_Detail studentGroupDetail = new Student_Group_Detail();
            studentGroupDetail.Id = request.Id;
            studentGroupDetail.StudentBedId = request.StudentBedId;
            //判断床位是否可以使用
            var BedIdNum = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.IsDelete == 0 && it.Id == studentGroupDetail.Id).ToList();
            if (BedIdNum == null)
            {
                //可以使用该床位
                return Success();

            }
            //修改宿舍人员
            int command = _demoContext.DB.Updateable(studentGroupDetail).UpdateColumns(it => new { it.StudentBedId }).ExecuteCommand();
            if (command == 1)
            {
                //修改成功
                return Success();
            }
            //修改失败
            return Failure(ResultCode.SYSTEM_INNER_ERROR);

        }


        /// <summary>
        /// 删除宿舍
        /// </summary>
        /// <param name="request">请求模型</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DelStudentGroup(DeleteStudentGroupRequest request)
        {


            // 参数校验
            if (!request.StudentGroupId.HasValue)
            {
                return Ok("宿舍编号必填，不可为空");
            }

            // 判断是否存在
            Student_Group studentGroup = _demoContext.DB.Queryable<Student_Group>().InSingle(request.StudentGroupId.Value);
            if (studentGroup == null)
            {
                return Ok("该宿舍不存在");
            }

            // 判断是否已删除
            if (studentGroup.IsDelete == 1)
            {
                return Ok("该宿舍已删除");
            }

            // 若宿舍中有人员则不可删除
            var number = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.StudentGroupId == request.StudentGroupId && it.IsDelete == 0).ToList();
            if (number.Count == 0)
            {
                // 0=未删除；1已删除
                studentGroup.IsDelete = 1;
                // 记录更新时间

                // 记录操作日志

                // 数据库影响行数
                int command = _demoContext.DB.Updateable<Student_Group>(studentGroup).ExecuteCommand();



                return Ok(command > 0 ? "删除成功" : "删除失败");
            }
            return Ok("不可以删除");
        }

        /// <summary>
        /// 删除宿舍人员
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteStudent(DeleteStudentDetail request)
        {
            // 宿舍编号参数校验
            if (!request.StudentGroupId.HasValue)
            {
                return Ok("宿舍编号必填，不可为空");
            }

            // 判断是否存在
            var studentGroup = _demoContext.DB.Queryable<Student_Group>().InSingle(request.StudentGroupId.Value);
            if (studentGroup == null)
            {
                return Ok("该宿舍不存在");
            }

            // 判断是否已删除
            if (studentGroup.IsDelete == 1)
            {
                return Ok("该宿舍已删除");
            }
            Student_Group_Detail studentGroupDetail = new Student_Group_Detail();
            studentGroupDetail.Id = request.Id;
            studentGroupDetail.StudentBedId = request.StudengBedId;
            studentGroupDetail.StudentGroupId = request.StudentGroupId;
            studentGroupDetail.StudentName = request.StudentName;
            studentGroupDetail.StudentNo = request.StudentNo;
            studentGroupDetail.IsDelete = request.IsDelete;
            //进行删除更新
            int command = _demoContext.DB.Updateable(studentGroupDetail).ExecuteCommand();
            if (command == 1)
            {
                return Ok("删除成功");
            }
            return Ok("删除失败");
        }

        /// <summary>
        /// 搜索宿舍
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchStudentGroup(DeleteStudentGroupRequest request)
        {
            //宿舍id校验
            if (!request.StudentGroupId.HasValue)
            {
                //宿舍编号获取为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            //宿舍id条件查询
            var command = _demoContext.DB.Queryable<Student_Group>().Where(it => it.StudentGroupId == request.StudentGroupId && it.IsDelete == 0).ToList();
            //判断是否查询到
            if (command.Count == 0)
            {
                //宿舍不存在
                return Failure(ResultCode.RESULT_DATA_NOT);
            }
            //var json = new
            //{
            //    code = 0,
            //    msg = "",
            //    count = command.Count,
            //    data = command
            //};
            return Success(command, command.Count);

        }
        /// <summary>
        /// 搜索学生
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult searchStudentSelect(GetStudentGroupDetailRequest request)
        {
            //宿舍id参数校验
            if (request.StudentGroupId.HasValue)
            {
                //宿舍编号获取为空
                return Failure(ResultCode.PARAM_IS_INVALLD);
            }
            Student_Group_Detail studentGroupDetail = new Student_Group_Detail();
            studentGroupDetail.StudentGroupId = request.StudentGroupId;
            studentGroupDetail.StudentNo = request.StudentNo;
            studentGroupDetail.IsDelete = request.IsDelete;

            //按照宿舍id进行条件查询
            var command = _demoContext.DB.Queryable<Student_Group_Detail>().Where(it => it.StudentNo == studentGroupDetail.StudentNo && it.IsDelete == 0).ToList();
            //判断是否查询到
            if (command.Count == 0)
            {
                //宿舍不存在
                return Failure(ResultCode.RESULT_DATA_NOT);
            }
            //var json = new
            //{
            //    code = 0,
            //    msg = "",
            //    count = command.Count,
            //    data = command
            //};
            return Success(command, command.Count);

        }

    }
}
