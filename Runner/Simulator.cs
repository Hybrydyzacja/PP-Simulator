using Simulator.Maps;

namespace Simulator;

public class Simulator
{
    static void Main(string[] args)
    {
        {
            Console.WriteLine("Starting Simulator!\n");

        }


        {
            //Lab5a();
            Lab5b();
        }

        //static void Lab5a()
        //{
        //    try
        //    {
        //        Console.WriteLine("Test 1: Tworzenie prostokąta ze współrzędnych");
        //        Rectangle rectangle1 = new Rectangle(2, 3, 5, 7);
        //        Console.WriteLine($"Stworzono prostokąt: {rectangle1}");
        //        Console.WriteLine($"Czy punkt (3, 4) znajduje się w prostokącie? {rectangle1.Contains(new Point(3, 4))}");  // True
        //        Console.WriteLine($"Czy punkt (6, 8) znajduje się w prostokącie? {rectangle1.Contains(new Point(6, 8))}");  // False


        //        Console.WriteLine("\nTest 2: Tworzenie prostokąta z punktów");
        //        Point p1 = new Point(1, 1);
        //        Point p2 = new Point(6, 6);
        //        Rectangle rectangle2 = new Rectangle(p1, p2);
        //        Console.WriteLine($"Stworzono prostokąt: {rectangle2}");
        //        Console.WriteLine($"Czy punkt (3, 3) znajduje się w prostokącie? {rectangle2.Contains(new Point(3, 3))}");  // True
        //        Console.WriteLine($"Czy punkt (7, 7) znajduje się w prostokącie? {rectangle2.Contains(new Point(7, 7))}");  // False


        //        Console.WriteLine("\nTest 3: Tworzenie prostokąta z uporządkowanymi wspołrzędnymi");
        //        Rectangle rectangle3 = new Rectangle(7, 6, 2, 3);  // Konieczna zmiana kolejnosci punktów
        //        Console.WriteLine($"Stworzono prostokąt z zamienionymi współrzędnymi: {rectangle3}");  // Oczekiwane: (2, 3):(7, 6)
        //        Console.WriteLine($"Czy punkt (3, 4) znajduje się w prostokącie? {rectangle3.Contains(new Point(3, 4))}");  // True
        //        Console.WriteLine($"Czy punkt (8, 8) znajduje się w prostokącie? {rectangle3.Contains(new Point(8, 8))}");  // False


        //        Console.WriteLine("\nTest 4: Próba stworzenia \"chudego\" prostokąta");
        //        try
        //        {
        //            Rectangle invalidRect1 = new Rectangle(5, 5, 5, 10);  // Błąd
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            Console.WriteLine($"{ex.Message}");  // Oczekiwany wyjątek
        //        }

                
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"{ex.Message}");
        //    }
        //}

        static void Lab5b()
        {
            try
            {
                var map = new SmallSquareMap(10);
                Console.WriteLine($"Map size: {map.Size}");

                var point1 = new Point(5, 5);
                var point2 = new Point(5, 10);
                var point3 = new Point(10, 5);
                var point4 = new Point(10, 10);
                var point5 = new Point(1, 1);
                Console.WriteLine($"Point {point1} is in the map: {map.Exist(point1)}");
                Console.WriteLine($"Point {point2} is in the map: {map.Exist(point2)}");
                Console.WriteLine($"Point {point3} is in the map: {map.Exist(point3)}");
                Console.WriteLine($"Point {point4} is in the map: {map.Exist(point4)}");
                Console.WriteLine($"Point {point5} is in the map: {map.Exist(point5)}");

                var startPoint = new Point(6, 5);
                var nextPoint = map.Next(startPoint, Direction.Left);
                Console.WriteLine($"Start point: {startPoint}, Next point: {nextPoint}");
                var nextPoint2 = map.Next(startPoint, Direction.Right);
                Console.WriteLine($"Start point: {startPoint}, Next point: {nextPoint2}");
                var nextPoint3 = map.Next(startPoint, Direction.Up);
                Console.WriteLine($"Start point: {startPoint}, Next point: {nextPoint3}");

                var diagonalPoint = map.NextDiagonal(startPoint, Direction.Up);
                Console.WriteLine($"Diagonal point: {diagonalPoint}");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
    }
}
