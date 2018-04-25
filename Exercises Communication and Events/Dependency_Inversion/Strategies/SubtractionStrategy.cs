
using P03_DependencyInversion;

public class SubtractionStrategy : ICalculateStrategy 
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand - secondOperand;
    }
}

