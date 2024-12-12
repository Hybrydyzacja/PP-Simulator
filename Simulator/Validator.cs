
namespace Simulator;

public class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        var valueTrimmed = value.Trim();


        if (valueTrimmed.Length > max)
        {
            valueTrimmed = valueTrimmed.Substring(0, max);
            valueTrimmed = valueTrimmed.Trim(); // sprawdzenie czy po obcięciu do max lenght na końcu zmiennej nie zostały spacje
        }
        if (valueTrimmed.Length < min)
        {
            valueTrimmed = valueTrimmed.PadRight(min, placeholder);
        }
        if (!char.IsUpper(valueTrimmed[0]))
        {
            valueTrimmed = char.ToUpper(valueTrimmed[0]) + valueTrimmed.Substring(1);
        }
      
        return valueTrimmed;
    }
}

