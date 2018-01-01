using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.CardAction
{
    public class CA_ServantAttack : BaseCardAbility
    {
        public override AbilityType AbilityType { get; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从攻击 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseBiology targetBiology = gameContext.GetCardByLocation(targetCardIndex) as BaseBiology;
            BaseServant servant = sourceCard as BaseServant;
            if (targetBiology != null)
            {
                int trueDamege = servant.Damage;
                if (targetBiology is BaseHero)
                {
                    BaseHero hero = gameContext.GetCardByLocation(targetCardIndex) as BaseHero;
                    if (trueDamege >= hero.Ammo)
                    {
                        trueDamege -= hero.Ammo;
                        hero.Ammo = 0;
                    }
                    else
                    {
                        hero.Ammo -= trueDamege;
                        trueDamege = 0;
                    }
                    hero.Life -= trueDamege;
                }
                else
                {
                    targetBiology.Life -= trueDamege;
                    //随从死亡
                    if (targetBiology.Life < 1)
                    {
                        //随从进坟场
                        targetBiology.CardLocation = CardLocation.坟场;
                    }

                    //攻击者也要受到被攻击者的伤害
                    servant.Life -= targetBiology.Damage;

                    //随从死亡
                    if (servant.Life < 1)
                    {
                        //随从进坟场
                        servant.CardLocation = CardLocation.坟场;                        
                    }
                }
            }
        }
    }
}
