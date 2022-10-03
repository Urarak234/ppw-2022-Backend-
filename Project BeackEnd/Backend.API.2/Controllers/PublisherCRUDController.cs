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
    public class PublisherCRUDController
    {
        private readonly Endpoints _endpoint;

        public PublisherCRUDController(Endpoints endpoint)
        {
            _endpoint = endpoint;
        }

        //CRUD Methods
        /// <summary>
        /// Get a publisher by specified ID from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information
        /// Shows a publisher object by specified <code>id</code> 
        /// </remarks>
        /// <param name="id">Introduce the ID of a game you are looking for</param>
        /// <response code = "200">Publisher is found!</response>
        /// <response code = "404">Publisher is not found! Check the intorduced id!</response>
        [AllowAnonymous]
        [HttpGet("GetPublisherByID")]
        public JsonResult GetPublisherByID(int id)
        {
            var result = _endpoint.GetPUBLISHER(id);
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
        [AllowAnonymous]
        [HttpGet("GetAllPublishers")]
        public JsonResult GetAllPublishers()
        {
            var result = _endpoint.GetAllPUBLISHERS();
            return result;
        }

        /// <summary>
        /// Create a publisher and post it into the DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that creates an object of a publisher and put it into DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Post Example:</b>
        /// 
        ///         {
        ///             "id": 1,                                                Introduce ID
        ///             "name": "Konami",                                       Introduce Title
        ///             "image": "IMG",                                         Introduce img path
        ///             "description": "Game company that develops games",      Introduce some description
        ///             "site": "https://www.konami.com/en/",                   Introduce site adress (if exists)
        ///             "games": 1                                              Introduce game
        ///         }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="publisher">Create publisher object</param>
        /// <response code = "200">Publisher is created and posted!</response>
        /// <response code = "404">Error! Check the intorduced info if it's correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify games!</response>
        [HttpPost("PostA_Publisher")]
        public Task<IActionResult> PostAPublisher(Publishers publisher)
        {
            var result = _endpoint.AddPUBLISHER(publisher);
            return result;
        }

        /// <summary>
        /// Update a publisher info in the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds an object of a publisher by it's <code>ID</code> and change it's <code>data</code> in the DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Update Example:</b>
        /// 
        ///         {
        ///             "id": 1,                                                Introduce ID
        ///             "name": "Konami",                                       Introduce Title
        ///             "image": "IMG",                                         Introduce img path
        ///             "description": "Game company that develops games",      Introduce some description
        ///             "site": "https://www.konami.com/en/",                   Introduce site adress (if exists)
        ///             "games": 1                                              Introduce game
        ///         }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="publisher">Update publisher object</param>
        /// <response code = "200">Publisher is Updated and Saved!</response>
        /// <response code = "404">Publisher not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify games!</response>
        [HttpPut("UpdateA_Publisher")]
        public Task<IActionResult> UpdateAPublisher(Publishers publisher)
        {
            var result = _endpoint.UpdatePUBLISHER(
                publisher.id,
                publisher.name, 
                publisher.image,
                publisher.description,
                publisher.site, 
                publisher.games
                );
            return result;
        }

        /// <summary>
        /// Delete a publisher from the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds and delets an object of a publisher by it's <code>ID</code> from the DataBase.  
        /// </remarks>
        /// <param name="id">Introduce <code>Id</code> of an object. </param>
        /// <response code = "200">Publisher is Deleted!</response>
        /// <response code = "404">Publisher not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpDelete("DeleteA_Publisher")]
        public Task<IActionResult> DeletePublisher(int id)
        {
            var result = _endpoint.DeletePUBLISHER(id);
            return result;
        }
    }
}
