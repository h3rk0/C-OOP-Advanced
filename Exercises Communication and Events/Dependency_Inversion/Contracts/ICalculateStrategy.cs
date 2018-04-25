namespace P03_DependencyInversion
{
	public interface ICalculateStrategy
	{
		int Calculate(int firstOperand, int secondOperand);
	}
}