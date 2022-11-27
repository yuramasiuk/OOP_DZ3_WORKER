
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Write the name of the team: ");
        Team t = new Team(Console.ReadLine());
        string chooose;


        do
        {
            Console.WriteLine("Write your position:");
            if (Console.ReadLine() == "Developer")
            {
                Console.WriteLine("Write your name: ");
                Developer developer = new Developer(Console.ReadLine());
                Console.WriteLine("Write your work day: ");
                developer.WorkDay = Convert.ToInt32(Console.ReadLine());
                t.NewMember(developer);

            }
            else
            {
                Console.WriteLine("Write your name: ");
                Manager manager = new Manager(Console.ReadLine());
                Console.WriteLine("Write your work day: ");
                manager.WorkDay = Convert.ToInt32(Console.ReadLine());
                t.NewMember(manager);
            }
            Console.WriteLine("You wanna to add sb (yes/no): ");
            chooose = Console.ReadLine();
        } while (chooose != "no");
        //t.ShowOurTeam();
        t.ShowOnDetail();
    }
}
public abstract class Worker
{

    public string Name;

    public string Position;

    public int WorkDay;
    public Worker(string name) //k
    {
        Name = name;
    }


    public void Call()   //m
    {
    }
    public void WriteCode()
    {
    }
    public void Relax()
    {
    }
    public abstract void FillWorkDay();

}

public class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Developer";

    }
    public override void FillWorkDay() //perevuzn
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}
public class Manager : Worker
{
    private Random rnd;

    public Manager(string name) : base(name)
    {
        Position = "Manager";
    }

    public override void FillWorkDay()
    {
        rnd = new Random();
        for (int i = 0; i < rnd.Next(1, 10); i++)
        {
            Call();
        }
        for (int i = 0; i < rnd.Next(1, 10); i++)
        {
            Relax();
        }
        for (int i = 0; i < rnd.Next(1, 5); i++)
        {
            Call();
        }
    }

}
public class Team
{
    public string Name;

    private List<Worker> lst = new List<Worker>();



    public Team(string name)
    {
        Name = name;

    }

    public void NewMember(Worker worker)
    {
        lst.Add(worker);
    }
    //public void ShowOurTeam()
    //{
    //    Console.WriteLine($"Name team: {Name} ");
    //    foreach (var item in lst)
    //    {
    //        Console.WriteLine(item.Name);
    //    }
    //}


    public void ShowOnDetail()
    {
        Console.WriteLine($"Team name: {Name} ");
        foreach (var item in lst)
        {
            Console.WriteLine($"Name: {item.Name}- Position: {item.Position}- WorkDay: {item.WorkDay}");
        }
    }
}