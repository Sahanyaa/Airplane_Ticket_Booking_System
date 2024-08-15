using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplane_Ticket_Booking
{
    public partial class ChooseFlight : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["rootConnection"].ConnectionString;
        public ChooseFlight()
        {
            InitializeComponent();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id,short_code FROM city";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int flightId = Convert.ToInt32(reader["id"]);
                        string shortCode = reader["short_code"].ToString();
                        cmbDeptCity.Items.Add(new ComboBoxItem(shortCode, flightId));
                        cmbDestCity.Items.Add(new ComboBoxItem(shortCode, flightId));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedItemDept = (ComboBoxItem)cmbDeptCity.SelectedItem;
            int selectedFlightIdDept = selectedItemDept.FlightId;

            ComboBoxItem selectedItemDest = (ComboBoxItem)cmbDestCity.SelectedItem;
            int selectedFlightIdDest = selectedItemDest.FlightId;

            DateTime selectedDate = dtpDeptDate.Value.Date;

            try
            {
                string query = "SELECT * FROM Flights WHERE dept_city = @deptCity AND dest_city = @destCity AND dept_date = @deptDate";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@deptCity", selectedFlightIdDept);
                    command.Parameters.AddWithValue("@destCity", selectedFlightIdDest);
                    command.Parameters.AddWithValue("@deptDate", selectedDate);

                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable flightsTable = new DataTable();
                    adapter.Fill(flightsTable);

                    dgvResult.DataSource = flightsTable;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            // String flightID = dgvResult.SelectedRows[0].Cells[0].Value.ToString();
            String flightID = txtFlightID.Text;
            ChooseSeat chooseSeat = new ChooseSeat(flightID);
            chooseSeat.Show();
            this.Hide();
        }
    }
}
