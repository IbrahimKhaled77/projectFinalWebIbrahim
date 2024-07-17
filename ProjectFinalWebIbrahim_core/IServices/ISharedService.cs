using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface ISharedService
    {

        Task UpdateApprovment(int Id, bool value);
    }
}
