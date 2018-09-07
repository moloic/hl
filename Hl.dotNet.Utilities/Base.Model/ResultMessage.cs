using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Utilities
{
    [Serializable]
    public class ResultMessage
    {
        #region 构造函数
        public ResultMessage()
        { }

        public ResultMessage(bool returnType)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnType ? "操作成功" : "操作失败";
        }

        public ResultMessage(bool returnType, string returnMsg)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
        }

        public ResultMessage(bool returnType, string returnMsg, bool SerializeTime)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.SerializeTime = SerializeTime;//是否要序列化时间到时分秒
        }

        public ResultMessage(bool returnType, string returnMsg, object returnData)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnData = returnData;
        }

        public ResultMessage(bool returnType, string returnMsg, object returnData, bool SerializeTime)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnData = returnData;
            this.SerializeTime = SerializeTime;//是否要序列化时间到时分秒
        }

        public ResultMessage(bool returnType, string returnMsg, int returnCount)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnCount = returnCount;
        }

        public ResultMessage(bool returnType, string returnMsg, int returnCount, object returnData)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnCount = returnCount;
            this.ReturnData = returnData;
        }

        public ResultMessage(bool returnType, string returnMsg, int returnCount, object returnData  , bool SerializeTime)
        {
            this.ReturnType = returnType;
            this.ReturnMsg = returnMsg;
            this.ReturnCount = returnCount;
            this.ReturnData = returnData;
            this.SerializeTime = SerializeTime;
        }
        #endregion

        /// <summary>
        /// 返回是否成功的类型
        /// </summary>
        public bool ReturnType { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object ReturnData { get; set; }

        /// <summary>
        /// 返回的数据记录总数
        /// </summary>
        public int ReturnCount { get; set; }

        /// <summary>
        /// 序列化到时分秒
        /// </summary>
        public bool SerializeTime { get; set; }


        /***********************layUI返回信息用法*********************************/


      
        /// <summary>
        /// 序列化消息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonHelper.ToJson(this);
        }

    }
}
