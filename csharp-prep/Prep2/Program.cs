using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int intput = int.Parse(input);
        // The following commented out portion works, but isn't cool enough
        // int[] letter_grades = [90, 80, 70, 60];
        // char[] grade_letters = ['A', 'B', 'C', 'D'];
        // char letter = 'F';
        // for (int i = 0; i < 4; i++)
        // {
        //     if (intput >= letter_grades[i])
        //     {
        //         letter = grade_letters[i];
        //         break;
        //     }
        // }
        /*
                           Condition that ensures the math applies only for all non 'F' grades
                           |                       Conversion from grade number into uppercase letter index (handles extra credit)
                           |                       |                        The starting index for uppercase letters
                           |                       |                        ||   'F' as default 
                    |------|---|           |-------|-------------------|    ||   |-|              */                 
        string l = (intput >= 60 ? (char)((Math.Max(99 - intput, 0) / 10) + 65) :'F').ToString();

        /*             |--<(+/-) if in range>--|    |----<plus grade>----|  |---<minus grade>---| |---|-<letter only otherwise  */
        string grade = (intput>=60 && intput<95) ? ((intput%10>=7)?(l+'+'):((intput%10<3)?(l+'-'):l)):l;
        Console.WriteLine($"Your grade is {grade}");
    }
}