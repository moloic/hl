using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_componetmessage : BaseModel
    {

        public cloud_componetmessage() { }
        public string Id { get; set; }
        public string ComponentId { get; set; }
        public string SendUserId { get; set; }
        public int? IsRead { get; set; }
        public string AddresseeUserId { get; set; }

        public string EquipmentId { get; set; }
        public string Remark { get; set; }
        public string ComponentName { get; set; }




    }
}
