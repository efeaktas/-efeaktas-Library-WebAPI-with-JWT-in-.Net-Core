using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.IService;
using Library.DataAccess;
using Library.DTO.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthorApiController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorApiController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }
        [HttpPost]
        [Route("CreateAuthor")]
        public IActionResult CreateAuthor([FromBody]CreateAuthorRequest request)
        {
            Author author = new Author();
            author.Name = request.Name;
            author.IsActive = true;
            _authorService.Add(author);
            return Ok();
        }
        [HttpPost]
        [Route("ListAuthor")]
        public IActionResult ListAuthor()
        {
            List<Author> authors = _authorService.ListActiveOnes();
            List<ListAuthorResponse> allResponses = new List<ListAuthorResponse>();
            foreach (Author author in authors)
            {
                ListAuthorResponse response = new ListAuthorResponse();
                response.Id = author.Id;
                response.Name = author.Name;
                allResponses.Add(response);
            }
            return Ok(allResponses);
        }
        [HttpPost]
        [Route("GetAuthor")]
        public async Task<IActionResult> GetAuthor([FromBody]GetAuthorRequest request)
        {
            if (request==null)
            {
                return NotFound();
            }
            Author author = await _authorService.GetById(request.Id);
            ListAuthorResponse response = new ListAuthorResponse();
            response.Id = author.Id;
            response.Name = author.Name;
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request)
        {
            Author author = await _authorService.GetById(request.Id);
            author.Name = request.Name;
            _authorService.Update(author);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor([FromBody] DeleteAuthorRequest request)
        {
            Author author = await _authorService.GetById(request.Id);
            author.IsActive = false;
            _authorService.Update(author);
            return Ok();
        }

    }
}
