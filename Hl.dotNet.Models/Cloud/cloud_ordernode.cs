using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
	public class cloud_ordernode : BaseModel
	{
	  #region 获取/设置 字段值
		public cloud_ordernode(){}
	
      			
		  		 
		       /// <summary>
		       /// Id
               /// </summary>
               /// <returns></returns>
                public string Id { get; set; }
								
		  		 
		       /// <summary>
		       /// OrderId
               /// </summary>
               /// <returns></returns>
                public string OrderId { get; set; }
								
		  		 
		       /// <summary>
		       /// NodeId
               /// </summary>
               /// <returns></returns>
                public string NodeId { get; set; }
								
		  		 
		       /// <summary>
		       /// CreateUser
               /// </summary>
               /// <returns></returns>
                public string CreateUser { get; set; }
								
		  		 
		       /// <summary>
		       /// CreateDate
               /// </summary>
               /// <returns></returns>
        		public DateTime? CreateDate { get; set; }
        public DateTime? CreateDate_B { get; set; }
        public DateTime? CreateDate_E { get; set; }
	    						
		  		 
		       /// <summary>
		       /// Rmark
               /// </summary>
               /// <returns></returns>
                public string Rmark { get; set; }
						    	 
    	  #endregion

    	 
    	 
       
	}
}