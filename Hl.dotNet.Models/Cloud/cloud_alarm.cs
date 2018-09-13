using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_alarm : BaseModel
    {

        public cloud_alarm() { }
        public string Id { get; set; }
        public string EquipmentId { get; set; }
        public int? Code { get; set; }
        public string CodeName { get; set; }
        public string ReasonMark { get; set; }
        public string ResolventMark { get; set; }
        public int? IsRead { get; set; }
        public int? IsOk { get; set; }

        public string IsReadState { get; set; }
        public string IsOkState { get; set; }
        public string EquipmentName { get; set; }

    }
}
