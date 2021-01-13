namespace Yummy.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Yummy.Services.Data;
    using Yummy.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]

        // Post(expecting VoteInputModel)
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.votesService.VoteAsync(input.RecipeId, userId, input.Value);

            var votesAverage = this.votesService.RecipeVotesAvg(input.RecipeId);

            var vm = new VoteResponseModel()
            {
                AverageVote = votesAverage,
            };
            return vm;
        }
    }
}
