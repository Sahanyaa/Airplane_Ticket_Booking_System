using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplane_Ticket_Booking
{
    public partial class CusDetails : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["rootConnection"].ConnectionString;
        
        String flightID;
        List<string> selectedSeats;
        decimal price;
        string deptCityName;
        string destCityName;
        DateTime deptDate;
        DateTime destDate;
        decimal ticketPrice;

        int count;
        public CusDetails(String flightID, List<string> selectedSeats)
        {
            InitializeComponent();
            this.flightID = flightID;
            this.selectedSeats = selectedSeats;
            txtFlightID.Text = flightID;
            txtSeats.Text = string.Join(", ", selectedSeats);


            //count seats
            count = selectedSeats.Count;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Flights.id, City1.name AS dept_city_name, City2.name AS dest_city_name, dept_date, dest_date, ticket_price " +
                               "FROM Flights " +
                               "JOIN City AS City1 ON Flights.dept_city = City1.id " +
                               "JOIN City AS City2 ON Flights.dest_city = City2.id " +
                               "WHERE Flights.id = @flightID";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@flightID", flightID);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int flightId = Convert.ToInt32(reader["id"]);
                        deptCityName = reader["dept_city_name"].ToString();
                        destCityName = reader["dest_city_name"].ToString();
                        deptDate = Convert.ToDateTime(reader["dept_date"]);
                        destDate = Convert.ToDateTime(reader["dest_date"]);
                        ticketPrice = Convert.ToDecimal(reader["ticket_price"]);

                        price = ticketPrice * count;


                        //string message = $"Flight ID: {flightId}\n" +
                        //                 $"Departure City: {deptCityName}\n" +
                        //                 $"Destination City: {destCityName}\n" +
                        //                 $"Departure Date: {deptDate}\n" +
                        //                 $"Destination Date: {destDate}\n" +
                        //                 $"Ticket Price: {ticketPrice:C2}"+
                        //                 $"Total Price: {price:C2}";
                        

                        //MessageBox.Show(message);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    MessageBox.Show(ex.Message);
                }
                
            }

            txtFlightID.Enabled = false;
            txtSeats.Enabled = false;
            lblTotal.Text = price.ToString() + " LKR";

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            String Email = txtEmail.Text;
            String Name = txtName.Text;
            String Mobile = txtMobile.Text;
            String PassportNo = txtPassportNo.Text;

            ThankYou thankYou = new ThankYou(flightID, Email, Name, Mobile, selectedSeats, selectedSeats.Count, PassportNo, deptCityName, destCityName, deptDate, destDate, ticketPrice, price);
            thankYou.Show();
            this.Hide();
        }
    }
}
