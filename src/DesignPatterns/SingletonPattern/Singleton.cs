using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    // Szablon (klasa generyczna)
    public class Singleton<T>
        where T : class, new()
    {
        private readonly static object _instanceLock = new object();

        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (_instanceLock)     // Monitor.Enter(_instanceLock)            
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }                       // Monitor.Exit(_instanceLock)
            }
        }
    }
}
