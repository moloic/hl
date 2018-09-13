using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_helpinfo : BaseModel
    {
        public cloud_helpinfo() { }
        public string Id { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }

        public string ReasonMark { get; set; }
        public string ResolventMark { get; set; }
        public int? State { get; set; }
        public string Remark { get; set; }

    }

}
