using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.Enum
{
    public enum OperateResCodeEnum
    {
        成功 = 100,
        签名验证失败 = 101,
        缺少参数 = 102,
        内部错误 = 103,
        查询不到需要的数据 = 110,
        登录失败 = 104,
        参数错误 = 105,
        不能提交重复数据 = 106,
        没有访问权限 = 107
    }
}
