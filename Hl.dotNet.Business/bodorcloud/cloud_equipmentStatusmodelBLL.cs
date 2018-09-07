using Hl.dotNet.CacheBase;
using Hl.dotNet.DataAccess;
using Hl.dotNet.IBusiness;
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    public class cloud_equipmentStatusmodelBLL : Icloud_equipmentStatusmodelBLL
    {

        cloud_equipmentStatusmodelDal cloud_equipmentStatusmodelDal = new cloud_equipmentStatusmodelDal();
        cloud_equipmentstatusDal statusDal = new cloud_equipmentstatusDal();
        public IList<cloud_equipmentStatusmodel> getcloud_equipmentmodelList(cloud_equipmentStatusmodel model)
        {
            IList<cloud_equipmentStatusmodel> Alllist = new List<cloud_equipmentStatusmodel>();
            IList<cloud_equipmentStatusmodel> list = new List<cloud_equipmentStatusmodel>();
            try
            {
                list = cloud_equipmentStatusmodelDal.getMyequipmentShow(model);
                if (list != null && list.Count > 0)
                {
                    foreach (cloud_equipmentStatusmodel m in list)
                    {
                        cloud_equipmentStatusmodel mt = new cloud_equipmentStatusmodel();
                        mt.EquipmentId = m.EquipmentId;
                        mt.Address = m.Address;
                        mt.Name = m.Name;
                        mt.Baidulat = m.Baidulat;
                        mt.Baidulng = m.Baidulng;
                        mt.cloud_equipmentstatusList = statusDal.getcloud_equipmentstatusList(new cloud_equipmentstatus { EquipmentId = mt.EquipmentId });
                        Alllist.Add(mt);
                    }
                }
            }
            catch
            {
                list = null;
            }
            return Alllist;
        }


    }
}
