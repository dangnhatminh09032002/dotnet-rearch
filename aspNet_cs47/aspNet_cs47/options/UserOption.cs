namespace aspNet_cs47.options
{
    public class UserOption
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        /*
         Nếu dùng hàm contructor thì không thể khởi tạo ở Select().Get() được (chưa rõ lí do)
         */
    }
}
