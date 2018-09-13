using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_repairorder : BaseModel
    {
        #region 获取/设置 字段值
        public cloud_repairorder() {
            Level = 0;
        }



        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// OrderNumber
        /// </summary>
        /// <returns></returns>
        public string OrderNumber { get; set; }


        /// <summary>
        /// OrderType
        /// </summary>
        /// <returns></returns>
        public string OrderType { get; set; }


        /// <summary>
        /// ProblemDescribe
        /// </summary>
        /// <returns></returns>
        public string ProblemDescribe { get; set; }


        /// <summary>
        /// EquipmentId
        /// </summary>
        /// <returns></returns>
        public string EquipmentId { get; set; }


        /// <summary>
        /// SubmitPeople
        /// </summary>
        /// <returns></returns>
        public string SubmitPeople { get; set; }


        /// <summary>
        /// SubmitTime
        /// </summary>
        /// <returns></returns>
        public DateTime? SubmitTime { get; set; }
        public DateTime? SubmitTime_B { get; set; }
        public DateTime? SubmitTime_E { get; set; }


        /// <summary>
        /// HandleUser
        /// </summary>
        /// <returns></returns>
        public string HandleUser { get; set; }


        /// <summary>
        /// State
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }


        /// <summary>
        /// HandleOpinion
        /// </summary>
        /// <returns></returns>
        public string HandleOpinion { get; set; }


        /// <summary>
        /// HandleFeedback
        /// </summary>
        /// <returns></returns>
        public string HandleFeedback { get; set; }


        /// <summary>
        /// Handledifficulty
        /// </summary>
        /// <returns></returns>
        public string Handledifficulty { get; set; }


        /// <summary>
        /// HandleEvaluate
        /// </summary>
        /// <returns></returns>
        public string HandleEvaluate { get; set; }



        public int IsEvaluate { get; set; }

        /// <summary>
        /// 订单分类
        /// </summary>
        public int? OrderClassify { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndOrderTime { get; set; }

        public int IsReceive { get; set; }


        /// <summary>
        /// 级别
        /// </summary>
        public int? Level { get; set; }

        #endregion




    }
}