using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CSharp_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {


        /// Question-5





        /// <summary>
        /// Inputs the sequences(five digit code) in the form of list of strings and then decodes it into instructions including direction(from first two digits) and steps(last three digits).
        /// </summary>
        /// <param name="sequences">List of five-digit sequences representing the instructions.</param>
        /// <returns>A list of decoded instructions (direction and steps).</returns>
        /// <remarks>
        /// Each instruction must be exactly five digits.  
        /// The first two digits determine the direction:
        /// If their sum is odd, the direction is "left."
        /// If their sum is even (and not zero), the direction is "right."
        /// If their sum is zero, the direction remains the same as the previous instruction.
        /// The last three digits represent the number of steps.
        /// If the sequence is "99999," processing will terminate.
        /// </remarks>
        /// <method>
        /// The input is taken in string and made a list called sequences then we validate if the first number in the sequences list
        /// is 99999 then we break the loop that means we stop the code there only. Next we validate if the digits of each number
        /// in the sequences are five or not, if not five then we print the message "Each instruction must be exactly five digits."
        /// Then we get the first digit and second digit of the number in sequence using substring and then we convert the substring 
        /// into integer so that we can add the fisrt two digits and then compare if sum is zero or even or odd and then assign the 
        /// direction previous direction or right or left accordingly. The last three digits are extracted from number in the sequences 
        /// using .Substring(2) which means get the digits from index2 till end. The direction after if-elseif-else is assigned to previous direction
        /// and at last return the result which includes direction and step.
        /// </method>
        /// <example>
        /// GET api/J3/code?sequences=57234&sequences=00907&sequences=34100&sequences=99999  ->  right 234
        ///                                                                                      right 907
        ///                                                                                      left 100
        /// GET api/J3/code?sequences=34554&sequences=00807&sequences=56100&sequences=99999  ->  left 554
        ///                                                                                      left 807
        ///                                                                                      left 100                                                                                     
        /// </example>


        [HttpGet(template: "code")]
        public string code([FromQuery] List<string> sequences)
        {
            string result = "";
            string preDirection = "";

            foreach (var num in sequences)
            {
                if (num == "99999"){
                    break;
                }

                if (num.Length != 5){
                    result += "Each instruction must be exactly five digits.\n";
                    continue;
                }

                int firstDigit = int.Parse(num.Substring(0, 1));
                int secondDigit = int.Parse(num.Substring(1, 1));
                int sum = firstDigit + secondDigit;

                string steps = num.Substring(2);
                string direction = "";

                if (sum == 0){
                    direction = preDirection;
                }
                else if ((sum % 2) != 0){
                    direction = "left";
                }
                else{
                    direction = "right";
                }

                result += $"{direction} {steps}\n";
                preDirection = direction;
            }

            return result;
        }
    }
}




