using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Giving the number of collisions and deliveries and outputs the final score in the game.
        /// </summary>
        /// <returns>
        /// It returns the final score in the game.
        /// </returns>
        /// <param name="Collisions"> The number of collisions with an obstacle </param>
        /// <param name="Deliveries"> The number of pacakges delivered </param>
        /// <remarks>
        /// Content-Type: application/x-www-form-urlencoded
        /// </remarks>
        /// <example>
        /// POST : api/J1/Delivedroid  ->  950 (Request Body: Collisions=5&Deliveries=10) 
        /// POST : api/J1/Delivedroid  -> 300 (Request Body: Collisions=20&Deliveries=10)
        /// POST : api/J1/Delivedroid  -> -200 (Request Body: Collisions=20&Deliveries=0) 
        /// </example>


        [HttpPost(template:"Delivedroid")]
        public int Delivedroid([FromForm]int Collisions, [FromForm]int Deliveries)
        {
            int collisions_score = 10 * Collisions;
            int deliveries_score = 50 * Deliveries;
            int bonus_score = 500;
            int final_score;

            if (Deliveries > Collisions)
            {
                final_score =  deliveries_score - collisions_score + bonus_score;
            }
            else
            {
                final_score = deliveries_score - collisions_score;
            }

            return final_score;
        }




        /// <summary>
        /// Inputs the number of regular boxes and small boxes and outputs the number of cupackes left.
        /// </summary>
        /// <returns>
        /// Outputs the number of cupcakes left.
        /// </returns>
        /// <param name="reg_box"> number of regular boxes </param>
        /// /// <param name="small_box"> number of small boxes </param>
        /// <remarks>
        /// Given is the number of cupackes box can hold:
        /// Regular box(i.e. reg_box) = 8
        /// Small box(i.e. small_box) = 3
        /// </remarks>
        /// <example>
        /// POST : api/J1/cupcakes?reg_box=2&small_box=5  ->  3 
        /// POST : api/J1/cupcakes?reg_box=2&small_box=4  ->  0 
        /// POST : api/J1/cupcakes?reg_box=4&small_box=2  ->  10 
        /// </example>

        [HttpPost(template: "cupcakes")]

        public int cupcakes([FromForm]int reg_box, [FromForm]int small_box)
        {
            int cupcakes_in_reg_box = 8 * reg_box;
            int cupcakes_in_small_box = 3 * small_box;
            int total_students = 28;

            int num_of_cupcakes_left = (cupcakes_in_reg_box + cupcakes_in_small_box) - total_students;

            return num_of_cupcakes_left;
        }
































    }
}
