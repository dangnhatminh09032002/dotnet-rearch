using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Minh.Cs37
{
    public class Program
    {
        public static void ShowDataTable(DataTable table)
        {
            Console.WriteLine("Table {0}", table.TableName);
            foreach (DataColumn column in table.Columns)
            {
            }
            Console.WriteLine("");

            int cols_count = table.Columns.Count;
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("----------------");
                for (int i = 0; i < cols_count; i++)
                {
                    Console.WriteLine($"{table.Columns[i].ColumnName} - {row[i]}");
                }
            }
        }

        public static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()); // Cần có Microsoft.Extensions.Configuration.Json để dùng module này;
            configurationBuilder.AddJsonFile("config.json");
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            string connectionString = configurationRoot["Database:SqlServer:ConnectString:HangfireConnection"];

            //Connect to database
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // DataSet dataset = new DataSet();
            // DataTable persionTable = new DataTable("persion");
            // persionTable.Columns.Add("id");
            // persionTable.Columns.Add("name");
            // persionTable.Columns.Add("age");
            // persionTable.Rows.Add(0, "Dang Nhat Minh", 25);
            // persionTable.Rows.Add(1, "Tran Quynh Chi", 22);
            // dataset.Tables.Add(persionTable);
            // ShowDataTable(persionTable)

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "persion");

            adapter.SelectCommand = new SqlCommand("SELECT * FROM persion  WHERE id > 1000", connection);
            // Nếu không có thì không thể gọi update khi gọi table.Rows.Add() => nghĩa là muốn add và update (nó sẽ tự check nếu có mới thì sẽ tự gọi insert nên phải có adapter.insert), điều này tương tự nếu delete, update, update, một row
            adapter.InsertCommand = new SqlCommand("INSERT INTO persion (name, age) VALUES (@Name, @Age)", connection);
            adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "name");
            adapter.InsertCommand.Parameters.Add("@Age", SqlDbType.Int, -1, "age");
            adapter.DeleteCommand = new SqlCommand("DELETE FROM persion WHERE id = @Id", connection);
            adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, -1, "id"); // Nó sẽ lấy cái id ở của row bên dưới xong bỏ vào đây, rồi hàm command sẽ xóa những cái có id tương tự
            adapter.UpdateCommand = new SqlCommand("UPDATE persion SET name = @Name, age = @Age WHERE id = @Id", connection);
            adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, -1, "id");
            adapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "name");
            adapter.UpdateCommand.Parameters.Add("@Age", SqlDbType.Int, -1, "age");
            DataSet dataset = new DataSet();
            adapter.Fill(dataset); // Truyền dữ liệu vào dataset
            // Khi dữ liệu đã truyền vào dataset ta có thể chỉnh sửa dữ liệu trong dataset xong đó gửi lạ (Update, Insert, ...) lên database

            DataTable persionTable = dataset.Tables["persion"]; // Get data
            ShowDataTable(persionTable);
            // Create new row
            // var row = persionTable.Rows.Add();
            // row["name"] = "Linh Chi";
            // row["age"] = 21;
            // adapter.Update(dataset);

            // Delete row
            // DataRow rowWillDelete = persionTable.Rows[0]; // 
            // if (rowWillDelete != null) rowWillDelete.Delete();
            // adapter.Update(dataset);

            // Update row
            // DataRow rowWillUpdate = persionTable.Rows[0];
            // rowWillUpdate["name"] = "Tran Linh Chi";
            // rowWillUpdate["age"] = 23;
            // adapter.Update(dataset);

            connection.Close();
        }
    }
}