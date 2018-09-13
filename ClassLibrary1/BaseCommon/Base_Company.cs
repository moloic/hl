using System;
using System.ComponentModel;
using System.Text;

namespace Hl.dotNet.Models
{
    /// <summary>
    /// 公司管理
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.06 10:59</date>
    /// </author>
    /// </summary>
    [Description("公司管理")]
    [Serializable]
    public class Base_Company 
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 公司主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司主键")]
        public string CompanyId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("父级主键")]
        public string ParentId { get; set; }
        /// <summary>
        /// 公司分类
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司分类")]
        public string Category { get; set; }
        /// <summary>
        /// 公司编码
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司编码")]
        public string Code { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司名称")]
        public string FullName { get; set; }
        /// <summary>
        /// 公司简称
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司简称")]
        public string ShortName { get; set; }
        /// <summary>
        /// 公司性质
        /// </summary>
        /// <returns></returns>
        [DisplayName("公司性质")]
        public string Nature { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        /// <returns></returns>
        [DisplayName("法定代表人")]
        public string Manager { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        [DisplayName("联系人")]
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [DisplayName("联系电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        /// <returns></returns>
        [DisplayName("传真")]
        public string Fax { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        /// <returns></returns>
        [DisplayName("电子邮件")]
        public string Email { get; set; }
        /// <summary>
        /// 省主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("省主键")]
        public string ProvinceId { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [DisplayName("省")]
        public string Province { get; set; }
        /// <summary>
        /// 市主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("市主键")]
        public string CityId { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [DisplayName("市")]
        public string City { get; set; }
        /// <summary>
        /// 县/区主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("县/区主键")]
        public string CountyId { get; set; }
        /// <summary>
        /// 县/区
        /// </summary>
        /// <returns></returns>
        [DisplayName("县/区")]
        public string County { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        /// <returns></returns>
        [DisplayName("详细地址")]
        public string Address { get; set; }
        /// <summary>
        /// 开户信息
        /// </summary>
        /// <returns></returns>
        [DisplayName("开户信息")]
        public string AccountInfo { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        /// <returns></returns>
        [DisplayName("邮编")]
        public string Postalcode { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        /// <returns></returns>
        [DisplayName("网址")]
        public string Web { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 有效
        /// </summary>
        /// <returns></returns>
        [DisplayName("有效")]
        public int? Enabled { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [DisplayName("排序码")]
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        [DisplayName("删除标记")]
        public int? DeleteMark { get; set; }
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
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("修改时间")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("修改用户主键")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        [DisplayName("修改用户")]
        public string ModifyUserName { get; set; }
        /// <summary>
        /// 成立时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("成立时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        /// <returns></returns>
        [DisplayName("选项")]
        public string Choice { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        /// <returns></returns>
        [DisplayName("经营范围")]
        public string BusinessScope { get; set; }
        /// <summary>
        /// 经营期开始
        /// </summary>
        /// <returns></returns>
        [DisplayName("经营期开始")]
        public DateTime? Starttime { get; set; }
        /// <summary>
        /// 经营期开始
        /// </summary>
        /// <returns></returns>
        [DisplayName("经营期结束")]
        public DateTime? Endtime { get; set; }

        #endregion

        
    }
}