using System;
using System.Collections.Generic;
using DBEntity;

namespace DBContext
{
    public interface IEmployeeRepository
    {
        ResponseBase getEmployees();
        ResponseBase login(string email, string pw);
        //ResponseBase getService(int id);
        //EntityProject getServices(int id);

        //List<EntityProject> GetServices();
    }
}
