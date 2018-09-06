﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    /// <summary>
    /// 系统日志
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.07.22 22:43</date>
    /// </author>
    /// </summary>
    [Description("系统日志")]
    [Serializable]
    public class Base_SysLog
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 日志主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("日志主键")]
        public string SysLogId { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("对象主键")]
        public string ObjectId { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("日志类型")]
        public string LogType { get; set; }
        /// <summary>
        /// 操作IP
        /// </summary>
        /// <returns></returns>
        [DisplayName("操作IP")]
        public string IPAddress { get; set; }
        /// <summary>
        /// IP地址所在地址
        /// </summary>
        /// <returns></returns>
        [DisplayName("IP地址所在地址")]
        public string IPAddressName { get; set; }
        /// <summary>
        /// 公司主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司主键")]
        public string CompanyId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("部门主键")]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建用户主键")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建用户")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 模块主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("模块主键")]
        public string ModuleId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        [DisplayName("描述")]
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        [DisplayName("状态")]
        public string Status { get; set; }
        [DisplayName("sql语句")]
        public string SqlText { get; set; }

        #endregion


    }
}
