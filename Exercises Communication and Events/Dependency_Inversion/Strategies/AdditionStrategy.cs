
using P03_DependencyInversion;

public class AdditionStrategy : ICalculateStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }
}

