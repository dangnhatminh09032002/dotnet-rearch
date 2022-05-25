// Inverted Dependency
namespace Minh.DependencyInjection
{
    namespace InvertedDependency
    {
        public interface IClassC
        {
            public void Action();
        }

        public interface IClassB
        {
            public void Action();
        }

        public interface IClassA { }


        public class ClassC : IClassC
        {
            public void Action()
            {
                Console.WriteLine("This is class_C");
            }
        }

        public class ClassB : IClassB
        {
            private readonly IClassC _classC;

            public ClassB(IClassC class_C) => _classC = class_C;

            public void Action()
            {
                Console.WriteLine("This is class_B");
                _classC.Action();
            }
        }

        public class ClassA
        {
            private readonly IClassB _classB;

            public ClassA(IClassB class_B) => _classB = class_B;

            public void Action()
            {
                Console.WriteLine("This is class_A");
                _classB.Action();
            }
        }
    }
}