using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
	public class base_usermenuModel
	{
	  #region 获取/设置 字段值
		public base_usermenuModel(){}
	
      			
		  		 
		       /// <summary>
		       /// Id
               /// </summary>
               /// <returns></returns>
                public string Id { get; set; }
								
		  		 
		       /// <summary>
		       /// UserId
               /// </summary>
               /// <returns></returns>
                public string UserId { get; set; }
								
		  		 
		       /// <summary>
		       /// MenuId
               /// </summary>
               /// <returns></returns>
                public string MenuId { get; set; }

                /// <summary>
                /// CreateTime
                /// </summary>
                /// <returns></returns>
                public DateTime? CreateTime { get; set; }
    	  #endregion

    	 
    	 
       
	}
}