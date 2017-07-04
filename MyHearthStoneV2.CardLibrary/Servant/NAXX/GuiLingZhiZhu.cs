using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.SpecialEffect.Deathwhisper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.NAXX
{
    [PropertyChangedNotification]
    public class GuiLingZhiZhu : BaseServant, Revive
    {
        private int _damage = 1;
        private int _life = 2;
        private int _cost = 2;

        public string Describe
        {
            get
            {
                return "";
            }
        }

        public Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }
        private CardLocation _cardLocation = CardLocation.牌库;
        public CardLocation CardLocation
        {
            get
            {
                return _cardLocation;
            }

            set
            {
                _cardLocation = value;
            }
        }

        private int _chessboardIndex = -1;
        public int ChessboardIndex
        {
            get
            {
                return _chessboardIndex;
            }

            set
            {
                _chessboardIndex += value;
            }
        }
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



        //public void Spell()
        //{
        //    XiaoZhiZhu z1 = new XiaoZhiZhu();
        //    z1.Damage = 2;
        //    XiaoZhiZhu z2 = new XiaoZhiZhu();
        //    z2.Damage = 3;
        //}

    }
}
