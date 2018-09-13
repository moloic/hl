using System;
using System.ComponentModel;
using System.Text;

namespace Hl.dotNet.Models
{
    /// <summary>
    /// ��˾����
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.06 10:59</date>
    /// </author>
    /// </summary>
    [Description("��˾����")]
    [Serializable]
    public class Base_Company 
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��˾����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾����")]
        public string CompanyId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ParentId { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾����")]
        public string Category { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾����")]
        public string Code { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾����")]
        public string FullName { get; set; }
        /// <summary>
        /// ��˾���
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾���")]
        public string ShortName { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��˾����")]
        public string Nature { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [DisplayName("����������")]
        public string Manager { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ϵ��")]
        public string Contact { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ϵ�绰")]
        public string Phone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Fax { get; set; }
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����ʼ�")]
        public string Email { get; set; }
        /// <summary>
        /// ʡ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ʡ����")]
        public string ProvinceId { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [DisplayName("ʡ")]
        public string Province { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string CityId { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��")]
        public string City { get; set; }
        /// <summary>
        /// ��/������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��/������")]
        public string CountyId { get; set; }
        /// <summary>
        /// ��/��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��/��")]
        public string County { get; set; }
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ϸ��ַ")]
        public string Address { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Ϣ")]
        public string AccountInfo { get; set; }
        /// <summary>
        /// �ʱ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ʱ�")]
        public string Postalcode { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ַ")]
        public string Web { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ע")]
        public string Remark { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ч")]
        public int? Enabled { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public int? SortCode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɾ�����")]
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����û�����")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����û�")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸�ʱ��")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸��û�����")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸��û�")]
        public string ModifyUserName { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// ѡ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѡ��")]
        public string Choice { get; set; }
        /// <summary>
        /// ��Ӫ��Χ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӫ��Χ")]
        public string BusinessScope { get; set; }
        /// <summary>
        /// ��Ӫ�ڿ�ʼ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӫ�ڿ�ʼ")]
        public DateTime? Starttime { get; set; }
        /// <summary>
        /// ��Ӫ�ڿ�ʼ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӫ�ڽ���")]
        public DateTime? Endtime { get; set; }

        #endregion

        
    }
}