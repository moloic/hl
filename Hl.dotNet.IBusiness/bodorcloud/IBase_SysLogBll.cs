using Hl.dotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.IBusiness
{
    public interface IBase_SysLogBll
    {

        void WriteLog(string ObjectId, OperationType OperationType, string Status, string Remark = "");


    }
}
