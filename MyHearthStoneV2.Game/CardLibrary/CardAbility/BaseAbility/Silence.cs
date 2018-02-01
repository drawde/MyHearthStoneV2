using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Silence : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            if (CastCrosshairStyle == CastCrosshairStyle.单个)
            {
                DisableCardAbility(actionParameter.SecondaryCard as BaseBiology);
            }
            else if (CastCrosshairStyle == CastCrosshairStyle.范围)
            {
                var enemyPlayer = actionParameter.GameContext.GetUserContextByEnemyCard(actionParameter.MainCard);
                var currentPlayer = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
                List<BaseBiology> biologys = new List<BaseBiology>();
                if (CastStyle == CastStyle.敌方随从)
                {
                    biologys = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(enemyPlayer.IsFirst);
                }
                else if (CastStyle == CastStyle.己方随从)
                {
                    biologys = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(currentPlayer.IsFirst);
                }
                else if (CastStyle == CastStyle.随从)
                {
                    biologys.AddRange(actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(currentPlayer.IsFirst));
                    biologys.AddRange(actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(enemyPlayer.IsFirst));
                }
                foreach (var bio in biologys.Where(c => c != null && c.CardType == CardType.随从))
                {
                    DisableCardAbility(bio);
                }
            }
            return null;
        }

        private void DisableCardAbility(BaseBiology bio)
        {
            bio.Damage = bio.InitialDamage;
            bio.Cost = bio.InitialCost;
            bio.Life = bio.InitialLife;
            bio.BuffDamage = bio.InitialDamage;
            bio.BuffCost = bio.InitialCost;
            bio.BuffLife = bio.InitialLife;

            bio.Abilities.Clear();
        }
    }
}
