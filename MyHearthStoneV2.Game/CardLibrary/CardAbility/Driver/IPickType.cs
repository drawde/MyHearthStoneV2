﻿namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 挑选方式
    /// </summary>
    internal interface IPickType : IGameCache
    {
        PickType PickType { get; set; }
    }
}
