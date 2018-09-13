using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
	public class cloud_agentequipment : BaseModel
	{
	  #region 获取/设置 字段值
		public cloud_agentequipment(){}
	
      			
		  		 
		       /// <summary>
		       /// Id
               /// </summary>
               /// <returns></returns>
                public string Id { get; set; }
								
		  		 
		       /// <summary>
		       /// EquipmentId
               /// </summary>
               /// <returns></returns>
                public string EquipmentId { get; set; }
								
		  		 
		       /// <summary>
		       /// AgentId
               /// </summary>
               /// <returns></returns>
                public string AgentId { get; set; }
								
		  		 
		       /// <summary>
		       /// State
               /// </summary>
               /// <returns></returns>
                public int? State { get; set; }
        				    	 
    	  #endregion

    	 
    	 
       
	}
}