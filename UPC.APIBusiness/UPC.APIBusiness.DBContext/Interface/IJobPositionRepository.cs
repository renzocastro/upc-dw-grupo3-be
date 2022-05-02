using DBEntity;

namespace DBContext
{
    public interface IJobPositionRepository
    {
        ResponseBase getJobPositions();
        ResponseBase getJobPosition(string code);
    }
}
