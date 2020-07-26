using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeMade.ApiModels;
using HomeMade.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeMade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        // GET: api/<RecipesController>
        [HttpGet()]
        public IActionResult GetAll()
        {
            var recipeModels = _recipeService.GetAll().ToApiModels();
            return Ok(recipeModels);
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        
        {
            var recipe = _recipeService.Get(id);
            if (recipe == null) return NotFound();
            return Ok(recipe);
        }

        [HttpGet("/api/ingredients/{ingredientId}/recipes")]
        public IActionResult GetIngredientsForRecipe(int ingredientId)
        {
            var recipeModels = _recipeService.GetIngredientsForRecipe(ingredientId).ToApiModels();
            return Ok(recipeModels);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public IActionResult Add([FromBody] RecipeModel recipeModel)
        {
            try
            {
                // add the new author
                _recipeService.Add(recipeModel.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddRecipe", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new author. E.g., /api/authors/99, if the new is 99
            return CreatedAtAction("Get", new { Id = recipeModel.Id }, recipeModel);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RecipeModel recipeModel)
        {
            //ModelState.AddModelError("UpdateQuestion", "Not Implemented!");            
            //return BadRequest(ModelState);
            var updatedRecipe = _recipeService.Update(recipeModel.ToDomainModel());
            if (updatedRecipe == null) return NotFound();
            return Ok(updatedRecipe);
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            //ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
            //return BadRequest(ModelState);
            //_recipeService.Remove(id);
            //return Ok();
            var recipe = _recipeService.Get(id);

            if (recipe == null) return NotFound();

            _recipeService.Remove(recipe);

            return NoContent();
        }
    }
}
