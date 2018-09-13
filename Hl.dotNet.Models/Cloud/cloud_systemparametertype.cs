using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_systemparametertype : BaseModel
    {

        public cloud_systemparametertype() { }

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
        public string DicsId { get; set; }

        /// <summary>
        /// State
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }

        public string Remark { get; set; }





    }
}
