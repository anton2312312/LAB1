using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseFirst
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ////ДАБАВЛЕНИЕ ДАННЫХ Castomers
            //using (HotelEntities db = new HotelEntities())
            //{
            //    Customers c = new Customers();
            //    c.Age = 100;
            //    c.Email = "antI@mak.ro";
            //    c.FirstName = "Peter";
            //    c.LastName = "Pin";
            //    c.PassportID = 123456;
            //    c.Phone = "8-800-888-88-88";
            //    db.Customers.Add(c);
            //    db.SaveChanges();
            //}

            ////ИЗМЕНЕНИЕ ДАННЫХ
            //using (HotelEntities db = new HotelEntities())
            //{
            //    Customers p1 = db.Customers.Where((customer) => customer.FirstName == "Peter").FirstOrDefault();
            //    if (p1 != null)
            //    {
            //        p1.Age = 1000;
            //        db.SaveChanges();
            //    }
            //}

            ////УДАЛЕНИЕ ДАННЫХ
            //using (HotelEntities db = new HotelEntities())
            //{
            //    Customers p1 = db.Customers.Where((customer) => customer.FirstName == "Peter").FirstOrDefault();
            //    if (p1 != null)
            //    {
            //        db.Customers.Remove(p1);
            //        db.SaveChanges();
            //    }
            //}

            ////ДАБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ Booking
            //using (HotelEntities db = new HotelEntities())
            //{
            //    Booking b = new Booking();

            //    b.ArrivalDate = new DateTime(2001, 01, 20);
            //    b.ArrivalTime = new TimeSpan(12, 30, 0);
            //    b.DepartureTime = new TimeSpan(12, 30, 0);
            //    b.DepartureDate = new DateTime(2001, 01, 20);
            //    b.CustomerId = db.Customers.Where(customer => customer.FirstName == "Peter").FirstOrDefault().Id;
            //    b.RoomId = db.Rooms.FirstOrDefault().Id;
            //    db.Booking.Add(b);
            //    db.SaveChanges();
            //}

            //using (HotelEntities db = new HotelEntities())
            //{
            //    Rooms r = new Rooms();

            //    r.Price = 5000;
            //    r.NumberOfRooms = 1;
            //    r.NumberOfPersons = 2;

            //    db.Rooms.Add(r);
            //    db.SaveChanges();
            //}

            ////ВЫВОД 2 ТАБЛИЦ
            //using (HotelEntities db = new HotelEntities())
            //{
            //    var bookings = db.Booking.Join(db.Customers,
            //                  booking => booking.CustomerId,
            //                  customer => customer.Id,
            //                  (booking, customer) => new
            //                  {
            //                      FirstName = customer.FirstName,
            //                      LastName = customer.LastName,
            //                      Phone = customer.Phone,
            //                      ArrivalDate = booking.ArrivalDate,
            //                      DepartureDate = booking.DepartureDate,
            //                  });
            //    foreach (var b in bookings)
            //        tbOutput.Text += string.Format("({0} {1}) Phone: {2} ArrivalDate: {3} DepartureDate: {4}\n",
            //            b.FirstName, b.LastName, b.Phone,
            //            b.ArrivalDate, b.DepartureDate);

            //}


            ////ВЫВОД 3 ТАБЛИЦ
            using (HotelEntities db = new HotelEntities())
            {
                var bookings = from booking in db.Booking
                               join customer in db.Customers on booking.CustomerId equals customer.Id
                               join room in db.Rooms on booking.RoomId equals room.Id
                               select new
                               {
                                   Name = customer.FirstName,
                                   Price = room.Price,
                                   ArrivalDate = booking.ArrivalDate,
                                   DepartureDate = booking.DepartureDate,
                               };
                foreach (var b in bookings)
                    tbOutput.Text += string.Concat("Name: ", b.Name,
                        " \nPrice: ", b.Price,
                        " \nArrivalDate: ", b.ArrivalDate,
                        " \nDepartureDate ", b.DepartureDate,
                        "\n---------\n"
                        );
            }
        }
    }
}
