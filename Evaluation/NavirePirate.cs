using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public class NavirePirate : Navire
    {
        private bool _EstEndommage;

        public NavirePirate(int x, int y, int drapeau, bool estEndommage) : base(x, y, drapeau)
        {
            EstEndommage = estEndommage;
        }

        public bool EstEndommage { get => _EstEndommage; set => _EstEndommage = value; }

        public override string Nom()
        {
            return base.Nom() + " pirate";
        }

        public override string? ToString()
        {
            string res = Nom() + " avec drapeau " + Drapeau + $" en ({X},{Y}) - ";
            if (EstDetruit)
            {
                res += "Détruit";
            }
            else if (EstEndommage)
            {
                res += "Endommagé";
            }
            else
            {
                res += "Intact";
            }
            return res;
        }

        public override bool EstPacifique()
        {
            return false;
        }

        public override void RecoitBoulet()
        {
            if (EstEndommage)
            {
                Coule();
            }
            else
            {
                EstEndommage = true;
            }
        }

        protected override void Combat(Navire navire)
        {
            navire.RecoitBoulet();
            if (navire is NavirePirate)
            {
                this.RecoitBoulet();
            }
        }
    }
}
