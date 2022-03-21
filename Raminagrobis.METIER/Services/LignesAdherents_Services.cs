using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.DTO.DTO;
using Raminagrobis.METIER.Metier;

namespace Raminagrobis.METIER.Services
{
    public class LignesLignesAdherentss_Services
    {
        #region GetAll
        public List<LignesAdherents_METIER> GetAll()
        {
            var result = new List<LignesAdherents_METIER>();
            var depot = new LignesAdherentsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new LignesAdherents_METIER(item.ID_produit,item.ID_commande ,item.ID_ligne_global, item.Quantite));
            }
            return result;
        }
        #endregion

        #region GetByID
        public LignesAdherents_METIER GetByID(int id)
        {
            var depot = new LignesAdherentsDepot_DAL();
            var LignesAdherents = depot.GetByID(id);
            return new LignesAdherents_METIER(LignesAdherents.ID_produit, LignesAdherents.ID_commande, LignesAdherents.ID_ligne_global, LignesAdherents.Quantite);
        }
        #endregion

        #region Insert
        public void Insert(LignesAdherents_DTO input)
        {
            var LignesAdherents = new LignesAdherents_DAL(input.ID_produit, input.ID_commande, input.ID_ligne_global, input.Quantite);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Insert(LignesAdherents);
        }
        #endregion

        #region Update
        public void Update(int id, LignesAdherents_DTO input)
        {
            var LignesAdherents = new LignesAdherents_DAL(input.ID_produit, input.ID_commande, input.ID_ligne_global, input.Quantite);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Update(LignesAdherents);
        }
        #endregion

    }
}
