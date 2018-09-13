using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface Ibase_menuBLL
    {

        IList<base_menu> getList(base_menu _model);

    }
}
