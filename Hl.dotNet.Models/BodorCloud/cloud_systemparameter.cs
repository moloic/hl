using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Models
{

    [Serializable]
    public class cloud_systemparameter : BaseModel
    {
        public cloud_systemparameter() { }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DicsId { get; set; }
        public string ConVal { get; set; }
        public string Conunit { get; set; }
        public string EffectiveTime { get; set; }
        public string Remark { get; set; }

        public string EquipmentType { get; set; }
        public string Type { get; set; }

        public string Equipmentfullname { get; set; }

        public string TypeName { get; set; }



    }

}
