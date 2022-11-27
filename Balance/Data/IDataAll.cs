using System.Collections;
using System.Windows.Documents;

namespace Balance.Data
{
    internal interface IDataAll<T>
    {
        T[] SelectAllRows();
    }
}
