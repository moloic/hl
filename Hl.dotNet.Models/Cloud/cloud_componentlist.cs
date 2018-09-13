using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_componentlist : BaseModel
    {
        public cloud_componentlist() { }
        public string Id { get; set; }
        public string ComponentId { get; set; }
        public string BomCode { get; set; }
        public string Name { get; set; }
        public string Marker { get; set; }
        public int? State { get; set; }
        public string Remark { get; set; }
        public string UnityModel { get; set; }
        public int? CycleDate { get; set; }
    }

}
