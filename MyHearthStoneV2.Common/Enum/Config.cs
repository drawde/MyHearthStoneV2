using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.Enum
{
    /// <summary>
    /// Redis键
    /// </summary>
    public enum RedisKeyEnum
    {
        /// <summary>
        /// 游戏控制器
        /// </summary>
        GameControllers = 1,

        /// <summary>
        /// 卡牌模型对象
        /// </summary>
        CardsInstance = 2,

        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdminUserCode = 3,

        /// <summary>
        /// CSS和JS文件版本号
        /// </summary>
        CSSAndJSVersion = 4,
    }
}
