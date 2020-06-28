using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using SqlSugar;
using WebApi.Student.CRUD.Model;

namespace WebApi.Student.CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {

        /// <summary>
        /// 无参成功返回类型
        /// </summary>
        /// <returns></returns>
        public IActionResult Success()
        {
            GetStudentGroupResult result = new GetStudentGroupResult();
            result.code = (int)ResultCode.SUCCESS;
            result.msg = ResultCode.SUCCESS.GetDescription();
            return Ok(result);
        }

        /// <summary>
        /// 有参的成功返回类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public IActionResult Success<T>(T response)
        {

            GetStudentGroupResult<T> result = new GetStudentGroupResult<T>();
            result.code = (int)ResultCode.SUCCESS;
            result.msg = ResultCode.SUCCESS.GetDescription();
            result.data = response;
            return Ok(result);

        }
        /// <summary>
        /// 带参集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IActionResult Success<T>(T response,int count)
        {

            GetStudentGroupResult<T> result = new GetStudentGroupResult<T>();
            result.code = 0;
            result.msg = ResultCode.SUCCESS.GetDescription();
            result.count = count;
            result.data = response;
            return Ok(result);

        }
        /// <summary>
        /// 无参的失败返回类型
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public IActionResult Failure(ResultCode resultCode)
        {
            GetStudentGroupResult result = new GetStudentGroupResult();
            result.code = (int)resultCode;
            result.msg = resultCode.GetDescription();
            return Ok(result);

        }
        /// <summary>
        /// 有参的失败返回类型
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public IActionResult Failure<T>(ResultCode resultCode, T response)
        {
            GetStudentGroupResult<T> result = new GetStudentGroupResult<T>();
            result.code = (int)resultCode;
            result.msg = resultCode.GetDescription();

            result.data= response;
            return Ok(result);
        }

        public IActionResult Success<T>(T response, int pageInde, int pageSize, int totalCount)
        {
            return Ok(new { });
        }

    }



    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举类型描述
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum en)
        {

            Type type = en.GetType();
            FieldInfo fd = type.GetField(en.ToString());
            if (fd == null)

                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string name = string.Empty;
            foreach (DescriptionAttribute attr in attrs)
            {
                name = attr.Description;
            }
            return name;


        }

    }
}
