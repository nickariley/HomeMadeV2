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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/<IngredientsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var ingredientModels = _ingredientService.GetAll().ToApiModels();
            return Ok(ingredientModels);
        }

        // GET api/<IngredientsController>/5
        //[HttpGet("/api/ingredients/{ingredientId}/recipes")]
        [HttpGet("/api/recipes/{recipeId}/ingredients")]
        public IActionResult GetIngredientsForRecipe(int recipeId)
        {
            var ingredientModels = _ingredientService.GetIngredientsForRecipe(recipeId).ToApiModels();
            return Ok(ingredientModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ingredient = _ingredientService.Get(id);
            if (ingredient == null) return NotFound();
            return Ok(ingredient.ToApiModel());
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public IActionResult Post([FromBody] IngredientModel ingredientModel)
        {
            try
            {

                // add the new book
                _ingredientService.Add(ingredientModel.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddIngredient", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = ingredientModel.Id }, ingredientModel);
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] IngredientModel ingredientModel)
        {
            var updatedIngredient = _ingredientService.Update(ingredientModel.ToDomainModel());
            if (updatedIngredient == null) return NotFound();
            return Ok(updatedIngredient.ToApiModel());
        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ingredient = _ingredientService.Get(id);

            if (ingredient == null) return NotFound();

            _ingredientService.Remove(ingredient);

            return NoContent();
        }
    }
}
