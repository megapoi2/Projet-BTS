﻿using System;
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
    public class Fournisseurs_Services
    {
        private FournisseursDepot_DAL depot = new FournisseursDepot_DAL();

        #region GetAll
        public List<Fournisseurs_METIER> GetAll()
        {
            var result = new List<Fournisseurs_METIER>();
            var depot = new FournisseursDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Fournisseurs_METIER(item.ID, item.Societe, item.Civilite, item.Nom, item.Prenom, item.Email, item.Adresse, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Fournisseurs_METIER GetByID(int id)
        {
            var depot = new FournisseursDepot_DAL();
            var fournisseurs = depot.GetByID(id);
            return new Fournisseurs_METIER(fournisseurs.ID, fournisseurs.Societe, fournisseurs.Civilite, fournisseurs.Nom, fournisseurs.Prenom, fournisseurs.Email, fournisseurs.Adresse, fournisseurs.Actif);
        }
        #endregion

        #region Insert
        public Fournisseur_DTO Insert(Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Insert(fournisseurs);
            input.ID = fournisseurs.ID;

            return input;
        }
        #endregion

        #region Update
        public void Update(int id, Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(id, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Update(fournisseurs);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Fournisseurs_DAL fournisseurs;
            FournisseursDepot_DAL depot = new FournisseursDepot_DAL();
            fournisseurs = depot.GetByID(id);
            depot.Delete(fournisseurs);
        }
        #endregion
    }
}
