using Data.Enums;

namespace Data.Interface
{
    public interface IDataAccessible
    {
        public void OnDataChange(DataChangeType changeType, bool boolean, int integer);
    }
}