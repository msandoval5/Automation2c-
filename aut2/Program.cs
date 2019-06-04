using System;

namespace aut2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestElements test = new TestElements("FireFox");
            test.Fill("Mariana");
            test.FillLastName("Sandoval");
            test.Fill(123);
           test.FillPass("12345");
            test.SelectMonth();
            test.SelectDay();
            test.SelectYear();
            test.CheckFemale();
            test.VerifyText();
            test.VerifyTitle();
            test.DriverTitle();
            test.CleanUp();
        }
    }
}
