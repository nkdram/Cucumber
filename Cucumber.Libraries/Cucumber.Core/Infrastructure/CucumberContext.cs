using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cucumber.Core.Infrastructure
{
    /// <summary>
    /// App Context
    /// </summary>
    public class CucumberContext
    {
        #region Methods

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ICucumberAppEngine Initialize()
        {
            if (Singleton<ICucumberAppEngine>.Instance == null)
            {
                Singleton<ICucumberAppEngine>.Instance = new CucumberAppEngine();
                Singleton<ICucumberAppEngine>.Instance.Initialize();
            }

            return Singleton<ICucumberAppEngine>.Instance;
        }

        #endregion

        #region Properties

        public static ICucumberAppEngine Current
        {
            get
            {
                if (Singleton<ICucumberAppEngine>.Instance == null)
                {
                    Initialize();
                }

                return Singleton<ICucumberAppEngine>.Instance;
            }
        }

        #endregion
    }
}
