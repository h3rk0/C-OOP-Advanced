namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
		private ICalculateStrategy strategy;

        public PrimitiveCalculator(ICalculateStrategy strategy)
        {
			this.strategy = strategy;
        }

        public void ChangeStrategy(char @operator)
        {
			ICalculateStrategy strategy = null;
            switch (@operator)
			{
				case '+':
					strategy = new AdditionStrategy();
					break;
				case '-':
					strategy = new SubtractionStrategy();
					break;
				case '/':
					strategy = new DivisionStrategy();
					break;
				case '*':
					strategy = new MultiplicationStrategy();
					break;
			}

			this.strategy = strategy;
			
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
			return strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
