using System;

namespace ClassBoxDataValidation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(lenght, width, height);

                Console.WriteLine(box.GetSurfaceArea(box));
                Console.WriteLine(box.GetLateralSurfaceArea(box));
                Console.WriteLine(box.GetVolume(box));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}