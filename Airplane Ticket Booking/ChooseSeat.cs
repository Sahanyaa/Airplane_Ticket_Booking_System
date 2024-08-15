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
    public partial class ChooseSeat : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["rootConnection"].ConnectionString;
        
        string[] checkboxes = { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4", "E1", "E2", "E3", "E4", "F1", "F2", "F3", "F4", "G1", "G2", "G3", "G4" };
        private string flightID;
        List<string> alreadyBooked = new List<string>();
        public ChooseSeat(String flightID)
        {
            InitializeComponent();
            this.flightID = flightID;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT seat FROM booked_seats WHERE flight = @Flight";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Flight", flightID);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string seat = reader.GetString("seat");
                        Console.WriteLine(seat);
                        alreadyBooked.Add(seat);

                        // Find the checkbox control based on the seat name and mark it as checked and disabled
                        CheckBox checkbox = Controls.Find(seat, true).FirstOrDefault() as CheckBox;
                        if (checkbox != null)
                        {
                            checkbox.Checked = true;
                            checkbox.Enabled = false;
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while retrieving booked seats: " + ex.Message);
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            List<string> selectedSeats = new List<string>();
            
            

            foreach (string checkboxName in checkboxes)
            {
                CheckBox checkbox = Controls.Find(checkboxName, true).FirstOrDefault() as CheckBox;

                if (checkbox != null && checkbox.Checked)
                {
                    if (!alreadyBooked.Contains(checkboxName))
                    {
                        selectedSeats.Add(checkboxName);
                    }
                }
            }

            if (selectedSeats.Count > 0)
            {
                string message = "Selected seats: " + string.Join(", ", selectedSeats);
                MessageBox.Show(message);
                CusDetails cusDetails = new CusDetails(flightID, selectedSeats);
                cusDetails.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Choose at least one");
            }

        }
    }
}
