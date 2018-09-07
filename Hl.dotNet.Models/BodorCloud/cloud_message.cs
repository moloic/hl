using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_message : BaseModel
    {
        public cloud_message() { }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string CreateUserId { get; set; }
        public int? IsRead { get; set; }
        public string SendToUserId { get; set; }


    }

}
