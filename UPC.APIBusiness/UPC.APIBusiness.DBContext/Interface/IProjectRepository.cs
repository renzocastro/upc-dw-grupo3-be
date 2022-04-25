using System;
using System.Collections.Generic;
using DBEntity;

namespace DBContext
{
    public interface IProjectRepository
    {
        ResponseBase getProjects();
        //ResponseBase getProject(int id);
        EntityProject getProject(int id);

        List<EntityProject> GetProjects();
    }
}
