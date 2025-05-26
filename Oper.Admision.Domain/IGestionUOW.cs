using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain
{
    public interface IGestionUOW
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
        int Save();
    }
}
