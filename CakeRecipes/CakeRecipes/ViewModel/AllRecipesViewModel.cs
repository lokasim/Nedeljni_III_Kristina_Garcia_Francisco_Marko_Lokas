﻿using CakeRecipes.Command;
using CakeRecipes.Models;
using CakeRecipes.Services;
using CakeRecipes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CakeRecipes.ViewModel
{
    class AllRecipesViewModel : ViewModelBase
    {
        RecipeService recipeData = new RecipeService();
        AllRecipesWindow allReciperWindow;

        #region Constructor
        /// <summary>
        /// Constructor with the AllRecipesWindow info window opening
        /// </summary>
        /// <param name="allRecipesWindowOpen">opends the window</param>
        public AllRecipesViewModel(AllRecipesWindow allRecipesWindowOpen)
        {
            allReciperWindow = allRecipesWindowOpen;
            RecipeList = recipeData.GetAllRecipes().ToList();
        }
        #endregion

        #region Property
        /// <summary>
        /// List of recipes
        /// </summary>
        private List<tblRecipe> recipeList;
        public List<tblRecipe> RecipeList
        {
            get
            {
                return recipeList;
            }
            set
            {
                recipeList = value;
                OnPropertyChanged("RecipeList");
            }
        }

        /// <summary>
        /// Specific Recipe
        /// </summary>
        private tblRecipe recipe;
        public tblRecipe Recipe
        {
            get
            {
                return recipe;
            }
            set
            {
                recipe = value;
                OnPropertyChanged("Recipe");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Delete Recipe button
        /// </summary>
        private ICommand deleteRecipe;
        public ICommand DeleteRecipe
        {
            get
            {
                if (deleteRecipe == null)
                {
                    deleteRecipe = new RelayCommand(param => DeleteRecipeExecute(), param => CanDeleteRecipeExecute());
                }
                return deleteRecipe;
            }
        }

        /// <summary>
        /// Method for deleting the selected item from the list
        /// </summary>
        public void DeleteRecipeExecute()
        {
            try
            {
                MessageBoxResult dialogDelete = Xceed.Wpf.Toolkit.MessageBox.Show($"Da li zelite da obrisete ovaj recept iz liste?\n\nRecept: {Recipe.RecipeName}", "Obrisi recept", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (dialogDelete == MessageBoxResult.Yes)
                {
                    if (Recipe != null)
                    {
                        recipeData.DeleteRecipe(Recipe.RecipeID);
                        RecipeList = recipeData.GetAllRecipes().ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Trenutno je nemoguce obrisati recept...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Checks if its possible to press the delete button
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteRecipeExecute()
        {
            if (Recipe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Edit Recipe button
        /// </summary>
        private ICommand editRecipe;
        public ICommand EditRecipe
        {
            get
            {
                if (editRecipe == null)
                {
                    editRecipe = new RelayCommand(param => EditRecipeExecute(), param => CanEditRecipeExecute());
                }
                return editRecipe;
            }
        }

        /// <summary>
        /// Method for edit the selected item from the list
        /// </summary>
        public void EditRecipeExecute()
        {
            try
            {
                MessageBoxResult dialogDelete = Xceed.Wpf.Toolkit.MessageBox.Show($"Da li zelite da azurirate ovaj recept iz liste?\n\nRecept: {Recipe.RecipeName}", "Azuriraj recept", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (dialogDelete == MessageBoxResult.Yes)
                {
                    if (Recipe != null)
                    {
                        AddRecipe addRecipeWindow = new AddRecipe(Recipe);
                        addRecipeWindow.ShowDialog();
                        RecipeList = recipeData.GetAllRecipes().ToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Trenutno je nemoguce obrisati recept...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Checks if its possible to press the edit button
        /// </summary>
        /// <returns></returns>
        public bool CanEditRecipeExecute()
        {
            if (Recipe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Exit button
        /// </summary>
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exits the current window
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Da li zelite da napustiti aplikaciju", "Odustani", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                allReciperWindow.Close();
            }
        }

        /// <summary>
        /// Checks if its possible to press the button
        /// </summary>
        /// <returns></returns>
        private bool CanExitExecute()
        {
            return true;
        }
        #endregion
    }
}