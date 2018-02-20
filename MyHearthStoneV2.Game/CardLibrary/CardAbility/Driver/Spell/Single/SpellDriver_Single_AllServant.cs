using MyHearthStoneV2.Game.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single
{
    internal class SpellDriver_Single_AllServant<T> : SpellDriver<T> where T : IGameAction
    {
        public override AbilityType AbilityType => AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;
        public override CastStyle CastStyle => CastStyle.随从;
    }
}
