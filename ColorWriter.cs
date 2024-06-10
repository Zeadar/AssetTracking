namespace AssetTracking
{
    internal class ColorWriter
    {
        static public void RedLine(string input)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        static public void GreenLine(string input)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }

		static public string YellowPrompt(string query){
            Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(query.PadLeft(25));
			Console.Write(" > ");
			Console.ResetColor();
            string input = Console.ReadLine() ?? "";
            return input.Trim().ToUpper();
		}

        //Turns out Console.WriteLine with background
        //color is buggy af
        static public void MatrixLine(string output, ConsoleColor color) 
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = color;
            foreach (char c in output)
            {
                Console.Write(c);
            }
            Console.ResetColor();
            Console.Write("\n");
        }

        static public void MatrixLine(string output){
            MatrixLine(output, ConsoleColor.White);
        }
    }
}
