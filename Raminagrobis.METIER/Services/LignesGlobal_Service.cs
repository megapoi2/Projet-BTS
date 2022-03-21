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
    public class LignesGlobals_Services
    {
        #region GetAll
        public List<LignesGlobal_METIER> GetAll()
        {
            var result = new List<LignesGlobal_METIER>();
            var depot = new LignesGlobalDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new LignesGlobal_METIER(item.ID_panier, item.Quantite, item.ID_produit));
            }
            return result;
        }
        #endregion

        #region GetByID
        public LignesGlobal_METIER GetByID(int id)
        {
            var depot = new LignesGlobalDepot_DAL();
            var LignesGlobal = depot.GetByID(id);
            return new LignesGlobal_METIER(LignesGlobal.ID_panier, LignesGlobal.Quantite, LignesGlobal.ID_produit);
        }
        #endregion

        #region Insert
        public void Insert(LignesGlobal_DTO input)
        {
            var LignesGlobal = new LignesGlobal_DAL(input.ID_panier, input.Quantite, input.ID_produit);
            var depot = new LignesGlobalDepot_DAL();
            depot.Insert(LignesGlobal);
        }
        #endregion

        #region Update
        public void Update(int id, LignesGlobal_DTO input)
        {
            var LignesGlobal = new LignesGlobal_DAL(id, input.ID_panier, input.Quantite, input.ID_produit);
            var depot = new LignesGlobalDepot_DAL();
            depot.Update(LignesGlobal);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            LignesGlobal_DAL LignesGlobal;
            LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();
            LignesGlobal = depot.GetByID(id);
            depot.Delete(LignesGlobal);
        }
        #endregion
    }
}
