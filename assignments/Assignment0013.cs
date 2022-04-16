
namespace leetcode
{
    class Assignment0013
    {
        public static void Run()
        {
            System.Console.WriteLine(new Assignment0013().RomanToInt("I"));
            System.Console.WriteLine(new Assignment0013().RomanToInt("IV"));
            System.Console.WriteLine(new Assignment0013().RomanToInt("V"));
            System.Console.WriteLine(new Assignment0013().RomanToInt("LVIII"));
            System.Console.WriteLine(new Assignment0013().RomanToInt("MCMXCIV"));
        }

        // naive
        public int RomanToInt(string s)
        {
            var res = 0;

            int tmp = s.IndexOf("CM");

            if (tmp != -1)
            {
                res += 900;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("CD");

            if (tmp != -1)
            {
                res += 400;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("XC");

            if (tmp != -1)
            {
                res += 90;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("XL");

            if (tmp != -1)
            {
                res += 40;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("IX");

            if (tmp != -1)
            {
                res += 9;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("IV");

            if (tmp != -1)
            {
                res += 4;
                s = s.Substring(0, tmp) + s.Substring(tmp + 2);
            }

            tmp = s.IndexOf("M");

            while (tmp != -1)
            {
                res += 1000;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("M");
            }

            tmp = s.IndexOf("D");

            while (tmp != -1)
            {
                res += 500;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("D");
            }

            tmp = s.IndexOf("C");

            while (tmp != -1)
            {
                res += 100;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("C");
            }

            tmp = s.IndexOf("L");

            while (tmp != -1)
            {
                res += 50;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("L");
            }

            tmp = s.IndexOf("X");

            while (tmp != -1)
            {
                res += 10;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("X");
            }

            tmp = s.IndexOf("V");

            while (tmp != -1)
            {
                res += 5;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("V");
            }

            tmp = s.IndexOf("I");

            while (tmp != -1)
            {
                res += 1;
                s = s.Substring(0, tmp) + s.Substring(tmp + 1);
                tmp = s.IndexOf("I");
            }

            if (s.Length != 0)
            {
                throw new Exception();
            }

            return res;
        }
    }
}
