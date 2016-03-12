using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agetest
{


    public class Age
    {
        public int Years;
        public int Months;
        public int Days;

        public Age(DateTime Bday, DateTime Cday) // constructor 2-- birthdate , currentdate
        {
            this.Count(Bday, Cday);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
               (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                 ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                TimeSpan difference = Cday.Subtract(Bday);
                
                
                // This is to convert the timespan to datetime object
                DateTime age = DateTime.MinValue + difference;
                
                

                this.Years = age.Year-1 ;
                this.Months = age.Month-1;
                this.Days = age.Day-1;
            }
            else 
            {
                throw new FormatException("Birthday date must be earlier than current date");
            }
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Age[] objAge = new Age[10];
            int noSiblings;
            string message;

            Restart: //restarting on exception
            do
            {
                Console.Write("Enter number of your siblings : ");
            
                    noSiblings = int.Parse(Console.ReadLine());
                 if (noSiblings <= 0 ) { Console.WriteLine("Negative value not allowed please provide Positive number"); }
                
            } while (noSiblings<=0);
               
               
            Console.WriteLine("-----------------------------------------------------------------------");
            for (int i = 0; i < noSiblings; i++)
            {
                try
                {

                    Console.Write("\nPlease enter date of birth of sibling in format of MM/DD/YYYY " + (i + 1) + " : ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    objAge[i] = new Age(birthDate, DateTime.Today);
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                    
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------");

             //printing age of siblings
            for (int i = 0; i < noSiblings; i++)
            {
                try
                {
                message = "Age of Sibling " + (i + 1) + " is " + (objAge[i].Years) + " years  " + (objAge[i].Months) + " months " + (objAge[i].Days) + "Days";
                Console.WriteLine(message);
                }
                catch (NullReferenceException e)
                {

                    Console.WriteLine(e.Message);
                   
                    goto Restart; // gtng restart
                   
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            //difference
            for (int i = 0; i < noSiblings - 1; i++)
            {
                if (objAge[i].Days < objAge[i + 1].Days)
                {
                    objAge[i].Months = objAge[i].Months - 1;
                    objAge[i].Days = objAge[i].Days + 30;
                }
                if (objAge[i].Months < objAge[i + 1].Months)
                {
                    objAge[i].Years--;
                    objAge[i].Months = objAge[i].Months + 12;
                }
                message = "Difference between sibling " + (i + 1) + " and " + (i + 2) + " is ";
                message += (objAge[i].Years - objAge[i+1].Years) + " years  " + (objAge[i].Months - objAge[i+1].Months) + 
                    " months " + (objAge[i].Days - objAge[i+1].Days) + " Days ";
                Console.WriteLine(message);
            }

            Console.ReadLine();

        }
    }
}
