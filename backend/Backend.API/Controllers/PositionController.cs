using Backend.Core.Constans;
using Backend.Core.Enums;
using Backend.Core.Modell.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace Backend.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PositionController : ControllerBase
    {

        public PositionController()
        {
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "getAllAsync")]
        [Route("api/v{version:apiVersion}/positions/all")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(List<PositionResponse>))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        public List<PositionResponse> UploadImageAsync()
        {
            return FakeDataStorage.Data.DistinctBy(x => x.Position)
                                       .Select((x) => new PositionResponse(x.Position, x.Position))
                                       .ToList();
        }
    }
}
