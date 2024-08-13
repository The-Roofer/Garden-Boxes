using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace GardenBoxesWithDatabase
{
  internal class Program
  {
    const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HELLO\\Desktop\\AcademyPGH\\Git_Project\\garden-boxes\\GardenBoxesWithDatabase\\FarmerDB.mdf;Integrated Security=True";


    static Dictionary<string,double> LookupVegtable()
    {
      Dictionary<string,double> VeggieData = new Dictionary<string,double>();

      SqlConnection conn = new SqlConnection(connectionString);
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM VEGTABLES", conn);
      SqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
      {
        Console.WriteLine(reader["VegtableName"].ToString() + reader["VegtableRatio"].ToString());
        VeggieData.Add($"{reader["VegtableName"].ToString()}", Convert.ToDouble(reader["VegtableRatio"]));
      }
      reader.Close();
      conn.Close();

      return VeggieData;
    }


    static void AddVegtable()
    {
      string name = "";
      double ratio = 0.0;

      Console.Write("Enter the name of your vegtable:");
      name = Console.ReadLine();
      Console.Write("Enter the yeild rato");
      ratio = Convert.ToDouble(Console.ReadLine());

      SqlConnection conn = new SqlConnection(connectionString);
      conn.Open();
      SqlCommand cmd = new SqlCommand($"Insert into Vegtables (VegtableName,VegtableRatio) Values ('{name}','{ratio}')",conn);
      Console.WriteLine(cmd.ExecuteNonQuery()+" Rows Affected");
      conn.Close() ;
    }



    static void Main(string[] args)
    {
      double length = 0;
      double width = 0; 
      double perimeter = 0;
      double area = 0;

      int corn = 0;
      int beets = 0;
      int carrots = 0;


      Dictionary<string,double> veggieData = new Dictionary<string,double>();

      string response = "";
      
      veggieData = LookupVegtable();

      Console.WriteLine("Would you like to Add a Vegtable?");
      response = Console.ReadLine().ToLower();
      if (response[0] == 'y')
      {
        AddVegtable();
      }


      Console.WriteLine("Enter gardenbox length");
      length = Convert.ToDouble(Console.ReadLine());
      Console.WriteLine("Enter gardenbox width");
      width = Convert.ToDouble(Console.ReadLine());

      perimeter = CalcPerimeter(length, width);
      area = CalcArea(length, width);

      Console.WriteLine($"Your gardenbox has a perimeter of {perimeter} feet and a total area of {area} Sq Feet");


      carrots = Convert.ToInt32(veggieData["Carrots"]*area);

      corn = Convert.ToInt32(veggieData["Corn"] * area);

      beets = Convert.ToInt32(veggieData["Beets"] * area);

      Console.WriteLine($"Your garden can handle {carrots} carrots, {corn} corn, or {beets} beets");

  


    }


    static double CalcArea(double length, double width)
    {
      double area = 0;
      area = length * width;
      return area;
    }
    
    static double CalcPerimeter(double legnth, double width)
    {
      double perimeter = (width * 2) + (legnth*2);
      return perimeter;
    }


  }
}
