//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Reflection;
//using System.Web;
//using Hl.dotNet.Utilities;
//using Yahoo.Yui.Compressor;


//namespace Hl.dotNet.Utilities
//{
//    public class JsCssHelper
//    {
//        private static JavaScriptCompressor javaScriptCompressor = new JavaScriptCompressor();
//        private static CssCompressor cssCompressor = new CssCompressor();
//        #region Js 文件操作
//        /// <summary>
//        /// js文件下载
//        /// </summary>
//        /// <param name="filePaths">文件路径</param>
//        public static void DownJSFile(string filePaths)
//        {
//            try
//            {
//                string rootPath = Assembly.GetExecutingAssembly().CodeBase.Replace("/bin/Hl.dotNet.Utilities.DLL", "").Replace("file:///", "");

//                HttpResponse response = HttpContext.Current.Response;
//                response.ContentType = "text/javascript";
//                string[] filePathlist = filePaths.Split(',');
//                foreach (var filePath in filePathlist)
//                {
//                    string path = rootPath + filePath;
//                    if (DirFileHelper.IsExistFile(path))
//                    {
//                        string content = File.ReadAllText(path, Encoding.UTF8);
//                        if (Config.GetValue("JsCompressor") == "true")
//                        {
//                            content = javaScriptCompressor.Compress(content);
//                        }
//                        response.Write(content);

//                    }
//                }
//                response.Flush();
//                response.Clear();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        /// <summary>
//        /// 读取js文件内容并压缩
//        /// </summary>
//        /// <param name="filePathlist"></param>
//        /// <returns></returns>
//        public static string ReadJSFile(string[] filePathlist)
//        {
//            StringBuilder jsStr = new StringBuilder();
//            try
//            {
//                string rootPath = Assembly.GetExecutingAssembly().CodeBase.Replace("/bin/Learun.Util.DLL", "").Replace("file:///", "");
//                foreach (var filePath in filePathlist)
//                {
//                    string path = rootPath + filePath;
//                    if (DirFileHelper.IsExistFile(path))
//                    {
//                        string content = File.ReadAllText(path, Encoding.UTF8);
//                        if (Config.GetValue("JsCompressor") == "true")
//                        {
//                            content = javaScriptCompressor.Compress(content);
//                        }
//                        jsStr.Append(content);
//                    }
//                }
//                return jsStr.ToString();
//            }
//            catch (Exception)
//            {

//            }
//            try
//            {
//                jsStr.Clear();
//                string rootPath = Assembly.GetExecutingAssembly().CodeBase.Replace("/bin/Hl.dotNet.Utilities.DLL", "").Replace("file:///", "");
//                foreach (var filePath in filePathlist)
//                {
//                    string path = rootPath + filePath;
//                    if (DirFileHelper.IsExistFile(path))
//                    {
//                        string content = File.ReadAllText(path, Encoding.UTF8);
//                        if (Config.GetValue("JsCompressor") == "true")
//                        {
//                            content = javaScriptCompressor.Compress(content);
//                        }
//                        jsStr.Append(content);
//                    }
//                }
//                return jsStr.ToString();
//            }
//            catch (Exception)
//            {
//                return "";
//            }
//        }
//        #endregion

//        #region Css 文件操作
//        /// <summary>
//        /// css文件下载
//        /// </summary>
//        /// <param name="filePaths">文件路径</param>
//        public static void DownCssFile(string filePaths)
//        {
//            try
//            {
//                string rootPath = Assembly.GetExecutingAssembly().CodeBase.Replace("/bin/Hl.dotNet.Utilities.DLL", "").Replace("file:///", "");

//                HttpResponse response = HttpContext.Current.Response;
//                response.ContentType = "text/css";
//                string[] filePathlist = filePaths.Split(',');
//                foreach (var filePath in filePathlist)
//                {
//                    string path = rootPath + filePath;
//                    if (DirFileHelper.IsExistFile(path))
//                    {
//                        string content = File.ReadAllText(path, Encoding.UTF8);
//                        content = cssCompressor.Compress(content);
//                        response.Write(content);
//                    }
//                }
//                response.Flush();
//                response.Clear();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        /// <summary>
//        /// 读取css 文件内容并压缩
//        /// </summary>
//        /// <param name="filePathlist"></param>
//        /// <returns></returns>
//        public static string ReadCssFile(string[] filePathlist)
//        {
//            StringBuilder cssStr = new StringBuilder();
//            try
//            {
//                string rootPath = Assembly.GetExecutingAssembly().CodeBase.Replace("/bin/Hl.dotNet.Utilities.DLL", "").Replace("file:///", "");
//                foreach (var filePath in filePathlist)
//                {
//                    string path = rootPath + filePath;
//                    if (DirFileHelper.IsExistFile(path))
//                    {
//                        string content = File.ReadAllText(path, Encoding.UTF8);
//                        content = cssCompressor.Compress(content);
//                        cssStr.Append(content);
//                    }
//                }
//                return cssStr.ToString();
//            }
//            catch (Exception)
//            {
//                return cssStr.ToString();
//            }
//        }
//        #endregion
//    }
//}
