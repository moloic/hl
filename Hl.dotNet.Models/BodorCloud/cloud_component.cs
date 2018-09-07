using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_component : BaseModel
    {

        public cloud_component() { }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }


        /// <summary>
        /// State
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }

         public string Remark { get; set; }

         public string StateName { get; set; }
   



    }
}
