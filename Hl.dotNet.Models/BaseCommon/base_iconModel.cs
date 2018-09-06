using System;
using System.ComponentModel;
using System.Text;
namespace Hl.dotNet.Models
{
    [Serializable]
	public class base_iconModel
	{
	  #region 获取/设置 字段值
		public base_iconModel(){}
	
      			
		  		 
		       /// <summary>
		       /// Id
               /// </summary>
               /// <returns></returns>
                public string Id { get; set; }
								
		  		 
		       /// <summary>
		       /// FileName
               /// </summary>
               /// <returns></returns>
                public string FileName { get; set; }
								
		  		 
		       /// <summary>
		       /// OldFileName
               /// </summary>
               /// <returns></returns>
                public string OldFileName { get; set; }
								
		  		 
		       /// <summary>
		       /// FileType
               /// </summary>
               /// <returns></returns>
                public string FileType { get; set; }

                public DateTime CreateTime { get; set; }		
		  		 
		       /// <summary>
		       /// Url
               /// </summary>
               /// <returns></returns>
                public string Url { get; set; }
						    	 
    	  #endregion

    	 
    	 
       
	}
}