namespace B18_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            int inputNumber;
            bool enteredLegalNumber = false;
            System.Console.WriteLine("Please write a whole positive number of length 6:");
            string inputNumberString = System.Console.ReadLine();

            // If user enters an illegal number - ask for a new legal number.
            while (!enteredLegalNumber)
            {
                int inputNumberStringLength = inputNumberString.Length;
                if (inputNumberStringLength == 6 && int.TryParse(inputNumberString, out inputNumber) && inputNumber >= 0)
                {
                    enteredLegalNumber = true;
                    updateNumberStatistics(out char minimumDigit, out char maximumDigit, out int evenDigitsCounter, out int digitsLessThanFirstCounter, inputNumberString);
                    string numerStatisticsMessage = 
                        string.Format(
@"The input number is: {0}.
1. The largest digit is: {1}
2. The smallest digit is: {2}
3. The number of even digits are: {3}
4. Number of digits that are smaller than the first digit: {4}",
                        inputNumberString, maximumDigit, minimumDigit, evenDigitsCounter, digitsLessThanFirstCounter);
                    System.Console.WriteLine(numerStatisticsMessage);
                }
                else
                {
                    System.Console.WriteLine("You have entered an illegal input! Please write a whole positive number of length 6.");
                    inputNumberString = System.Console.ReadLine();
                }
            }

            System.Console.WriteLine("Type any key to exit");
            System.Console.ReadLine();
        }

        private static void updateNumberStatistics(out char o_MinimumDigit, out char o_MaximumDigit, out int o_EvenDigitsCounter, out int o_DigitsLessThanFirstCounter, string i_InputString)
        {
            o_MinimumDigit = i_InputString[0];
            o_MaximumDigit = i_InputString[0];
            o_EvenDigitsCounter = 0;
            o_DigitsLessThanFirstCounter = 0;
            char firstDigit = i_InputString[0];
            foreach (char currentDigit in i_InputString)
            {
                if (currentDigit < o_MinimumDigit)
                {
                    o_MinimumDigit = currentDigit;
                }

                if (currentDigit > o_MaximumDigit)
                {
                    o_MaximumDigit = currentDigit;
                }
                
                // Update counter if the digit is even.
                int digitInteger = int.Parse(currentDigit.ToString());
                o_EvenDigitsCounter += digitInteger % 2 == 0 ? 1 : 0;

                // Update counter if the digit is smaller than the first digit.
                o_DigitsLessThanFirstCounter += currentDigit < firstDigit ? 1 : 0;
            }
        }
    }
}
