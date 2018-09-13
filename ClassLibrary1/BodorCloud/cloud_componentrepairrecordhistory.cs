using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    [Serializable]
    public class cloud_componentrepairrecordhistory : BaseModel
    {
        public cloud_componentrepairrecordhistory() { }
        public string Id { get; set; }
        public string Cloud_componentId { get; set; }
        public string EquipmentId { get; set; }
        public string ComponentName { get; set; }
        public int? CycleDate { get; set; }
        public DateTime? HistoryTime { get; set; }
        public DateTime? NextTime { get; set; }
    }
}
