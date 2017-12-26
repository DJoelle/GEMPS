using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.DAL
{
    public interface IDAL<T>
    {
        T this[int index] { get; set; }

        int Count { get; }

        string NextId { get; }

        //void StoreInFile();

        void Add(T item);

        void Clear();

        bool Contains(T item);

        int IndexOf(T item);

        bool Remove(Func<T, bool> condition);

        bool RemoveAt(int index);

        List<T> Find(Func<T, bool> condition);
    }
}
