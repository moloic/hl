
using Hl.dotNet.Models;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Icloud_equipmentStatusmodelBLL
    {

        IList<cloud_equipmentStatusmodel> getcloud_equipmentmodelList(cloud_equipmentStatusmodel model);
    }
}
