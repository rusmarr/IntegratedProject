﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttons.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
     public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
        public void AddItem(Product myproduct, int myquantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == myproduct.ProductID)
                .FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = myproduct,
                    Quantity = myquantity
                });
            }
            else
            {
                line.Quantity += myquantity;
            }
        }
        public void RemoveLine(Product myproduct)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == myproduct.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
