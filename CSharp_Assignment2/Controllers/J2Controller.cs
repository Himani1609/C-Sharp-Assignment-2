using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {


        /// Question-3


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

            int total_spiceness = 0;
            string[] list_peppers = ingredients.Split(',');

            foreach(string pepper in list_peppers)
            {
                
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









        /// Question-4


        /// <summary>
        /// Inputs the number of scores and fouls each player made and 
        /// returns the number of players who got rating above threshold(40) and if the team is gold or not.
        /// </summary>
        /// <returns>
        /// The number of players who got rating above 40 and if team is gold or not
        /// </returns>
        /// <param name="score"> the number of scores player made </param>
        /// <param name="foul"> the number of fouls player made</param>
        /// <remarks>
        /// User inputs the number of scores and fouls player made and that is stored in the form of individual lists
        /// (list<int> score and list<int> foul) and then 5 points are given to each score that player made and 3 points are 
        /// deducted for each foul that player made and then there will be a for loop that loop for all the players and then 
        /// see if the player has points above threshold i.e. 40 then it will be added to gold_team variable and it then checks 
        /// if the team is gold or not( i.e. a team is gold if all the players of the team have points above threshold) and 
        /// returns the total number of players above threshold points and returns a boolean true/false if the team is gold or not.        /// 
        /// </remarks>
        /// <example>
        /// GET : api/J2/rating?score=12&score=10&score=9&foul=4&foul=3&foul=1 -> Players that have rating above 40 are: 3 ,Team is gold team: True
        /// GET : api/J2/rating?score=8&score=12&foul=0&foul=1 -> Players that have rating above 40 are: 2 ,Team is gold team: True
        /// </example>

        [HttpGet(template:"rating")]

        public string rating([FromQuery]List<int> score,[FromQuery]List<int> foul)
        {
            int gold_team = 0;
            int total_players = score.Count;
            int threshold = 40;

            for (int i = 0; i < total_players; i++)
            {
                int star_rating = (5 * score[i]) - (3 * foul[i]);

                if (star_rating >= threshold) { 

                    gold_team++;
                }
            }

            bool team_gold_or_not = gold_team == total_players;

            return "Players that have rating above 40 are: " + gold_team + " ,Team is gold team: " + team_gold_or_not;

        }
    }
}

