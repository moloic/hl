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
    public class base_menuBLL : Ibase_menuBLL
    {


        base_menuDal base_menudal = new base_menuDal();

        public IList<base_menu> getList(base_menu _model)
        {
            IList<base_menu> list = new List<base_menu>();
            try
            {
                list = base_menudal.GetList(_model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

    }
}
