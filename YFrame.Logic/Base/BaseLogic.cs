using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Logic.Base
{
    public class BaseLogic<T>
    {
        protected T Data { get { return UnitySetup.Instance.Resolve<T>(); } }
    }
}
