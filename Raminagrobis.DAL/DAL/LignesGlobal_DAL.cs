using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.DAL
{
    public class LignesGlobal_DAL
    {
        public int ID_panier { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID_ligne_adherent { get; set; }
        public int ID { get; set; }

        public LignesGlobal_DAL(int id_panier, int quantite, int id_produit, int id_ligne_adherent) => (ID_panier, Quantite, ID_produit, ID_ligne_adherent) = (id_panier, quantite, id_produit, id_ligne_adherent);

        public LignesGlobal_DAL(int id, int id_panier, int quantite, int id_produit, int id_ligne_adherent) => (ID, ID_panier, Quantite, ID_produit, ID_ligne_adherent) = (id, id_panier, quantite, id_produit, id_ligne_adherent);
    }
}
