using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                System.Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT AUDIS)
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                System.Console.WriteLine(audi);
            }
        }

        //Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiplied by 3
            // Take all numbers, but 9 
            // Orders numbers by ascending value

            var processedNumberList =
                numbers.
                    Select(num => num * 3). // 3,6,9 etc..
                    Where(num => num != 9). // all but the 9
                    OrderBy(num => num); //at the end we order ascending

        }

        static public void SearchExamples()
        {
            List<String> textList = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //1. First of all elements 
            var first = textList.First();

            //2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            //4. First element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));
            // "" or first element that contains "z"

            //5. Last element that contains "z" or default
            var lasttOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));
            // "" or last element that contains "z"

            //6. Single Values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumbers = { 0, 2, 6 };

            // Obtain { 4 , 8 }
            var myEvenNumbers = evenNumbers.Except(otherNumbers); // { 4 , 8 }
        }

        static public void MultipliedSelect()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, Text 1",
                "Opinion 2, Text 2",
                "Opinion 3, Text 3",
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(','));

            var enterprises = new[]{
                new Enterprise(){
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Miguel",
                            Email = "miguel@test.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@test.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@test.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise(){
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Maria",
                            Email = "maria@test.com",
                            Salary = 1400
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Julio",
                            Email = "julio@test.com",
                            Salary = 2344
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Moises",
                            Email = "moises@test.com",
                            Salary = 1800
                        }
                    }
                }
            };

            //Obtain all Employees of All Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises al least employees with at least 1000€ of salary
            bool hasEmployeesWithSalaryMoreThan1000 =
                enterprises.Any(enterprises =>
                    enterprises.Employees.Any(employee => employee.Salary > 1000));
        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
            );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, secondElement = secondElement };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // SKIP
            var skipTwoFirstValues = myList.Skip(2); // { 3,4,5,6,7,8,9,10 };
            var skipTwoLastValues = myList.SkipLast(2); // { 1,2,3,4,5,6,7,8 };
            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // { 5,6,7,8,9,10 };

            //TAKE
            var takeTwoFirstValues = myList.Take(2); // { 1,2 }
            var takeTwoLastValues = myList.TakeLast(2); // { 9,10 };
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // { 1,2,3 };

        }

        //Paging with Skip & Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        //Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            System.Console.WriteLine("Average : {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: Number : {0} Square: {1}", number, Math.Pow(number, 2));
            }
        }

        //ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // ("1=one","2=two","3=three","4=four","5=five")
        }

        //Repeat & Range
        static public void RepeatRangeLinq()
        {
            //Generate collection from 1 to 1000 --> RANGE
            IEnumerable<int> first100 = Enumerable.Range(1, 1000);

            // var aboveAverage = from number in first100
            //                    select number;

            //Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // { "X","X","X","X","X" }
        }

        static public void StudentsLinq()
        {
            var classRoom = new[]{
                new Student{
                    Id = 1,
                    Name = "Miguel",
                    Grade = 90,
                    Certified = true,
                },
                new Student{
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student{
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                 new Student{
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                 new Student{
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var approvedStudents = from student in classRoom
                                   where student.Grade >= 50 && student.Certified
                                   select student;

            var approvedStudentsName = from student in classRoom
                                       where student.Grade >= 50 && student.Certified
                                       select student.Name;
        }

        //ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqueal2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        //Aggregate
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 3 => 6
            // etc...

            string[] words = { "hello,", "my", "name", "is", "Miguel" }; // hello, my name is Miguel
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            // "", "hello,"
            // "hello,", "my,"
            // "hello, my", "name"
            // etc...
        }

        //Distinc
        static public void DistincValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        //GroupBy
        static public void GroupByExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Obtanin only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            //We will have two groups:
            //1. The group that doesnt fit the condition (Odd numbers)
            //2. The group that fits the condition (Even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2,4,6,8 (first the odds and then the even)
                }
            }

            //Another Example
            var classRoom = new[]{
                new Student{
                    Id = 1,
                    Name = "Miguel",
                    Grade = 90,
                    Certified = true,
                },
                new Student{
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student{
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                 new Student{
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false,
                },
                 new Student{
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified && student.Grade >= 50);

            //We obtain two groups 
            // 1º Not certified students
            // 2º Certified students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("----------- {0} ---------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }
}
