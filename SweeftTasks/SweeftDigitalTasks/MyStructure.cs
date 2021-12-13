using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigitalTasks
{
    public class MyStructure<TKey,TValue>
    {
        private Dictionary<TKey, TValue> Container { get; set; }

        public bool Delete(TKey key)
        {
            return Container.Remove(key);
        }

        public bool Add(TKey key, TValue value)
        {
            if (Container.ContainsKey(key))
            {
                return false;
            }
            Container.Add(key, value);
            return true;
        }

        public TValue[] Values => Container.Values.ToArray();


        public MyStructure()
        {
            Container = new Dictionary<TKey, TValue>();
        }
    }
}
