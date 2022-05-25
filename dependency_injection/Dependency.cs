namespace Minh.DependencyInjection
{
    namespace DirectDependency
    {
        class Class_C
        {
            private string _message;
            public Class_C(string message) => _message = message;
            public void ViewMessage()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_message);
                Console.ResetColor();
            }
        }

        class Class_B
        {
            private Class_C _classC;
            public Class_B(Class_C class_C) => _classC = class_C;
            public void ViewMessage()
            {
                _classC.ViewMessage();
            }
        }

        class Class_A
        {
            private Class_B _classB;
            public Class_A(Class_B class_B) => _classB = class_B;
            public void ViewMessage()
            {
                _classB.ViewMessage();
            }
        }

        public static class DirectDependency
        {
            public static void Start()
            {
                string message = "This is module direct dependency";

                Class_C instanceC = new Class_C(message);
                Class_B instanceB = new Class_B(instanceC);
                Class_A instanceA = new Class_A(instanceB);

                instanceA.ViewMessage();
            }
        }
    }
}

// Inverted Dependency
namespace Minh.DependencyInjection
{
    namespace InveredtDependency
    {
        public interface IClassC
        {
            public void ActionC();
        }

        public interface IClassB
        {
            public void ActionB();
        }


        public class Class_C : IClassC
        {
            public void ActionC()
            {
                Console.WriteLine("This is class_C");
            }
        }

        public class Class_B : IClassB
        {
            private readonly IClassC _classC;

            public Class_B(IClassC class_C) => _classC = class_C;

            public void ActionB()
            {
                Console.WriteLine("This is class_B");
                _classC.ActionC();
            }
        }

        public class Class_A
        {
            private readonly IClassB _classB;

            public Class_A(Class_B class_B) => _classB = class_B;

            public void Action()
            {
                Console.WriteLine("This is class_A");
                _classB.ActionB();
            }
        }
        public static class InvertedDependency
        {
            //....
        }
    }
}