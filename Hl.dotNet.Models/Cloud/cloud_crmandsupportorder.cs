using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    public class cloud_crmandsupportorder : BaseModel
    {
        public cloud_crmandsupportorder() { }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }


        /// <summary>
        /// UserId
        /// </summary>
        /// <returns></returns>
        //public string UserId { get; set; }


        /// <summary>
        /// OrderId
        /// </summary>
        /// <returns></returns>
        public string OrderId { get; set; }


        /// <summary>
        /// State
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }

        public List<string> orderidlist { get; set; }

        public DateTime? CreateDate { get; set; }

    }
}
