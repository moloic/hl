using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{
    /// <summary>
    /// 二维码
    /// </summary>
    public class base_qrcoder : BaseModel
    {

        public string Id { get; set; }
        public string Url { get; set; }
        public string CoderMsg { get; set; }

        public string Name { get; set; }

        public string ObjectId { get; set; }

        public string ImgeUrl { get; set; }




    }
}
