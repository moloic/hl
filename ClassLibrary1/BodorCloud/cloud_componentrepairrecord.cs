using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_componentrepairrecord : BaseModel
    {

        public cloud_componentrepairrecord() { }
        public string Id { get; set; }
        public string Cloud_componentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Lev { get; set; }
        public string UpdateUserId { get; set; }
        public string Remark { get; set; }
        public string ComponentName { get; set; }
        public string EquipmentId { get; set; }


    }
}
