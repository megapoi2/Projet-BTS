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
    public class LignesGlobal_Controller : ControllerBase
    {
        private LignesGlobals_Services service;

        public LignesGlobal_Controller(LignesGlobals_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<LignesGlobal_DTO> GetAll()
        {
            return service.GetAll().Select(item => new LignesGlobal_DTO()
            {
                ID = item.ID,
                ID_panier = item.ID_panier,
                ID_produit = item.ID_produit,
                Quantite = item.Quantite,   
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public LignesGlobal_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new LignesGlobal_DTO()
            {
                ID = item.ID,
                ID_panier = item.ID_panier,
                ID_produit = item.ID_produit,
                Quantite = item.Quantite,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public LignesGlobal_DTO Insert([FromBody] LignesGlobal_DTO item)
        {
            service.Insert(item);
            return item;
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] LignesGlobal_DTO item)
        {
            service.Update(id, item);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        #endregion
    }
}
