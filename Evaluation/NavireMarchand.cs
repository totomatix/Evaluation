using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public class NavireMarchand : Navire
    {
        public NavireMarchand(int x, int y, int drapeau) : base(x, y, drapeau)
        {
        }

        public override string Nom()
        {
            return base.Nom() + " marchand";
        }

        public override void RecoitBoulet()
        {
            Coule();
        }

        protected override void Combat(Navire navire)
        {
            
        }
    }
}
