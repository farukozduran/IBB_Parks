using IBB_Nesine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IBBNesine.Services.Abstract
{
    public interface IParkService
    {
        List<Park> GetParksByDistrict(string district);
    }
}
