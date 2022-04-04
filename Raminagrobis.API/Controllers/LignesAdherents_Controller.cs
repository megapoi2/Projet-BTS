using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Raminagrobis.METIER.Services;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LignesAdherents_Controller : ControllerBase
    {
        private LignesAdherents_Services service;

        public LignesAdherents_Controller(LignesAdherents_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<LignesAdherents_DTO> GetAll()
        {
            return service.GetAll().Select(item => new LignesAdherents_DTO()
            {
                ID_produit = item.ID_produit,
                ID_commande = item.ID_commande,
                ID_ligne_global= item.ID_ligne_global,
                Quantite = item.Quantite,
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public LignesAdherents_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new LignesAdherents_DTO()
            {
                ID_produit = item.ID_produit,
                ID_commande = item.ID_commande,
                ID_ligne_global = item.ID_ligne_global,
                Quantite = item.Quantite,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public LignesAdherents_DTO Insert([FromBody] LignesAdherents_DTO item)
        {
            service.Insert(item);
            return item;
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] LignesAdherents_DTO item)
        {
            service.Update(id, item);
        }
        #endregion
    }
}
