using MyHearthStoneV2.CardLibrary.SpecialEffect.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    public class Al_akir : BaseServant, Charge, Windfury, HolyShield, Taunt
    {
        private int _damage = 3;
        private int _life = 4;
        private int _cost = 8;
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
        private List<Type> _lstBuff;
        public List<Type> LstBuff
        {
            get
            {
                return _lstBuff;
            }

            set
            {
                _lstBuff = value;
            }
        }
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
                return Rarity.传说;
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
                return "风领主奥拉基尔";
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
            throw new NotImplementedException();
        }

        public void OutChessboard()
        {
        }
    }
}
