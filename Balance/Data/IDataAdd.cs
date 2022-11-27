using System.Collections.Generic;

namespace Balance.Data
{
    internal interface IDataAdd
    {
        void Add();
        void AddRange(List<object> range);
    }
}
