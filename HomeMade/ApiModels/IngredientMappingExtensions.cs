﻿using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public static class IngredientMappingExtensions
    {
        public static IngredientModel ToApiModel(this Ingredient ingredient)
        {
            return new IngredientModel
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                IngredientQuantity = ingredient.IngredientQuantity,
                IngredientUnit = ingredient.IngredientUnit,
                IngredientEdibleYieldPercentage = ingredient.IngredientEdibleYieldPercentage,
                //RecipeId = ingredient.RecipeId,
                //Recipe = ingredient.Recipe != null
                //? ingredient.Recipe.RecipeName + ", " + ingredient.Recipe.RecipeClassification : null
                
            };
        }

        public static Ingredient ToDomainModel(this IngredientModel ingredientModel)
        {
            return new Ingredient
            {
                Id = ingredientModel.Id,
                IngredientName = ingredientModel.IngredientName,
                IngredientQuantity = ingredientModel.IngredientQuantity,
                IngredientUnit = ingredientModel.IngredientUnit,
                IngredientEdibleYieldPercentage = ingredientModel.IngredientEdibleYieldPercentage,
                //RecipeId = ingredientModel.RecipeId
            };
        }

        public static IEnumerable<IngredientModel> ToApiModels(this IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Select(i => i.ToApiModel());
        }

        public static IEnumerable<Ingredient> ToDomainModels(this IEnumerable<IngredientModel> ingredientModels)
        {
            return ingredientModels.Select(i => i.ToDomainModel());
        }
    }
}
