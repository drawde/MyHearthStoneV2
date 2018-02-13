using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Tinker_sSharpswordOil : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "修补匠的磨刀油";
        public override int Cost { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;
        public override string Describe { get; set; } = "给你的武器+3攻击力，连击：给你的随从+3攻击力。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new SpellDriver<
                    ComboDriver
                    <
                        UpgradeWeapon<MainHeroFilter,Three,Zero>,
                        DoubleActionDriver<UpgradeWeapon<MainHeroFilter,Three,Zero>,AddDamage<RandomMainServantFilter,Three>>
                    >
                >(),
            //new CA_Tinker_sSharpswordOil()
        };

        public override string BackgroudImage { get; set; } = "Classical/Tinker_sSharpswordOil.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
