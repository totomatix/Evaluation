using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public abstract class Navire
    {
        private int _X;
        private int _Y;
        private int _Drapeau;
        private bool _EstDetruit = false;
        

        public Navire(int x, int y, int drapeau)
        {
            Avance(x, y);
            Drapeau = drapeau;
        }

        public int X { get => _X; private set => _X = value; }
        public int Y { get => _Y; private set => _Y = value; }
        public int Drapeau { get => _Drapeau; set => _Drapeau = value; }
        public bool EstDetruit { get => _EstDetruit; set => _EstDetruit = value; }

        public const int MAX_X = 100;
        public const int MAX_Y = 100;
        public const int RAYON_RENCONTRE = 5;



        public double Distance(Navire navire)
        {
            return Math.Sqrt(Math.Pow(X - navire.X, 2) + Math.Pow(Y - navire.Y, 2));
        }

        public void Coule()
        {
            EstDetruit = true;
        }


        public void Avance(int x, int y)
        {
            // cas de X en dessous de 0
            if (X + x < 0)
            {
                X = 0;
            }
            // cas ou X serait supérieur à MAX_X
            else if (X + x > MAX_X)
            {
                X = MAX_X;
            }
            // cas où le mvt est possible
            else
            {
                X += x;
            }
            // cas de Y en dessous de 0
            if (Y + y < 0)
            {
                Y = 0;
            }
            // cas ou Y serait supérieur à MAX_Y
            else if (Y + y > MAX_Y)
            {
                Y = MAX_Y;
            }
            // cas où le mvt est possible
            else
            {
                Y += y;
            }
        }

        public virtual string Nom()
        {
            return "Bateau";
        }

        public override string? ToString()
        {
            string res = Nom() + " avec drapeau " + Drapeau + $" en ({X},{Y}) - " ;
            if (EstDetruit)
            {
                res += "Détruit";
            }
            else
            {
                res += "Intact";
            }
            return res;
        }

        public abstract void RecoitBoulet();
        protected abstract void Combat(Navire navire);

        public virtual bool EstPacifique()
        {
            return true;
        }

        public void Rencontre(Navire navire)
        {
            if (Drapeau != navire.Drapeau && this.Distance(navire) <= RAYON_RENCONTRE)
            {
                this.Combat(navire);
            }
        }

    }
}
