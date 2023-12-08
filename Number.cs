namespace NumToString
{
    public class Number
    {
        public readonly static Dictionary<int, string> lookUpTable = new Dictionary<int, string>{
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
        };

        public static Int32 GetNumInput(string prompt)
        {
            // Return Result 
            Int32 num;

        askNumInput:
            Console.Write($"Please enter a {prompt}: ");
            bool issuccess = Int32.TryParse(Console.ReadLine(), out num);
            if (!issuccess)
            {
                Console.WriteLine($"{prompt} Cannot Be A Character or String!");
                goto askNumInput;
            }

            return num;
        }

        private static String ReadOnes(Int32 num)
        {
            return lookUpTable[num];
        }
        private static String ReadTenthFrom10to19(Int32 num)
        {
            String num_str = "";

            // Process The Ones
            Int32 ones_num = num % 10;
            switch (ones_num)
            {
                case 0:
                    num_str += "ten";
                    break;
                case 1:
                    num_str += "eleven";
                    break;
                case 2:
                    num_str += "twelve";
                    break;
                case 3:
                    num_str += "thirteen";
                    break;
                case 4:
                    num_str += "fourteen";
                    break;
                case 5:
                    num_str += "fifteen";
                    break;
                case 8:
                    num_str += "eighteen";
                    break;
                default:
                    num_str += $"{lookUpTable[ones_num]}teen";
                    break;
            }

            return num_str;
        }

        private static String ReadTenthFrom20to99(Int32 num)
        {
            String num_str = "";

            // Process The Tenth Number
            Int32 tenth_num = num / 10;
            switch (tenth_num)
            {
                case 2:
                    num_str += "twenty";
                    break;
                case 3:
                    num_str += "thirty";
                    break;
                case 4:
                    num_str += "forty";
                    break;
                case 5:
                    num_str += "fifty";
                    break;
                case 8:
                    num_str += "eighty";
                    break;
                default:
                    num_str += $"{lookUpTable[tenth_num]}ty";
                    break;
            }

            // Process The Ones Number
            Int32 ones_num = num % 10;
            if (ones_num > 0)
            {
                num_str += "-";
                num_str += ReadOnes(ones_num);
            }

            return num_str;
        }

        private static String ReadHundred(Int32 num)
        {
            String num_str = "";

            // Process The Hundreds
            Int32 hundred_num = num / 100;
            num_str = lookUpTable[hundred_num] + " hundred";

            // Process The Tenth
            Int32 tenth_num = num - hundred_num * 100;
            num_str += " ";
            if (tenth_num > 0)
            {
                if (tenth_num < 20)
                {
                    num_str += ReadTenthFrom10to19(tenth_num);
                }
                else
                {
                    num_str += ReadTenthFrom20to99(tenth_num);
                }
            }


            return num_str;
        }

        public static String ReadNum(Int32 num)
        {
            Console.Write("Convert To String: ");

            String num_str = "";
            if (num < 0)
            {
                num_str = "out of ability";
            }
            else if (num < 10)
            {
                num_str = ReadOnes(num);
            }
            else if (num < 20)
            {
                num_str = ReadTenthFrom10to19(num);
            }
            else if (num < 100)
            {
                num_str = ReadTenthFrom20to99(num);
            }
            else if (num < 1000)
            {
                num_str = ReadHundred(num);
            }
            else
            {
                num_str = "out of ability";
            }

            return num_str;
        }
    }

}