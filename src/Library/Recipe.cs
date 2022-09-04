//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double GetProductionCost()
        {
            double costoTotal = 0;
            double costoInsumos = 0;
            double costoEquipamiento = 0;
            foreach (Step step in this.steps)
            {
                costoInsumos += step.Input.UnitCost * step.Quantity/1000; 
                costoEquipamiento += step.Equipment.HourlyCost * step.Time/3600;
            }
            costoTotal = costoInsumos + costoEquipamiento;
            return costoTotal;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo Total: ${GetProductionCost()}");
        }
    }
}