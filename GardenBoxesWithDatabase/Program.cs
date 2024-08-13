namespace GardenBoxesWithDatabase
{
  internal class Program
  {
    static void Main(string[] args)
    {
      double length = 0;
      double width = 0; 
      double perimeter = 0;
      double area = 0;

      int corn = 0;
      int beets = 0;
      int carrots = 0;


      Console.WriteLine("Enter gardenbox length");
      length = Convert.ToDouble(Console.ReadLine());
      Console.WriteLine("Enter gardenbox width");
      width = Convert.ToDouble(Console.ReadLine());

      perimeter = CalcPerimeter(length, width);
      area = CalcArea(length, width);

      Console.WriteLine($"Your gardenbox has a perimeter of {perimeter} feet and a total area of {area} Sq Feet");

      carrots = Convert.ToInt32(Math.Floor(area));

      corn = Convert.ToInt32(Math.Floor(area)*(3.0/16));

      beets = Convert.ToInt32(Math.Floor(area) * (9.0 / 16));

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
