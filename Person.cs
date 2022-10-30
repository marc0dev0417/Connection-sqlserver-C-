using System;

namespace FundamentosSharp
{
    internal class Person
    {
        public int id = 3;
        public string name { get; set; }

    public Person(string name)
        {
            this.name = name; 
        }
    public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
