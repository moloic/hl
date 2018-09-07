using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_systemparameterlog : BaseModel
    {

        public cloud_systemparameterlog() { }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }
        /// <summary>
        /// cloud_systemparameterId
        /// </summary>
        /// <returns></returns>
        public string cloud_systemparameterId { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// Oldvalue
        /// </summary>
        /// <returns></returns>
        public string Oldvalue { get; set; }
        /// <summary>
        /// NewValue
        /// </summary>
        public string NewValue { get; set; }

        public string RealName { get; set; }



    }
}
