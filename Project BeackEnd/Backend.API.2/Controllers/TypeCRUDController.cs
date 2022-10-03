using Backend.API._2.Entities;
using Backend.API._2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.API._2.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API._2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeCRUDController
    {
        private readonly Endpoints _endpoint;

        public TypeCRUDController(Endpoints endpoint)
        {
            _endpoint = endpoint;
        }

        //CRUD Methods
        /// <summary>
        /// Get a type by specified ID from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information
        /// Shows a types object by specified <code>id</code> 
        /// </remarks>
        /// <param name="id">Introduce the ID of a type you are looking for</param>
        /// <response code = "200">Type is found!</response>
        /// <response code = "404">Type is not found! Check the intorduced id!</response>
        [AllowAnonymous]
        [HttpGet("GetTypeByID")]
        public JsonResult GetTypeByID(int id)
        {
            var result = _endpoint.Get_Type(id);
            return result;
        }

        /// <summary>
        /// Get all types from a DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that produce some information.
        /// Shows all types objects in format <code>JSON</code> 
        /// </remarks>
        /// <response code = "200">Successfully retrieved data!</response>
        /// <response code = "404">Types are not found! May be <code>DataBase is empty!</code></response>
        [AllowAnonymous]
        [HttpGet("GetAllTypes")]
        public JsonResult GetAllTypes()
        {
            var result = _endpoint.GetAll_Types();
            return result;
        }

        /// <summary>
        /// Create a type and post it into the DataBase
        /// </summary>
        /// <remarks>
        /// Simple request that creates an object of a type and put it into DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Post Example:</b>
        /// 
        ///     {
        ///         "id": 1,                Introduce id
        ///         "type": "PC"            Introduce type name
        ///     }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="type">Create type object</param>
        /// <response code = "200">Type is created and posted!</response>
        /// <response code = "404">Error! Check the intorduced info if it's correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify games!</response>
    [HttpPost("PostA_Type")]
        public Task<IActionResult> PostAType(Types type)
        {
            var result = _endpoint.Add_Type(type);
            return result;
        }

        /// <summary>
        /// Update a type info in the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds an object of a type by it's <code>ID</code> and change it's <code>data</code> in the DataBase. 
        /// Introduce data of an object by the <code>example</code> bellow. 
        /// <example>
        /// <br/><b>Update Example:</b>
        /// 
        ///     {
        ///         "id": 1,                Introduce id
        ///         "type": "PC"            Introduce type name
        ///     }
        /// 
        /// </example>
        /// </remarks>
        /// <param name="type">Update type object</param>
        /// <response code = "200">Type is Updated and Saved!</response>
        /// <response code = "404">Type not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        /// <response code = "500">Introduced data is not valid or u missed to identify games!</response>
        [HttpPut("UpdateA_Type")]
        public Task<IActionResult> UpdateAType(Types type)
        {
            var result = _endpoint.Update_Types(
                type.id,
                type.type
                );
            return result;
        }

        /// <summary>
        /// Delete a type from the DataBase
        /// </summary>
        /// <remarks>
        /// A request that finds and delets an object of a type by it's <code>ID</code> from the DataBase.  
        /// </remarks>
        /// <param name="id">Introduce <code>Id</code> of an object. </param>
        /// <response code = "200">Type is Deleted!</response>
        /// <response code = "404">Type not found! Check if <code>ID</code> is introduced correctly!</response>
        /// <response code = "401">You are not Valid to use this!</response>
        [HttpDelete("DeleteA_Type")]
        public Task<IActionResult> DeleteType(int id)
        {
            var result = _endpoint.Delete_Type(id);
            return result;
        }
    }
}
