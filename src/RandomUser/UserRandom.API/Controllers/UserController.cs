using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserRandom.API.Controllers.Base;
using UserRandom.API.Filter.PaginationHelper;
using UserRandom.API.Filter.UriService;
using UserRandom.API.Pagination;
using UserRandom.Application.UseCases.Contracts;
using UserRandom.Domain.Entities;
using UserRandom.Domain.Notification.Contracts;

namespace UserRandom.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : MainController
    {
        //use cases
        private readonly IUpdateUser update;
        private readonly IDeleteUser delete;
        private readonly IGetUser get;

        // filter
        IUriService uriService;

        public UserController(INotifier notifier, IUpdateUser update, IDeleteUser delete, IGetUser get, IUriService uriService) : base(notifier)
        {
            this.update = update;
            this.delete = delete;
            this.get = get;

            this.uriService = uriService;
        }

        #region GET
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            // filter pagination data
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            // get 
            var response = await get.GetAll();

            // total data
            var totalUsers = response.Count;

            // pagination
            var data = response.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize);


            // custom filter pagination information
            var pagedReponse = PaginationHelper.CreatePagedReponse<User>(data.ToList(), validFilter, totalUsers, uriService, route);

            return CustomResponse(pagedReponse);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await get.GetById(id);
            return CustomResponse(response);
        }
        #endregion

        #region PUT
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] string id, string title, string firstname, string lastName)
        {
            await update.Update(id, title, firstname, lastName);
            return CustomResponse();
        }
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id)
        {
            await update.UpdateById(id);
            return CustomResponse();
        }

        #endregion

        #region DELETE
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await delete.DeleteById(id);
            return CustomResponse();
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [HttpDelete("delete/{email}")]
        public async Task<IActionResult> DeleteEmail(string email)
        {
            await delete.Delete(email);
            return CustomResponse();
        }
        #endregion
    }
}
