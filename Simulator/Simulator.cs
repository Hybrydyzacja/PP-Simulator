namespace Simulator;

public class Simulator
{
    static void Main(string[] args)
    {
        {
            Console.WriteLine("Starting Simulator!\n");

        }


        {
            Lab5a();
        }

        static void Lab5a()
        {
            try
            {
                Console.WriteLine("Test 1: Tworzenie prostokąta ze współrzędnych");
                Rectangle rectangle1 = new Rectangle(2, 3, 5, 7);
                Console.WriteLine($"Stworzono prostokąt: {rectangle1}");
                Console.WriteLine($"Czy punkt (3, 4) znajduje się w prostokącie? {rectangle1.Contains(new Point(3, 4))}");  // True
                Console.WriteLine($"Czy punkt (6, 8) znajduje się w prostokącie? {rectangle1.Contains(new Point(6, 8))}");  // False


                Console.WriteLine("\nTest 2: Tworzenie prostokąta z punktów");
                Point p1 = new Point(1, 1);
                Point p2 = new Point(6, 6);
                Rectangle rectangle2 = new Rectangle(p1, p2);
                Console.WriteLine($"Stworzono prostokąt: {rectangle2}");
                Console.WriteLine($"Czy punkt (3, 3) znajduje się w prostokącie? {rectangle2.Contains(new Point(3, 3))}");  // True
                Console.WriteLine($"Czy punkt (7, 7) znajduje się w prostokącie? {rectangle2.Contains(new Point(7, 7))}");  // False


                Console.WriteLine("\nTest 3: Tworzenie prostokąta z uporządkowanymi wspołrzędnymi");
                Rectangle rectangle3 = new Rectangle(7, 6, 2, 3);  // Konieczna zmiana kolejnosci punktów
                Console.WriteLine($"Stworzono prostokąt z zamienionymi współrzędnymi: {rectangle3}");  // Oczekiwane: (2, 3):(7, 6)
                Console.WriteLine($"Czy punkt (3, 4) znajduje się w prostokącie? {rectangle3.Contains(new Point(3, 4))}");  // True
                Console.WriteLine($"Czy punkt (8, 8) znajduje się w prostokącie? {rectangle3.Contains(new Point(8, 8))}");  // False


                Console.WriteLine("\nTest 4: Próba stworzenia \"chudego\" prostokąta");
                try
                {
                    Rectangle invalidRect1 = new Rectangle(5, 5, 5, 10);  // Błąd
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");  // Oczekiwany wyjątek
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
