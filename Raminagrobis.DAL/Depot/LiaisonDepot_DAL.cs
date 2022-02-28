using Raminagrobis.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.Depot
{
    public class LiaisonDepot_DAL : Depot_DAL<Liaison_DAL>
    {
        #region GetAll
        public override List<Liaison_DAL> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetByID
        public override Liaison_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Insert
        public override Liaison_DAL Insert(Liaison_DAL liaison)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Liaison (id_produit, id_fournisseur) VALUES (@ID_produit, @ID_fournisseur); SELECT SCOPE IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_produit", liaison.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", liaison.ID_fournisseur));
            var ID_produit = Convert.ToInt32((decimal)commande.ExecuteScalar());
            var ID_fournisseur = Convert.ToInt32((decimal)commande.ExecuteScalar());
            liaison.ID_produit = ID_produit;
            liaison.ID_fournisseur = ID_fournisseur;

            DetruireConnexionEtCommande();

            return liaison;
        }
        #endregion

        #region Update
        public override Liaison_DAL Update(Liaison_DAL liaison)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public override void Delete(Liaison_DAL liaison)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}