using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DTO.DTO;
using Raminagrobis.DAL.Depot;
using Raminagrobis.METIER.Metier;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.METIER.Services
{
    public class Propositions_Services
    {
        private PropositionsDepot_DAL depot = new PropositionsDepot_DAL();

        #region GetAll
        public List<Propositions_METIER> GetAll()
        {
            var result = new List<Propositions_METIER>();
            var depot = new PropositionsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Propositions_METIER(item.ID_ligne_global, item.ID_fournisseur, item.Prix));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Propositions_METIER GetByID(int id)
        {
            var depot = new PropositionsDepot_DAL();
            var Propositions = depot.GetByID(id);
            return new Propositions_METIER(Propositions.ID_ligne_global, Propositions.ID_fournisseur, Propositions.Prix);
        }
        #endregion

        #region Insert
        public void Insert(Propositions_DTO input)
        {
            var Propositions = new Propositions_DAL(input.ID_ligne_global, input.ID_fournisseur, input.Prix);
            var depot = new PropositionsDepot_DAL();
            depot.Insert(Propositions);
        }
        #endregion

        #region Update
        public void Update(int id, Propositions_DTO input)
        {
            var Propositions = new Propositions_DAL(input.ID_ligne_global, input.ID_fournisseur, input.Prix);
            depot.Update(Propositions);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Propositions_DAL Propositions;
            PropositionsDepot_DAL depot = new PropositionsDepot_DAL();
            Propositions = depot.GetByID(id);
            depot.Delete(Propositions);
        }
        #endregion
    }
}
