using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAuction.ViewModel
{
    public class MyMediator
    {
        static readonly MyMediator instance = new MyMediator();

        public static MyMediator Instance
        {
            get
            {
                return instance;
            }
        }

        private MyMediator()
        {

        }

        private static Dictionary<string, Action<object>> subscribers = new Dictionary<string, Action<object>>();

        public void Register(string message, Action<object> action)
        {
            subscribers.Add(message, action);
        }

        public void Notify(string message, Object param)
        {
            foreach (var item in subscribers)
            {
                if (item.Key.Equals(message))
                {
                    Action<object> method = (Action<object>)item.Value;
                    method.Invoke(param);
                }
            }
        }

    }
}
