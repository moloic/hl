using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Utilities
{
    [Serializable]
    public class LayuiDataMessage
    {
        #region 构造函数
        public LayuiDataMessage()
        { }

        public LayuiDataMessage(int code)
        {
            this.code = code;
            this.msg = code==0 ? "操作成功" : "操作失败";
        }

        public LayuiDataMessage(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public LayuiDataMessage(int code, string msg, bool SerializeTime)
        {
            this.code = code;
            this.msg = msg;
            this.SerializeTime = SerializeTime;//是否要序列化时间到时分秒
        }

        public LayuiDataMessage(int code, string msg, object data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public LayuiDataMessage(int code, string msg, object data, bool SerializeTime)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
            this.SerializeTime = SerializeTime;//是否要序列化时间到时分秒
        }

        public LayuiDataMessage(int code, string msg, int count)
        {
            this.code = code;
            this.msg = msg;
            this.count = count;
        }

        public LayuiDataMessage(int code, string msg, int count, object data)
        {
            this.code = code;
            this.msg = msg;
            this.count = count;
            this.data = data;
        }

        public LayuiDataMessage(int code, string msg, int count, object data, bool SerializeTime)
        {
            this.code = code;
            this.msg = msg;
            this.count = count;
            this.data = data;
            this.SerializeTime = SerializeTime;
        }
        #endregion

        /// <summary>
        /// 返回是否成功的类型
        /// </summary>
        public int?  code { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 返回的数据记录总数
        /// </summary>
        public int count { get; set; }

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
            return JsonHelper.ToLayuiJson(this);
        }

    }
}
