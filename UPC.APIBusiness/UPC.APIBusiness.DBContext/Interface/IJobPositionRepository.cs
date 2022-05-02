using DBEntity;

namespace DBContext
{
    public interface IJobPositionRepository
    {
        ResponseBase getJobPositions();
        ResponseBase getJobPosition(string code);
        ResponseBase createJobPosition(EntityJobPosition entity);
        ResponseBase updateJobPosition(EntityJobPosition entity);
        ResponseBase deleteJobPosition(string code);
    }
}
