using System;
using System.Collections.Generic;
using DBEntity;

namespace DBContext
{
    public interface IServiceRepository
    {
        ResponseBase getServices();
        //ResponseBase getService(int id);
        //EntityProject getServices(int id);

        //List<EntityProject> GetServices();
    }
}
