using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IDisableSimpleStatusDAO : IStatusDAO<DisableSimpleStatus>
    {
        DisableSimpleStatus getDisableSimpleStatus();
    }
}
