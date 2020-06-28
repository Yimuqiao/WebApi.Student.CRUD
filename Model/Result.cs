using Google.Protobuf.Reflection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;


namespace WebApi.Student.CRUD.Model
{
    /// <summary>
    /// 公共返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GetStudentGroupResult<T>
    {

        // 状态码
        public int code { get; set; }

        // 消息
        public string msg { get; set; }
        //总数
        public int count { get; set; }
        //业务数据
        public object data { get; set; }        
        public T Response { get; set; }
    }
    /// <summary>
    /// 无参返回
    /// </summary>
    public class GetStudentGroupResult
    {
        // 状态码
        public int code { get; set; }

        // 消息
        public string msg { get; set; }
    }
    /// <summary>
    /// 状态码枚举
    /// </summary>
    public enum ResultCode
    {
        [Description("操作成功")]
        SUCCESS = 200,

        //参数错误:10001-19999
        [Description("宿舍编号获取为空")]
        PARAM_IS_INVALLD = 10001,
        [Description("宿舍不存在")]
        PARAM_IS_BANK = 10002,
        [Description("查询失败")]
        PARAM_TYPE_BIND_ERROR = 10003,
        [Description("宿舍名不可以为空")]
        PARAM_NOT_COMPLETE = 10004,
        [Description("宿舍编号重复")]
        PARAM_NO_COMPLETE = 10005,
        [Description("宿舍名重复")]
        PARAM_NAME_COMPLETE = 10006,
        [Description("学生名不可以为空")]
        PARAM_STUDENTNAME_BANK = 10007,
        [Description("学号不可以为空")]
        PARAM_STUDENTNO_BANK = 10008,
        [Description("该学号学生已在该宿舍")]
        PARAM_STUDENT_NOBANK = 10009,
        [Description("床号不可以为空")]
        PARAM_STUDENTBED_BANK = 10010,

        //系统错误:40001-49999
        [Description("添加失败")]
        SYSTEM_INNER_ERROR = 40001,

        //数据错误:50001-59999
        [Description("宿舍编号未找到")]
        RESULT_DATA_NOT = 50001,
        [Description("数据有误")]
        DATA_IS_WRONG = 50002,
        [Description("数据已存在")]
        DATA_ALREADY_EXISTED = 50003,

        //接口错误:60001-69999
        [Description("数据库接口调用异常")]
        INTERFACE_INNER_INVOKE_ERROR = 60001,

        [Description("用户无权限")]
        NO_AUTHORITY = 99998,
        [Description("session失效")]
        SESSION_INVALLD = 99999,


    }
    ///// <summary>
    ///// 枚举扩展类
    ///// </summary>
    //public static class EnumExtension
    //{
    //    /// <summary>
    //    /// 获取枚举类型描述
    //    /// </summary>
    //    /// <param name="en"></param>
    //    /// <returns></returns>
    //    public static string GetDescription(this Enum en)
    //    {

    //        Type type = en.GetType();
    //        FieldInfo fd = type.GetField(en.ToString());
    //        if (fd == null)

    //            return string.Empty;
    //        object[] attrs = fd.GetCustomAttributes(typeof(DescriptionAttribute), false);
    //        string name = string.Empty;
    //        foreach (DescriptionAttribute attr in attrs)
    //        {
    //            name = attr.Description;
    //        }
    //        return name;


    //    }

    //}
}
