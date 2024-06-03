namespace Checkpoint2
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

		static public void YellowPrompt(string input){
            Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(input.PadLeft(25));
			Console.Write(" > ");
			Console.ResetColor();
		}

        //Turns out Console.WriteLine with background
        //color is buggy af
        static public void MatrixLine(string input) 
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in input)
            {
                Console.Write(c);
            }
            Console.Write("\n");
            Console.ResetColor();
        }
    }
}
