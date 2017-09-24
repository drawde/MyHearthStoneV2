using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Model
{
    public enum InvitationStatus
    {
        无 = 0,
        已使用 = 2,
        未使用 = 1
    }

    public enum DataSourceEnum
    {
        API = 1,
        SignalR = 2,
        GameControler = 3,
        Web = 4,
        Admin = 5
    }
}
