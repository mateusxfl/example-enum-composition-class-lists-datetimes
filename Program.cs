using ExercicioEnum.Entities;
using ExercicioEnum.Entities.Enums;

Console.Clear();

Console.Write("Enter department's name: ");
string departmentName = Console.ReadLine();

var Department = new Department
{
    Name = departmentName
};

// -------------------------------------------------------------

Console.Clear();

Console.WriteLine("Enter worker data:\n");

Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Level (Junior/MidLevel/Senior): ");
var level = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base salary: ");
double baseSalary = double.Parse(Console.ReadLine());

var Worker = new Worker
{
    Name = name,
    Level = level,
    BaseSalary = baseSalary,
    Department = Department,
};

// -------------------------------------------------------------

Console.Clear();

Console.Write("How to many contracts to this worker? ");
int numberOfContracts = int.Parse(Console.ReadLine());

for (int i = 1; i <= numberOfContracts; i++)
{
    Console.Clear();

    Console.WriteLine($"\nEnter #{i} contract data:\n");

    Console.Write($"Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write($"Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine());

    Console.Write($"Duration (hours): ");
    int duration = int.Parse(Console.ReadLine());

    var HourContract = new HourContract
    {
        Date = date,
        Hours = duration,
        ValuePerHour = valuePerHour,
    };

    Worker.AddContract(HourContract);
}


// -------------------------------------------------------------

Console.Clear();

Console.Write("Enter month and year to calculate income (MM/YYYY): ");
var data = Console.ReadLine().Split("/");

Console.WriteLine($"\nName: {Worker.Name}");
Console.WriteLine($"Department: {Worker.Department.Name}");

Console.WriteLine($"Income for {data[0]}/{data[1]}: {Worker.Income(int.Parse(data[0]), int.Parse(data[1]))}\n");

Console.ReadKey();