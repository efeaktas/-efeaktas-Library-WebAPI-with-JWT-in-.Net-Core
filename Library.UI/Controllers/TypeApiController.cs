
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.IService;
using Library.DataAccess;
using Library.DTO.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class TypeApiController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public TypeApiController(ITypeService typeService)
        {
            this._typeService = typeService;
        }
        [HttpPost]
        [Route("CreateType")]
        public IActionResult CreateType([FromBody]CreateTypeRequest  request)
        {
            Type type = new Type();
            type.Name = request.Name;
            type.IsActive = true;
            _typeService.Add(type);
            return Ok();
        }
        [HttpPost]
        [Route("ListType")]
        public IActionResult ListType()
        {
            List<Type> types = _typeService.ListActiveOnes();
            List<ListTypeResponse> allResponses = new List<ListTypeResponse>();
            foreach (Type type in types)
            {
                ListTypeResponse response = new ListTypeResponse();
                response.Id = type.Id;
                response.Name = type.Name;
                allResponses.Add(response);
            }
            return Ok(allResponses);
        }
        [HttpPost]
        [Route("UpdateType")]
        public async Task<IActionResult> UpdateType([FromBody] UpdateTypeRequest request)
        {
            Type type = await _typeService.GetById(request.Id);
            type.Name = request.Name;
            _typeService.Update(type);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteType")]
        public async Task<IActionResult> DeleteType([FromBody] DeleteTypeRequest request)
        {
            Type type = await _typeService.GetById(request.Id);
            type.IsActive = false;
            _typeService.Update(type);
            return Ok();
        }

    }
}

