using System.Reflection;
using MINH.Common.Attribute;

// ObsoleteAttribute => Canh bao attr da bi loi thoi

class Program
{
    // Type -> class, struct, int, string,...
    #region Class User
    [MyAttr("Xin chao moi nguoi", Author = "This is Minh")]
    public class User
    {
        static int _count = 0;
        private int _id = _count++;
        public int Id => _id;
        [MyAttr("Xin chao moi nguoi", Author = "This is attr Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public void ViewDetails()
        {
            // Map qua các thuộc tính có sẵn
            var properties = this.GetType().GetProperties();
            Console.WriteLine("-- Propertie of this --");
            foreach (PropertyInfo propertie in properties)
            {
                // propertie.GetCustomAttributes(false); // Mỗi lần gọi sẽ là mội lần khởi tạo nên sẽ gọi constructor mỗi lần gọi hàm này
                string propertieName = propertie.Name;
                var propertieValue = propertie.GetValue(this);
                Console.WriteLine($"{propertieName} = {propertieValue}");
            }

            // Map qua thuoc tinh duoc custom
            Console.WriteLine("-- PropertieCustom of this --");
            var propertiesCustom = this.GetType().GetCustomAttributes(false); // Constructor sẽ được gọi tại thời điểm này
            foreach (var propertie in propertiesCustom)
            {
                MyAttrAttribute myAttr = propertie as MyAttrAttribute;
                if (myAttr != null)
                {
                    Console.WriteLine($"{nameof(myAttr.Author)} = {myAttr.Author}");
                }
            }
        }
    }
    #endregion
    static void Main(string[] args)
    {
        User minh = new User()
        {
            Name = "minh",
            Age = 20,
            Email = "minh@gmail.com",
        };
        minh.ViewDetails();
    }
}