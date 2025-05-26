using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Core.IRepo
{
    public interface IDBANRepo
    {
        Task<object> GetDetails();
    }
}
