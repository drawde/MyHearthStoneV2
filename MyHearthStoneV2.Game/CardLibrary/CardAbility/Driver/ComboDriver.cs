﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 连击驱动器
    /// </summary>
    /// <typeparam name="G1">无法触发连击时</typeparam>
    /// <typeparam name="G2">可以触发连击时</typeparam>
    public class ComboDriver<G1, G2, F> : BaseDriver<G1,F>, ICapture<F, NullEvent> where F : ICardLocationFilter where G1 : IGameAction where G2 : IGameAction
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            if (user.ComboSwitch)
                Activator.CreateInstance<G2>().Action(actionParameter);
            else
                Activator.CreateInstance<G1>().Action(actionParameter);
            return null;
        }

        public override bool TryCapture(Card card, IEvent @event) => false;
    }
}
