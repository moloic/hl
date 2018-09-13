using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_equipmentmodel : BaseModel
    {
        public cloud_equipmentmodel() { }
        public string Id { get; set; }
        public string DicsId { get; set; }
        public string FileId { get; set; }

        public string Url { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }


    }

}
