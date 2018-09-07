using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_equipmentstatus : BaseModel
    {
        public cloud_equipmentstatus() { }
        public string Id { get; set; }
        public string EquipmentId { get; set; }
        public int? Status { get; set; }
  
    }

}
