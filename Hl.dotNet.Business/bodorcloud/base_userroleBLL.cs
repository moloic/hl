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
    public class base_userroleBLL : Ibase_userroleBLL
    {

        base_userroleDal base_userroleDal = new base_userroleDal();

        public bool Insertuserinfo(base_userrole model)
        {
            return base_userroleDal.Insertuserrole(model);

        }


    }
}
