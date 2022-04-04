﻿using System;
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
    public class Adherents_Services
    {
        #region GetAll
        public List<Adherents_METIER> GetAll()
        {
            var result = new List<Adherents_METIER>();
            var depot = new AdherentDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Adherents_METIER(item.ID, item.Societe, item.Civilite, item.Nom, item.Prenom, item.Email, item.Date_adhesion, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Adherents_METIER GetByID(int id)
        {
            var depot = new AdherentDepot_DAL();
            var adherent = depot.GetByID(id);
            return new Adherents_METIER(adherent.ID, adherent.Societe, adherent.Civilite, adherent.Nom, adherent.Prenom, adherent.Email, adherent.Date_adhesion, adherent.Actif);
        }
        #endregion

        #region Insert
        public Adherent_DTO Insert(Adherent_DTO input)
        {
            var adherent = new Adherent_DAL(input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Date_adhesion, input.Actif);
            var depot = new AdherentDepot_DAL();
            depot.Insert(adherent);
            input.ID = adherent.ID;

            return input;
        }
        #endregion

        #region Update
        public void Update(int id, Adherent_DTO input)
        {
            var adherent = new Adherent_DAL(id, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Date_adhesion, input.Actif);
            var depot = new AdherentDepot_DAL();
            depot.Update(adherent);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Adherent_DAL adherent;
            AdherentDepot_DAL depot = new AdherentDepot_DAL();
            adherent = depot.GetByID(id);
            depot.Delete(adherent);
        }
        #endregion
    }
}
