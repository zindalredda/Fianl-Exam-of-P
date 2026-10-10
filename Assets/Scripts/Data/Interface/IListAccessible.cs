using System.Collections.Generic;
using Data.Enums;

namespace Data.Interface
{
    public interface IListAccessible
    {
        public void OnDataChange(ListType type, List<string> list);
    }
}