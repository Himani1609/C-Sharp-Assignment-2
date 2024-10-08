using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {

        /// <summary>
        /// Inputs the name of the pepper and outputs the total spiceness in SHU units(Scolville Heat Units).
        /// </summary>
        /// <returns>
        /// It returns the total spiceness in SHU units(Scolville Heat Units) in integer datatype.
        /// </returns>
        /// <param name="ingredients">A comma-separated list of pepper names</param>
        /// <remarks>
        ///The available peppers and their SHU values are:
        /// Poblano = 1500
        /// Mirasol = 6000
        /// Serrano = 15500
        /// Cayenne = 40000
        /// Thai = 75000
        /// Habanero = 125000
        /// </remarks>
        /// <example>
        /// GET : api/J2/ChiliPeppers?Ingredients=Poblano,Cayenne,Thai,Poblano  -> 118000
        /// GET : api/J2/ChiliPeppers?Ingredients=Habanero,Habanero,Habanero,Habanero,Habanero  -> 625000
        /// GET : api/J2/ChiliPeppers?Ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano  -> 278500
        /// </example>

        [HttpGet(template:"ChiliPeppers")]
        public int ChiliPeppers(string ingredients)
        {
            int Poblano = 1500;
            int Mirasol = 6000;
            int Serrano = 15500;
            int Cayenne = 40000;
            int Thai = 75000;
            int Habanero = 125000;

            // Initializing the variable total_spiceness 
            int total_spiceness = 0;

            // Making an array where we store the name of peppers got by splitting the string of ingredients parameter
            string[] list_peppers = ingredients.Split(',');

            foreach(string pepper in list_peppers)
            {
                // if there are any extra spaces around pepper names, it removes that
                string trim_pepper = pepper.Trim(); 

                if (trim_pepper == "Poblano")
                {
                    total_spiceness += Poblano;
                }
                else if (trim_pepper == "Mirasol")
                {
                    total_spiceness += Mirasol;
                }
                else if (trim_pepper == "Serrano")
                {
                    total_spiceness += Serrano;
                }
                else if (trim_pepper == "Cayenne")
                {
                    total_spiceness += Cayenne;
                }
                else if (trim_pepper == "Thai")
                {
                    total_spiceness += Thai;
                }
                else 
                {
                    total_spiceness += Habanero;
                }
            }

            return total_spiceness;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <param> </param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <example>
        /// 
        /// </example>

        [HttpGet(template:"rating")]

        public int rating(int score,int foul)
        {
            int gold_team = 0;
            int total_players = score.Length;
            bool above_threshold = true;

            for (int i = 0; i < total_players; i++)
            {
                int star_rating = (5 * score) - (3 * foul);

                if (star_rating >= 40) { 

                    gold_team++;
                }

                above_threshold = false;
            }

        }
    }
}

