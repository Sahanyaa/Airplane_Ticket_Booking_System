using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Airplane_Ticket_Booking
{
    
    public partial class ThankYou : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["rootConnection"].ConnectionString;

        List<string> selectedSeats;
        
        String email = null;
        String name = null;
        String mobile = null;
        String seats = null;
        int count;
        String passportNo = null;
        String deptCityName = null;
        String destCityName = null;
        DateTime deptDate;
        DateTime destDate;
        decimal ticketPrice;
        decimal total;
        String flightId;
        
        public ThankYou(String flightId, String email, String name, String mobile, List<string> selectedSeats,int count, String passportNo, String deptCityName, String destCityName,
            DateTime deptDate, DateTime destDate, decimal ticketPrice, decimal total)
        {
            InitializeComponent();
            this.flightId = flightId;
            this.email = email;
            this.name = name;
            this.mobile = mobile;
            this.selectedSeats = selectedSeats;
            this.seats = string.Join(", ", selectedSeats);
            this.count = count;
            this.passportNo = passportNo;
            this.ticketPrice = ticketPrice;
            this.total = total;
            this.deptCityName = deptCityName;
            this.destCityName = destCityName;
            this.deptDate = deptDate.Date;
            this.destDate = destDate.Date;

            if (flightId != null &&
                email != null &&
                name != null &&
                 mobile != null &&
                seats != null &&
                passportNo != null &&
                ticketPrice != 0 &&
                total != 0 &&
                deptCityName != null &&
                destCityName != null &&
                deptDate != null &&
                destDate != null)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO booking (flight_id, name, email, no_of_passengers, total_price) " +
                                   "VALUES (@FlightId, @Name, @Email, @NoOfPassengers, @TotalPrice)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FlightId", flightId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@NoOfPassengers", count);
                    command.Parameters.AddWithValue("@TotalPrice", total);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Booking successfully inserted.");
                            sendEmail();
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert the booking.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while inserting the booking: " + ex.Message);
                    }

                    try
                    {
                       // connection.Open();

                        foreach (string seat in selectedSeats)
                        {
                            query = "INSERT INTO booked_seats (seat, flight) VALUES (@Seat, @Flight)";
                            command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Seat", seat);
                            command.Parameters.AddWithValue("@Flight", flightId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Seat {seat} for Flight {flightId} successfully booked.");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to book Seat {seat} for Flight {flightId}.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while booking the seats: " + ex.Message);
                    }

                }


            }

        }

        private void sendEmail()
        {
            string senderEmail = "srilankaairline45@gmail.com";
            string senderPassword = "umbxleebjnntmqfy";

            string recipientEmail = email;
            string subject = $"Flight Booking Confirmation - [{flightId}]";
            string body = $"Dear {name},\n\n" +
                   $"Thank you for booking your flight with us. Here are the details of your booking:\n\n" +
                   $"- Departure City: {deptCityName}\n" +
                   $"- Destination City: {destCityName}\n" +
                   $"- Departure Date: {deptDate}\n" +
                   $"- Destination Date: {destDate}\n" +
                   $"- Seat(s) Booked: {seats}\n" +
                   $"- Ticket Price: {ticketPrice:C2}\n" +
                   $"- Total Amount: {total:C2}\n\n" +
                   $"Please keep this email as a confirmation of your booking.\n\n" +
                   $"If you have any questions or need further assistance, feel free to contact us at 7xxxxxxxx or reply to this email.\n\n" +
                   $"Thank you for choosing our airline. We look forward to serving you.\n\n" +
                   $"Best regards,\n" +
                   $"Your Airline Team";

            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
                    smtpClient.Send(mailMessage);

                    Console.WriteLine("Email sent successfully.");
                    MessageBox.Show("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
                MessageBox.Show("An error occurred while sending the email");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmWelcome frmWelcome = new frmWelcome();
            frmWelcome.Show();
            this.Hide();
        }
    }


}
