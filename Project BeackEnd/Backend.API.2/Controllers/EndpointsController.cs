using Backend.API._2.Entities;
using Backend.API._2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.API._2.Data;
//using System.Net.Mime;

namespace Backend.API._2.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class EndpointsController
    {
        private readonly Endpoints _endpoint;

        public EndpointsController(Endpoints endpoint)
        {
            _endpoint = endpoint;
        }

        /// <summary>
        /// Get a game by specified title from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information
        /// Shows a game object by specified <code>title</code> 
        /// </remarks>
        /// <param name="title">Introduce the <b>title</b> of a game you are looking for</param>
        /// <response code = "200">Game is found!</response>
        /// <response code = "404">Game is not found! Check the intorduced title!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("GetGameByTitle")]
        public JsonResult GetGameByTitle_Endpoint(string title)
        {
            var result = _endpoint.GetByTitle(title);
            return result;
        }

        /// <summary>
        /// Get all games by a type from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all game objects in format <code>JSON</code>, by specified <b>type</b>. 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Games are not found! May be <code>DataBase is empty</code> or <code>type not exists</code>!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("GetAllGamesByType")]
        public JsonResult GetAllGamesByType_Endpoint(string type)
        {
            var result = _endpoint.GetGamesByType(type);
            return result;
        }

        /// <summary>
        /// Get all games by a genre from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all game objects in format <code>JSON</code>, by specified <b>genre</b>. 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Games are not found! May be <code>DataBase is empty</code> or <code>genre not exists</code>!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("GetGamesByGenre")]
        public JsonResult GetGamesByGenre(string gener) 
        { 
            var result = _endpoint.GetByGenre(gener);
            return result;
        }

        /// <summary>
        /// Get all games by publisher from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all game objects in format <code>JSON</code>, by specified <b>publisher</b>. 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Games are not found! May be <code>DataBase is empty</code> or <code>publisher not exists</code>!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("GetGamesByPublisher")]
        public JsonResult GetGamesByPublisher(string publsher)
        {
            var result = _endpoint.GetGamesByPublisher(publsher);
            return result;
        }

        /// <summary>
        /// Get all publishers from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all publisher objects in format <code>JSON</code> 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Publisher are not found! May be <code>DataBase is empty!</code></response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("ShowAllPublishers")]
        public JsonResult ShowAllPublishers()
        {
            var result = _endpoint.GetAllPublishers();
            return result;
        }

        /// <summary>
        /// Show all games by specific score
        /// </summary>
        /// <remarks>
        /// Get and show games by a specific score range - from <b>minimal score</b> to <b>maximal score</b>.
        /// If games info shown in the <code>JSON</code> format.
        /// </remarks>
        /// <param name="minScore">Introduce <b>minimal score</b></param>
        /// <param name="maxScore">Introduce <b>maximal score</b></param>
        /// <response code = "200">Successfully games found!</response>
        /// <response code = "404">Games are not found! May be some <code>Score</code> field are not introducesed correctly or <b>no games</b> with that <b>score range</b></response>.
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("ShowGamesByScore")]
        public JsonResult ShowGamesByScore(double minScore, double maxScore)
        {
            var result = _endpoint.GetGamesByScore(minScore, maxScore);
            return result;
        }

        /// <summary>
        /// Show all games by specificated tags
        /// </summary>
        /// <remarks>
        /// Get and show games by a specificated <b>tags</b>. 
        /// If game has introduced tags - it is shown as a result. 
        /// Result will be shown in <code>JSON</code> format. <br/>Maximum tag seletion - <b><c>3</c></b>
        /// </remarks>
        /// <param name="tag_1">Introduce <b>First Tag</b></param>
        /// <param name="tag_2">Introduce <b>Second Tag</b></param>
        /// <param name="tag_3">Introduce <b>Third Tag</b></param>
        /// <response code = "200">Successfully games found!</response>
        /// <response code = "404">Games are not found! May be some <code>Tag</code> fields are not introducesed correctly or <b>no games</b> with that <b>Tags</b></response>.
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("ShowGamesByTags")]
        public JsonResult ShowGamesByTags(string tag_1, string tag_2, string tag_3)
        {
            var result = _endpoint.GetGamesByTags(tag_1, tag_2, tag_3);
            return result;
        }

        /// <summary>
        /// Show all games up to specifc number of results
        /// </summary>
        /// <remarks>
        /// Get and show games by a specificated <b>maximum results</b>. 
        /// If game has introduced tags - it is shown as a result. 
        /// Result will be shown in <code>JSON</code> format. Result counting proceed from <b>left to right</b>.
        /// <br/>There is an addition option: You can introduce the starting point from <b>what game</b> you want to show the result.
        /// </remarks>
        /// <param name="maxResult">Introduce <b>Maximum Results</b></param>
        /// <param name="from">Introduce <b>Starting Point</b></param>
        /// <response code = "200">Successfully games found!</response>
        /// <response code = "404">Games are not found! May be <code>Values</code> from fields are not introducesed correctly or <b>no games left to be shown</b></response>.
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("ShowGamesUpTo")]
        public JsonResult ShowGamesUpTo(int maxResult, int from)
        {
            var result = _endpoint.ShowGamesUpTo(maxResult, from);
            return result;
        }

        /// <summary>
        /// Show all game tags
        /// </summary>
        /// <remarks>
        /// Get and show all game tags from a DataBase. 
        /// Result will be shown in <code>JSON</code> format.
        /// </remarks>
        /// <response code = "200">Successfully tags found!</response>
        /// <response code = "404">Tags are not found! May be there are <b>no tags</b> in the DataBase</response>.
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("ShowAllTagsAvialable")]
        public JsonResult ShowAllTagsAvialable()
        {
            var result = _endpoint.ShowAllTagsAvialable();
            return result;
        }

        /// <summary>
        /// Show number of games in the DataBase.
        /// </summary>
        /// <remarks>
        /// Show number of games in the DataBase. 
        /// Result will be shown in <code>JSON</code> format.
        /// </remarks>
        /// <response code = "200">Number count successfully!</response>
        /// <response code = "404">Games are not found! May be there are <b>games</b> in the DataBase</response>.
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpGet("CountAllGames")]
        public JsonResult CountAllGames()
        {
            var result = _endpoint.CountAllGames();
            return result;
        }
    }
}
