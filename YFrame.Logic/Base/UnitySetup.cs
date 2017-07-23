using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Logic.Base
{
    public class UnitySetup
    {
        private UnityContainer container { get; set; }

        private UnitySetup() { container = new UnityContainer(); }

        /// <summary>
        /// 延迟加载单例模式
        /// </summary>
        private static readonly Lazy<UnitySetup> unitySetup = new Lazy<UnitySetup>(() => { return new UnitySetup(); });

        public static UnitySetup Instance { get { return unitySetup.Value; } }

        public T Resolve<T>()
        {
            try
            {
                return container.Resolve<T>();
            }
            catch (ResolutionFailedException ex)
            {
                throw new ApplicationException(string.Format("不能取回{0}类型，请在 IocContainer.Instance.Container 中映射{0}类型", typeof(T)), ex);
            }
        }
    }
}
