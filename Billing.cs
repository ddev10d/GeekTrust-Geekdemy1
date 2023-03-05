using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust
{
    public class Billing
    {
        private readonly ShoppingCart cart;

        public Billing(ShoppingCart cart)
        {
            this.cart = cart;
        }
        public decimal getEnrollmentFee()
        {
            return 500;
        }
        public decimal CalculateTotalProDiscount()
        {
            decimal totalProDiscount = 0;
            if (cart.IsProMember)
            {
                foreach(Programme programme in cart.programmes)
                {
                    totalProDiscount += programme.Cost * programme.ProMemberShipDiscount;
                }
            }
            return totalProDiscount;
        }
        public decimal CalculateTotalCost(decimal discount)
        {
            decimal totalCost = 0;
            foreach (Programme item in cart.programmes)
            {
               
                totalCost += item.Cost;
            }
            totalCost -= discount;
            return totalCost;
        }
        public decimal TotalProDiscount()
        {
            return 1;
        }

        internal decimal subtotal()
        {
            return 1;
            throw new NotImplementedException();
        }

        internal decimal couponDiscount()
        {
            return 1;
            throw new NotImplementedException();
        }
    }
}
