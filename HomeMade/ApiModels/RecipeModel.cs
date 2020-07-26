﻿using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeClassification { get; set; }

        //public string User { get; set; } //added
        //public int UserId { get; set; } //added
        public ICollection<IngredientModel> Ingredients { get; set; }
        //public int IngredientId { get; set; } //added
    }
}
