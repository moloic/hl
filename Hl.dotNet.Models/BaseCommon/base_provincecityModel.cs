using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
	public class base_provincecityModel
	{
	  #region 获取/设置 字段值
		public base_provincecityModel(){}
	
      			
		  		 
		       /// <summary>
		       /// ProvinceCityId
               /// </summary>
               /// <returns></returns>
                public string ProvinceCityId { get; set; }
								
		  		 
		       /// <summary>
		       /// ParentId
               /// </summary>
               /// <returns></returns>
                public string ParentId { get; set; }
								
		  		 
		       /// <summary>
		       /// Category
               /// </summary>
               /// <returns></returns>
                public string Category { get; set; }
								
		  		 
		       /// <summary>
		       /// Code
               /// </summary>
               /// <returns></returns>
                public string Code { get; set; }
								
		  		 
		       /// <summary>
		       /// FullName
               /// </summary>
               /// <returns></returns>
                public string FullName { get; set; }
								
		  		 
		       /// <summary>
		       /// Enabled
               /// </summary>
               /// <returns></returns>
                public int? Enabled { get; set; }
        						
		  		 
		       /// <summary>
		       /// SortCode
               /// </summary>
               /// <returns></returns>
                public int? SortCode { get; set; }
        						
		  		 
		       /// <summary>
		       /// DeleteMark
               /// </summary>
               /// <returns></returns>
                public int? DeleteMark { get; set; }
        						
		  		 
		       /// <summary>
		       /// CreateDate
               /// </summary>
               /// <returns></returns>
        		public DateTime? CreateDate { get; set; }
      
	    						
		  		 
		       /// <summary>
		       /// CreateUserId
               /// </summary>
               /// <returns></returns>
                public string CreateUserId { get; set; }
								
		  		 
		       /// <summary>
		       /// CreateUserName
               /// </summary>
               /// <returns></returns>
                public string CreateUserName { get; set; }
								
		  		 
		       /// <summary>
		       /// ModifyDate
               /// </summary>
               /// <returns></returns>
        		public DateTime? ModifyDate { get; set; }
      
	    						
		  		 
		       /// <summary>
		       /// ModifyUserId
               /// </summary>
               /// <returns></returns>
                public string ModifyUserId { get; set; }
								
		  		 
		       /// <summary>
		       /// ModifyUserName
               /// </summary>
               /// <returns></returns>
                public string ModifyUserName { get; set; }
						    	 
    	  #endregion

    	 
    	 
       
	}
}