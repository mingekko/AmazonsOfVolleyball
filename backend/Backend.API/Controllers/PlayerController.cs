using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Backend.Core.Constans;
using Backend.Core.Enums;
using Backend.Core.Modell.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Modell.Request;
using System.Linq;
using Backend.Services.Common;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    [ApiController]
    public partial class PlayerController : ControllerBase
    {
        public PlayerController()
        {
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "getAllAsync")]
        [Route("api/v{version:apiVersion}/players")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(List<Player>))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public List<Player> GetAll()
        {
            try
            {
                return FakeDataStorage.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "getPageAsync")]
        [Route("api/v{version:apiVersion}/players/page/{page}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(List<Player>))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public List<Player> Page([FromRoute][Required] int page = 0)
        {
            try
            {
                return FakeDataStorage.Data.Skip(page * 10)
                                           .Take(10)
                                           .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "getByIdAsync")]
        [Route("api/v{version:apiVersion}/player/{id}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public Player GetById([FromRoute][Required] int id)
        {
            try
            {
                return FakeDataStorage.Data.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "deleteAsync")]
        [Route("api/v{version:apiVersion}/player/delete/{id}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpDelete]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public async Task<bool> Delete([FromRoute][Required] int id)
        {
            try
            {
                await FakeDataStorage.DeletePalyer(id);
                FakeDataStorage.SaveData();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "addAsync")]
        [Route("api/v{version:apiVersion}/player/create")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpPost]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public Player CreateAsync([FromBody] [Required] PlayerRequest requestParam)
        {
            try
            {
                int id = FakeDataStorage.Data.Last().Id + 1;

                Player newData = new Player(requestParam, id);
                FakeDataStorage.AddNewPalyer(newData);
                FakeDataStorage.SaveData();

                return newData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "updateAsync")]
        [Route("api/v{version:apiVersion}/player/update")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpPut]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public async Task<Player> UpdateAsync([FromBody][Required] Player requestParam)
        {
            try
            {
                await FakeDataStorage.UpdatePalyer(requestParam);

                FakeDataStorage.SaveData();

                return requestParam;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
