using System;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Propositions_METIER
    {
        public int Prix { get; set; }
        public int ID_ligne_global { get; set; }
        public int ID_fournisseur { get; set; }

        public Propositions_METIER(int prix) => (Prix) = (prix);
        public Propositions_METIER(int id_ligne_global, int id_fournisseur, int prix) => (ID_ligne_global, ID_fournisseur, Prix) = (id_ligne_global,id_fournisseur,prix);

        #region Insert
        public void Insert()
        {
            Propositions_DAL propositions = new Propositions_DAL(ID_ligne_global, ID_fournisseur, Prix);

            var depotpropositions = new PropositionsDepot_DAL();

            propositions = depotpropositions.Insert(propositions);
        }
        #endregion

        #region Update
        public void Update()
        {
            Propositions_DAL propositions = new Propositions_DAL(ID_ligne_global, ID_fournisseur, Prix);

            var depotpropositions = new PropositionsDepot_DAL();

            propositions = depotpropositions.Update(propositions);
        }
        #endregion
    }
}