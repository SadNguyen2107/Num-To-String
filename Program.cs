namespace NumToString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Only Read From 0 to 999");
            // Get Number From Console
            Int32 num = Number.GetNumInput("Number");
            
            // Turn Number -> String
            String num_str = Number.ReadNum(num);
            Console.WriteLine(num_str);
        }
    }
}