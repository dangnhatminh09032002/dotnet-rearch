// namespace Minh.DependencyInjection
// {
//     namespace DirectDependency
//     {
//         class Class_C
//         {
//             private string _message;
//             public Class_C(string message) => _message = message;
//             public void ViewMessage()
//             {
//                 Console.ForegroundColor = ConsoleColor.Red;
//                 Console.WriteLine(_message);
//                 Console.ResetColor();
//             }
//         }

//         class Class_B
//         {
//             private Class_C _classC;
//             public Class_B(Class_C class_C) => _classC = class_C;
//             public void ViewMessage()
//             {
//                 _classC.ViewMessage();
//             }
//         }

//         class Class_A
//         {
//             private Class_B _classB;
//             public Class_A(Class_B class_B) => _classB = class_B;
//             public void ViewMessage()
//             {
//                 _classB.ViewMessage();
//             }
//         }

//         public static class DirectDependency
//         {
//             public static void Start()
//             {
//                 string message = "This is module direct dependency";

//                 Class_C instanceC = new Class_C(message);
//                 Class_B instanceB = new Class_B(instanceC);
//                 Class_A instanceA = new Class_A(instanceB);

//                 instanceA.ViewMessage();
//             }
//         }
//     }
// }

// Inverted Dependency
namespace Minh.DependencyInjection
{
    namespace InveredtDependency
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

        public class ClassD
        {
            private ClassA _classA;
            public ClassD(ClassA classA, string message)
            {
                _classA = classA;
                Console.WriteLine("message " + message);
            }
        }
    }
}