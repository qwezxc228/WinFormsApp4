using System.Data.SqlClient;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        List<Detail> details;
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            details = new();
            connection = new("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nadyb\\source\\repos\\WinFormsApp4\\WinFormsApp4\\Database1.mdf;Integrated Security=True");
        connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand command = new(
                "select * from Details",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                details.Add(
                    new(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["detail"]),
                        Convert.ToInt32(reader["price"])
                        )
                    );
            }
                reader.Close();
            var commannd1 = from detail1 in details
                            where detail1.price
                            select detail1;
            details= commannd1.ToList();
                string text = "";
                foreach (var item in details)
               listView1.Items.Add($"{item.id}{item.detail}{item.price}\n");

            
        }
    }
    public class Detail(int id, string detail,int price)

    {
        public int id { get; set; } = id;
        public string detail { get; set; } = detail;

        public int price { get; set; } = price;

    }
}
