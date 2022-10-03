using Backend.API._2.Entities;
using Backend.API._2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.API._2.Data;
using Microsoft.AspNetCore.Authorization;

namespace Backend.API._2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameCRUDController 
    {
        private readonly Endpoints _endpoint;

        public GameCRUDController(Endpoints endpoint)
        {
            _endpoint = endpoint;
        }

        //CRUD Methods
        /// <summary>
        /// Get a game by specified ID from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information
        /// Shows a game object by specified <code>id</code> 
        /// </remarks>
        /// <param name="id">Introduce the ID of a game you are looking for</param>
        /// <response code = "200">Game is found!</response>
        /// <response code = "404">Game is not found! Check the intorduced id!</response>
        [AllowAnonymous]
        [HttpGet("GetGameByID")]
        public JsonResult GetGameByID(int id)
        {
            var result = _endpoint.Get(id);
            return result;
        }

        /// <summary>
        /// Get all games from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all game objects in format <code>JSON</code> 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Games are not found! May be <code>DataBase is empty!</code></response>
        [AllowAnonymous]
        [HttpGet("GetAllGames")]
        public JsonResult GetAllGames()
        {
            var result = _endpoint.GetAll();
            return result;
        }

        /// <summary>
        /// Create a game and post it into the DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that creates an object of a game and put it into DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Post Example:</b>
        /// 
        ///     {
        ///         "id": 5,                                                Introduce Id
        ///         "image": "C/:images/imgexample.jpg",                    Introduce img path
        ///         "title": "The Game Title",                              Introduce game title
        ///         "description": "Introduce some description here",
        ///         "publisher": 5,                                         Select a publisher
        ///         "score": 5,                                             Introduce some Score (max 5)
        ///         "genre": "Introduce a maximum apropiate genre",
        ///         "type": 2,                                              Select a type
        ///         "tagsText": "Introduce tags, separeted by <c>,</c>",
        ///         "tags": null                                            DO not toch this!
        ///     }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="game">Create game object</param>
        /// <response code = "200">Game is created and posted!</response>
        /// <response code = "404">Error! Check the intorduced info if it's correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify type/publisher!</response>
        [HttpPost("PostA_Game")]
        public Task<IActionResult> PostAGame(Game game)
        {
            var result = _endpoint.AddGame(game);
            return result;
        }

        /// <summary>
        /// Update a game info in the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds an object of a game by it's <code>ID</code> and change it's <code>data</code> in the DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Update Example:</b>
        /// 
        ///     {
        ///         "id": 5,                                                Introduce Id
        ///         "image": "C/:images/imgexample.jpg",                    Introduce img path
        ///         "title": "The Game Title",                              Introduce game title
        ///         "description": "Introduce some description here",
        ///         "publisher": 5,                                         Select a publisher
        ///         "score": 5,                                             Introduce some Score (max 5)
        ///         "genre": "Introduce a maximum apropiate genre",
        ///         "type": 2,                                              Select a type
        ///         "tagsText": "Introduce tags, separeted by <c>,</c>",
        ///         "tags": null                                            DO not toch this!
        ///     }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="game">Update game object</param>
        /// <response code = "200">Game is Updated and Saved!</response>
        /// <response code = "404">Game not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify type/publisher!</response>
        [HttpPut("UpdateA_Game")]
        public Task<IActionResult> UpdateAGame(Game game)
        {
            var result = _endpoint.UpdateGame(
                game.id,
                game.image,
                game.title,
                game.description,
                game.publisher,
                game.score,
                game.genre,
                game.type,
                game.tagsText
                );
            return result;
        }

        /// <summary>
        /// Delete a game from the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds and delets an object of a game by it's <code>ID</code> from the DataBase.  
        /// </remarks>
        /// <param name="id">Introduce <code>Id</code> of an object. </param>
        /// <response code = "200">Game is Deleted!</response>
        /// <response code = "404">Game not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpDelete("DeleteA_Game")]
        public Task<IActionResult> DeleteAGame(int id)
        {
            var result = _endpoint.DeleteGame(id);
            return result;
        }
    }
}
