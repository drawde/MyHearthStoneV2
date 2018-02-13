using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 对一个目标造成伤害
    /// </summary>
    /// <typeparam name="TAG">目标</typeparam>
    /// <typeparam name="DMG">伤害量</typeparam>
    /// <typeparam name="QAT">伤害次数</typeparam>
    /// <typeparam name="DT">伤害类型</typeparam>
    internal class RiseDamage<TAG, DMG, QAT, DT> : BaseCardAbility where TAG : IFilter where DMG : IQuantity where QAT : IQuantity where DT : IDamageType
    {

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = GameActivator<TAG>.CreateInstance();
            DT damageType = GameActivator<DT>.CreateInstance();
            DMG dmg = GameActivator<DMG>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();

            for (int i = 0; i < qat.Quantity; i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, dmg.Quantity, secondaryCard: actionParameter.MainCard);
                    CardActionFactory.CreateAction(biology, damageType.ActionType).Action(para);
                }
            }
            return null;
        }
    }
}
