using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Spell;
using MyHearthStoneV2.CardLibrary.Servant.Neutral.Classical;


namespace MyHearthStoneV2.CardLibrary.CardAbility.Aura
{
    public class CA_VioletTeacher : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方打出法术牌前 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            //必须是自己打出的法术类牌才能触发自己的紫罗兰教师的技能
            if (gameContext.IsThisActivationUserCard(triggerCard) && gameContext.IsThisActivationUserCard(sourceCard) && triggerCard is BaseSpell)
            {
                var player = gameContext.GetActivationUserContext();
                if (player.DeskCards.Any(c => c == null))
                {
                    VioletStudent student = gameContext.CreateNewCardInDesk<VioletStudent>();
                    player.DeskCards[player.DeskCards.FindIndex(c => c == null)] = student;
                    player.AllCards.Add(student);
                    gameContext.AllCard.Add(student);
                }
            }
        }
    }
}
