using CoucheAccesDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheLogiqueMetier
{
    public class Manager
    {
        public static void AddReponses(string id, List<string> lesReponses)
        {
            Passerelle.AjouterReponses(id, lesReponses);
        }
    }
}
