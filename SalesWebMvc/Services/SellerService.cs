using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            //seller.Departament = _context.Departament.FirstOrDefault();
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            //Seller seller = _context.Seller.Where(s => s.Id == id).FirstOrDefault();
            return _context.Seller.Include(s => s.Departament).FirstOrDefault(s => s.Id == id);
        }

        public void RemoveSeller(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
