﻿using System;
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
        没有访问权限 = 107,
        用户名重复 = 108,
        手机号重复 = 109,
        邮箱重复 = 110,
        无法多开游戏 = 111,
        邀请码错误 = 112,
        验证码错误 = 113,
        用户名或密码错误 = 114,
        同时只能创建或占用一个游戏房间 = 115,
        这个房间已被其他玩家占用 = 116,
        法力值不足 = 117,
        没有足够的法力值 = 118,
        位置已被占用 = 119,
        你必须先攻击有嘲讽技能的随从 = 120,
        同一张卡牌数量不能超过两张 = 121,
        同一张传说级卡牌最多只能带一张 = 122,
        只能携带本职业的牌或中立牌 = 123,
        错误的目标 = 124,
        你无法施放这个技能 = 125,
    }
}
