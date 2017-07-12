using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Hero;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardAction.Servant.NAXX
{
    public class GuiLingZhiZhuAction : IAction
    {
        public GuiLingZhiZhu _entity;
        public GuiLingZhiZhuAction(GuiLingZhiZhu entity)
        {
            _entity = entity;
        }

        public void Attack(IBiology target)
        {
            if (typeof(BaseHero).IsAssignableFrom(target.GetType()))
            {
                BaseHero hero = (BaseHero)target;
                if (hero.Ammo >= _entity.Damage)
                {
                    hero.Ammo -= _entity.Damage;
                }
                else
                {                    
                    hero.Life -= _entity.Damage - hero.Ammo;
                    hero.Ammo = 0;
                }
            }
            else
            {
                BaseServant servant = (BaseServant)target;
                servant.Life -= _entity.Damage;
            }
        }
    }
}
