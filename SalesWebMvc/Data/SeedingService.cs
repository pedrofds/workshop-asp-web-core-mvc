using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //DB ja foi populado
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Electronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Marig Green", "maria@gmail.com", new DateTime(1979, 12, 21), 1000.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 21), 1000.0, d1);
            Seller s4 = new Seller(4, "Martha red", "martha@gmail.com", new DateTime(1993, 11, 21), 1000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 21), 1000.0, d3);
            Seller s6 = new Seller(6, "Bob Pink", "bob@gmail.com", new DateTime(1997, 3, 21), 1000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 5), 7000.0, SaleStatus.Pending, s3);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 6), 18000.0, SaleStatus.Billed, s4);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 15), 19000.0, SaleStatus.Canceled, s2);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 06, 25), 45000.0, SaleStatus.Billed, s2);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 14), 4000.0, SaleStatus.Pending, s3);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 20), 5000.0, SaleStatus.Pending, s1);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 12), 2000.0, SaleStatus.Billed, s5);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 9), 70000.0, SaleStatus.Billed, s6);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Canceled, s6);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();
        }

    }
}
