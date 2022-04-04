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
    public class Propositions_Controller : ControllerBase
    {
        private Propositions_Services service;

        public Propositions_Controller(Propositions_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Propositions_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Propositions_DTO()
            {
                ID_fournisseur = item.ID_fournisseur,
                ID_ligne_global = item.ID_ligne_global,
                Prix = item.Prix,
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public Propositions_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new Propositions_DTO()
            {
                ID_fournisseur = item.ID_fournisseur,
                ID_ligne_global = item.ID_ligne_global,
                Prix = item.Prix,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public Propositions_DTO Insert([FromBody] Propositions_DTO item)
        {
            service.Insert(item);
            return item;
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update (int id, [FromBody] Propositions_DTO item)
        {
            service.Update(id, item);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public void Delete( int id)
        {
            service.Delete(id);
        }
        #endregion
    }
}
