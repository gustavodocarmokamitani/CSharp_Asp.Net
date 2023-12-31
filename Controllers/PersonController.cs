using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);                    

                    return Ok(sum.ToString());
                }
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                    var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                    return Ok(subtract.ToString());
                }
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                    var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                    return Ok(multiplication.ToString());
                }
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("division /{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                    var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                    return Ok(division.ToString());
                }
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("average /{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                    var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                    return Ok(average.ToString());
                }
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("squareRoot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var numericValue = ConvertToDecimal(number);

                if (numericValue >= 0) 
                {
                    var squareRoot = Math.Sqrt((double)numericValue); 

                    return Ok(squareRoot.ToString());
                }
                else
                {
                    return BadRequest("Invalid Input: Cannot calculate square root of a negative number");
                }
            }
            return BadRequest("Invalid Input");
        }




        private bool IsNumeric(string strNumber)
        {
            double number;            
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
