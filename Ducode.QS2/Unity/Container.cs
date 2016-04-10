using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducode.QS2.Unity
{
    public static class Container
    {
        public static IUnityContainer Current { get; private set; }

        public static void Initialize(IUnityContainer container)
        {
            if (Current == null)
            {
                Current = container;
            }
        }
    }
}
