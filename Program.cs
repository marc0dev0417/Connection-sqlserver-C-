
using FundamentosSharp;

class Test
{
    static public void Main()
    {
        
        Db db = new Db();

        db.deletePersonByName("Benegas");

        foreach (var person in db.getPersons())
        {
            Console.WriteLine(person.name);
        }
    }
}