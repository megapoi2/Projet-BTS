using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.DAL.Depot
{
    public class LignesGlobalDepot_DAL : Depot_DAL<LignesGlobal_DAL>
    {
        #region GetAll
        public override List<LignesGlobal_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id_panier, quantite, id_produit FROM LignesGlobal";
            var reader = commande.ExecuteReader();

            var listeGlobal = new List<LignesGlobal_DAL>();

            while (reader.Read())
            {
                var lignesGlobal = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );

                listeGlobal.Add(lignesGlobal);
            }

            DetruireConnexionEtCommande();

            return listeGlobal;
        }
        #endregion

        #region GetByID
        public override LignesGlobal_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_panier, quantite, id_produit FROM LignesGlobal WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            LignesGlobal_DAL listeGlobal;

            if (reader.Read())
            {
                listeGlobal = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table LignesGlobal");
            }

            DetruireConnexionEtCommande();

            return listeGlobal;
        }
        #endregion

        #region Insert
        public override LignesGlobal_DAL Insert(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO LignesGlobal(id_panier, quantite, id_produit) VALUES (@ID_panier, @Quantite, @ID_produit); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_panier", lignesGlobal.ID_panier));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesGlobal.Quantite));
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesGlobal.ID_produit));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            lignesGlobal.ID = ID;

            DetruireConnexionEtCommande();

            return lignesGlobal;
        }
        #endregion

        #region Update
        public override LignesGlobal_DAL Update(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE LignesGlobal SET id_panier = @ID_panier, quantite = @Quantite, id_produit = @ID_produit WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID_panier", lignesGlobal.ID_panier));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesGlobal.Quantite));
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesGlobal.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID", lignesGlobal.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la LignesGlobal d'ID {lignesGlobal.ID}");
            }


            DetruireConnexionEtCommande();

            return lignesGlobal;
        }
        #endregion

        #region Delete
        public override void Delete(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM LignesGlobal WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", lignesGlobal.ID));

            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer la LignesGlobal d'ID : {lignesGlobal.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
