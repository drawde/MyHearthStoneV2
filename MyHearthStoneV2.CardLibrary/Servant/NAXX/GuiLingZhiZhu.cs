using MyHearthStoneV2.SpecialEffect.Deathwhisper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.NAXX
{
    public class GuiLingZhiZhu : BaseServant, Revive
    {
        private int _damage = 1;
        private int _life = 2;
        private int _cost = 2;
        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage += value;
            }
        }

        public int Life
        {
            get
            {
                return _life;
            }

            set
            {
                _life = value;
            }
        }

        public string Name
        {
            get
            {
                return "鬼灵蜘蛛";
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost += value;
            }
        }

        public void InChessboard()
        {
        }

        public void OutChessboard()
        {

        }

        public void Spell()
        {
        }
    }
}
