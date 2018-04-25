using System;

namespace Work_Force
{
    class StartUp
    {
        static void Main(string[] args)
        {
			Engine engine = new Engine(new JobsApi());
			engine.Run();
        }
    }
}
