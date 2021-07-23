using EFCoreMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connectMySQL.Interface
{
    public interface IIdentityService
    {
        ResponseToken Authentication(LoginModels loginModels);
    }
}
