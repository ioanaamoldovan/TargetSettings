using System;
using RandomNameGenerator;

namespace LearnCSharp
{
    public class Person
    {
        public int ID = 0;
        public string Name = "";
        public int Age = 0;

        public Person(int id)
        {
            ID = id;

            Random rand = new Random();
            int age = rand.Next(10, 70);
            Age = age;
            string name = "";

            if (age % 2 == 0)
            {
                 name = NameGenerator.Generate(Gender.Female);
            }
            else
            {
                name = NameGenerator.Generate(Gender.Female);
            }

            Name = name;
        }
    }
}
