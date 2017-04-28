using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSubSearchLib
{
    public class SubServiceFactory
    {
        private Dictionary<String, ISubService> svcMap;

        public SubServiceFactory()
        {
            svcMap = new Dictionary<string, ISubService>();
            OSDBService svc = new OSDBService();
            svcMap[svc.serviceId()] = svc;
        }

        public ISubService getService(string id)
        {
            return svcMap[id];
        }

        public List<String> getServiceIds()
        {
            return svcMap.Keys.ToList();
        }

        public ISubService getFirstService()
        {
            return svcMap.Values.ToList()[0];
        }
    }
}