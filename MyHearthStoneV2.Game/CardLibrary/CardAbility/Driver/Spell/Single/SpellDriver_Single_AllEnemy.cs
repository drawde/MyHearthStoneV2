using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single
{
    internal class SpellDriver_Single_AllEnemy<T> : SpellDriver<T> where T : IGameAction
    {
        public override AbilityType AbilityType => AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;
        public override CastStyle CastStyle => CastStyle.敌方随从或英雄;
    }
}
