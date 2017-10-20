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

    /// <summary>
    /// 短码类别
    /// </summary>
    public enum ShortCodeTypeEnum
    {
        无 = 0,
        卡牌 = 1,
        GameCode = 2,
        GameRoundCode = 3,
        TableCode = 4,
        InvitationCode = 5,
        CardGroupCode = 6,
        CardGroupPublicCode = 7,
    }
}
