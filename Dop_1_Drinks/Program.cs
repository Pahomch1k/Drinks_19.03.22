using System; 
using static System.Console;
using System.Collections; 
using System.IO;
using System.Text;
using System.Threading;


namespace Dop_1_Drinks
{
    class Program
    {
        static void Main(string[] args)
        {
            Drinks t = new Tea();
            t.InIt(); 
            t.Print();

            Drinks m = new Milk();
            m.InIt();
            m.Print();

            t.Print();
        } 
    }
     

    class Drinks
    {
        int Count = 1;
        string[,] ListDrinks = new string[100, 3];
        string[] s = new string[] {"Name", "Color", "Smak"};
        string line;

        string d { get; set; }

        virtual public void Print()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i + 1 == Count) break;
                Write(i + 1 + ". "); 
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + " - " + ListDrinks[i, j] + " ");
                }
                WriteLine(); 
            } 
        }

        virtual public void InIt()
        {
            WriteLine("Сколько добавить? ");
            int n = 0;
            n = Convert.ToInt32(ReadLine());
            Count += n;
            

            for (int i = 0; i < n; i++)
            {
                WriteLine(i + 1 + ".");
                line = $"{i + 1}. ";
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + "? ");
                    ListDrinks[i, j] = ReadLine();
                    line += $"{s[j]} - {ListDrinks[i, j]} ";
                }
                WriteLine(); 
                SaveInFile(line);
            } 
        }

        virtual public void SaveInFile(string line)
        {
            StreamWriter sw = new StreamWriter("Drinks.txt", true); 
            sw.WriteLine(line);
            sw.Close();
        }
    }

    class Tea : Drinks
    { 
        int Count = 1;
        public override void InIt()
        {
            base.InIt();
        }
        public override void Print()
        {
            base.Print();
        }
    }

    class Milk : Drinks
    { 
        string[] s = new string[] { "Name", "Color", "Smak", "OtKogo" };
        string[,] ListDrinks = new string[100, 4];
        int Count = 1;
        string line;

        public override void InIt()
        {
            WriteLine("Сколько добавить? ");
            int n = 0;
            n = Convert.ToInt32(ReadLine());
            Count += n;

            for (int i = 0; i < n; i++)
            {
                WriteLine(i + 1 + ".");
                line = $"{i + 1}. ";
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + "? ");
                    ListDrinks[i, j] = ReadLine();
                    line += $"{s[j]} - {ListDrinks[i, j]} ";
                }
                WriteLine();
                SaveInFile(line);
            }
        }
        public override void Print()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i + 1 == Count) break;
                Write(i + 1 + ". ");
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + " - " + ListDrinks[i, j] + " ");
                }
                WriteLine();
            }
        }

        public override void SaveInFile(string line)
        {
            StreamWriter sw = new StreamWriter("Milk.txt", true);
            sw.WriteLine(line);
            sw.Close();
        }
    } 
}
