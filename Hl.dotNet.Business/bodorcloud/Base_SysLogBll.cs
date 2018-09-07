using Hl.dotNet.DataAccess;
using Hl.dotNet.IBusiness;
using Hl.dotNet.Models;
using Hl.dotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    public class Base_SysLogBll : IBase_SysLogBll
    {

        #region 静态实例化
        private static Base_SysLogBll item;
        public static Base_SysLogBll Instance
        {
            get
            {
                if (item == null)
                {
                    item = new Base_SysLogBll();
                }
                return item;
            }
        }
        #endregion

        public Base_SysLog SysLog = new Base_SysLog();
        Base_SysLogDal Base_SysLogDal = new Base_SysLogDal();

        //写入日志 
        public void WriteLog(string ObjectId, OperationType OperationType, string Status, string Remark = "")
        {
            SysLog.SysLogId = CommonHelper.GetGuid;
            SysLog.ObjectId = ObjectId;
            SysLog.LogType = CommonHelper.GetString((int)OperationType);
            if (ManageProvider.Provider.IsOverdue())
            {
                SysLog.IPAddress = ManageProvider.Provider.Current().IPAddress;
                SysLog.IPAddressName = ManageProvider.Provider.Current().IPAddressName;
                SysLog.CompanyId = ManageProvider.Provider.Current().CompanyId;
                SysLog.DepartmentId = ManageProvider.Provider.Current().DepartmentId;
                SysLog.CreateUserId = ManageProvider.Provider.Current().UserId;
                SysLog.CreateUserName = ManageProvider.Provider.Current().UserName;
            }
            SysLog.ModuleId = DESEncrypt.Decrypt(CookieHelper.GetCookie("ModuleId"));
            SysLog.Remark = Remark;
            SysLog.Status = Status;
            SysLog.CreateDate = DateTime.Now;

            //异步的第一种写法
            ThreadPool.QueueUserWorkItem(new WaitCallback(WriteLogUsu), SysLog);//放入异步执行

            //异步的第二种写法
            //异步操作接口(注意BeginInvoke方法的不同！)
            //AddSystemLog handler = new AddSystemLog(WriteLogUsu);
            //IAsyncResult result = handler.BeginInvoke(SysLog, new AsyncCallback(callBackSysLog), "AsycState:OK");

            //第三种普通写法
            //WriteLogUsu(SysLog);
        }

        //回调函数
        static void callBackSysLog(IAsyncResult result)
        {

            //result 是“WriteLogUsu方法”的返回值
            //AsyncResult 是IAsyncResult接口的一个实现类，空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            AddSystemLog handler = (AddSystemLog)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);

        }
        private void WriteLogUsu(object obSysLog)
        {
            Base_SysLog VSysLog = (Base_SysLog)obSysLog;
            //保存的方法
            Base_SysLogDal.Insert(VSysLog);

        }


    }
    public delegate void AddSystemLog(object obSysLog);//声明一个委托
}
