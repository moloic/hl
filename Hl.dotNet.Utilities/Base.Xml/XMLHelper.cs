//=====================================================================================
// All Rights Reserved , Copyright © Learun 2013
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Xml;


namespace Hl.dotNet.Utilities
{
    public class XMLHelper
    {
        #region 对象转换
        /// <summary>
        /// Hashtable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static Hashtable XMLToHashtable(string xmlData)
        {
            DataTable dt = XMLToDataTable(xmlData);
            return DataHelper.DataTableToHashtable(dt);
        }
        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataTable XMLToDataTable(string xmlData)
        {
            if (!String.IsNullOrEmpty(xmlData))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(new System.IO.StringReader(xmlData));
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet XMLToDataSet(string xmlData)
        {
            if (!String.IsNullOrEmpty(xmlData))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(new System.IO.StringReader(xmlData));
                return ds;
            }
            return null;
        }
        #endregion

        #region 增、删、改操作
        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="filePath">XML文档绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <param name="xmlNode">XmlNode节点</param>
        /// <returns></returns>
        public static bool AppendChild(string filePath, string xPath, XmlNode xmlNode)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlNode n = doc.ImportNode(xmlNode, true);
                xn.AppendChild(n);
                doc.Save(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 从XML文档中读取节点追加到另一个XML文档中
        /// </summary>
        /// <param name="filePath">需要读取的XML文档绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <param name="toFilePath">被追加节点的XML文档绝对路径</param>
        /// <param name="toXPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static bool AppendChild(string filePath, string xPath, string toFilePath, string toXPath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(toFilePath);
                XmlNode xn = doc.SelectSingleNode(toXPath);

                XmlNodeList xnList = ReadNodes(filePath, xPath);
                if (xnList != null)
                {
                    foreach (XmlElement xe in xnList)
                    {
                        XmlNode n = doc.ImportNode(xe, true);
                        xn.AppendChild(n);
                    }
                    doc.Save(toFilePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改节点的InnerText的值
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <param name="value">节点的值</param>
        /// <returns></returns>
        public static bool UpdateNodeInnerText(string filePath, string xPath, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode xn = doc.SelectSingleNode(xPath);
                XmlElement xe = (XmlElement)xn;
                xe.InnerText = value;
                doc.Save(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取XML文档
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <returns></returns>
        public static XmlDocument LoadXmlDoc(string filePath)
        {
            try
            {
                XmlReader reader = new XmlTextReader(filePath);

                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                return doc;
            }
            catch
            {
                return null;
            }
        }
        #endregion 增、删、改操作

        #region 扩展方法
        /// <summary>
        /// 读取XML的所有子节点
        /// </summary>
        /// <param name="filePath">XML文件绝对路径</param>
        /// <param name="xPath">范例: @"Skill/First/SkillItem"</param>
        /// <returns></returns>
        public static XmlNodeList ReadNodes(string filePath, string xPath)
        {
            try
            {
                //XmlDocument doc = new XmlDocument();
                //doc.Load(filePath);
                //XmlNode xn = doc.SelectSingleNode(xPath);
                //XmlNodeList xnList = xn.ChildNodes;  //得到该节点的子节点
                //return xnList;

                string num = "";
                List<string> lis=new List<string>();
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNodeList nodeList = doc.GetElementsByTagName("formShow");
                //读取属性+元素
                foreach (XmlNode item in nodeList)
                {
                    XmlElement element = (XmlElement)item;
                    XmlNodeList nodelist = element.ChildNodes;
                    foreach (XmlElement el in nodelist)//读元素值 
                    {
                       string value= el.Attributes["key"].InnerText;
                    }
                    lis.Add(element.GetAttribute("name"));

                    lis.Add(item.Attributes["add"].Value);
                    //customerInfo.AppId = item.Attributes["AppID"].Value;
                    //customerInfo.CustomerID = item["CustomerID"].InnerText;
                }
                return nodeList;
            }
            catch
            {
                return null;
            }
        }



        #endregion 扩展方法
    }
}
