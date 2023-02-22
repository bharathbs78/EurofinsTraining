using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public interface INotification
    {
        void SendMessage(string msg);
    }
}
