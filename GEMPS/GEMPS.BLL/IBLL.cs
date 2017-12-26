using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BLL
{
    public interface IBLL <T, W, P>
    {
        void Add(T item);

        void Clear();

        bool Remove(W prefixe, object equalsTo);

        bool Remove(W prefixe, object[] equalsTo);

        List<T> Find(W prefixe, object equalsTo);

        List<T> Find(W prefixe, object[] equalsTo);

        void Update(T oldItem, T newItem);

        void Update(W prefixe, object equalsTo, P property, object propertyNewValue);
    }
}
