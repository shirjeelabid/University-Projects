using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airline_MS
{
    public partial class View : Form
    {
        string Get="";
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public View(string n)
        {
            Connection c = new Connection();
            InitializeComponent();
            Get = n;
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {

            if(Get=="PASSENGERS")
            {
                cmd = new SqlCommand("select P.*,S.Name as [State Name],C.Name [Country Name] from PASSENGER P,STATE S, COUNTRY C where P.StateID=S.StateID and S.CountryID=C.CountryID", cn);
            }
            else if (Get=="Employee")
            {
                cmd = new SqlCommand("select E.Emp_ID,E.Name,E.Password,E.Salary,E.Designation,E.Address,E.Email,E.PhoneNumber,B.BranchID,B.Name as [Branch Name] from EMPLOYEE E, Branch B where E.BranchID=B.BranchID  ", cn);
            }
            else if(Get=="[FLIGHT SCHEDULE]")
            {
                cmd = new SqlCommand("Select FS.FlightID as [Filght ID], FS.Flight_Date, FS.Departure,FS.DepartureTime, FS.Arrival,FS.ArrivalTime,A.Service_Charges as [Service Charges],A.Fule_Charges [Fuel Charges],R.Airport,AF.AircraftID as [Aircraft ID] from [FLIGHT SCHEDULE] FS, AIRFARE A, ROUTE R, AIRCRAFT AF where FS.AirfareID=A.AirfareID and A.RouteID=R.RouteID and FS.AircraftID=AF.AircraftID", cn);                    
            }
            else if (Get == "AIRCRAFTS")
            {
                cmd = new SqlCommand("Select * from AIRCRAFT", cn);
            }
            else if (Get == "TRANSACTIONS")
            {
                cmd = new SqlCommand("Select T.TransactionID as [Transaction ID], T.BookingDate, T.DepartureDate, T.FlightID as [Flight ID],T.PassengerID as [Passenger ID], T.Tickets, T.Tickets*C.Amount as [Total Charges],C.description as [Charges Description], T.Type, T.EmployeeID as [Employee ID] from TRANSACTIONS T, CHARGES C where T.ChargesID=C.ChargesID and T.FlightID=C.FlightID", cn);
            }
            else if (Get == "Branches")
            {
                cmd = new SqlCommand("Select B.BranchID,B.Name as [Branch Name], B.Address, S.Name as [State Name], C.Name as [Country Name] from Branch B, COUNTRY C, STATE S where B.StateID=S.StateID and S.CountryID=C.CountryID", cn);
            }
            else if (Get == "FS")
            {
                cmd = new SqlCommand("Select FS.FlightID as [Filght ID], FS.Flight_Date, FS.Departure,FS.DepartureTime, FS.Arrival,FS.ArrivalTime,R.Airport,AF.AircraftID from [FLIGHT SCHEDULE] FS, AIRFARE A, ROUTE R, AIRCRAFT AF where FS.AirfareID=A.AirfareID and A.RouteID=R.RouteID and FS.AircraftID=AF.AircraftID", cn);
            }
            else if (Get == "Booking")
            {
                cmd = new SqlCommand("Select * from Charges ", cn);
            }
            else
            {
                cmd = new SqlCommand("Select T.TransactionID as [Transaction ID], T.BookingDate, T.DepartureDate, T.Flightid as [Flight ID], T.Tickets, T.Tickets*C.Amount as [Total Charges],C.description as [Charges Description], T.Type from TRANSACTIONS T, CHARGES C where T.ChargesID=C.ChargesID and T.FlightID=C.FlightID and T.PassengerID=" + Convert.ToInt32(Get), cn);
            }
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dataset = new DataTable();
            sda.Fill(dataset);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataset;
            dataGridView1.DataSource = bs;
        }
    }
}
