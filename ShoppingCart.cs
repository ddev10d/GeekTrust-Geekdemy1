using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTrust
{
    public class ShoppingCart
    {
        public List<Programme> programmes = new List<Programme>();
        private Coupon appliedCoupon;
        public bool IsProMember=false;
        private decimal SubTotal;
        private decimal TotalProDiscount;
        private decimal EnrollmentFee;
        private decimal Total;
        

        public string AddProgrammes(string programmeCategory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Programme programme = programmeCategory switch
                {
                    "CERTIFICATION" => new Certification(),
                    "DIPLOMA" => new Diploma(),
                    "DEGREE" => new Degree(),
                    _ => throw new ArgumentException("Invalid programme category."),
                };
                programmes.Add(programme);
            }
            return $"{count} programmes added to {programmeCategory} category.";
        }
        public static decimal GetCostOfCheapestProgramme(List<Programme> p)
        {
            return p.OrderBy(o => o.Cost).First().Cost;
        }
        public string AddCoupon(string couponType)
        {
            appliedCoupon = new Coupon(couponType); 
            if(programmes.Count > 4)
            {
                decimal costOfCheapestProgramme = GetCostOfCheapestProgramme(programmes);
               
            }
            return "";
        }
        public string AddProMembership()
        {
            IsProMember = true;
            return "empty";
            //throw new NotImplementedException();
        }
        
        public string printBill(ShoppingCart cart)
        {
            Billing billing = new Billing(cart);

            decimal sub_total = billing.subtotal();
            decimal coupon_discount = billing.couponDiscount();
            decimal totalProDiscount = billing.CalculateTotalProDiscount();
            decimal enrollmentFee = billing.CalculateEnrollmentFee();
            decimal total = billing.CalculateTotalCost(totalProDiscount);
            decimal promembershipfees = IsProMember ? 200 : 0;

            return "SUB_TOTAL\n" + sub_total.ToString() + "COUPON_DISCOUNT\n" + coupon_discount.ToString() +
                   "TOTAL_PRO_DISCOUNT\n" + totalProDiscount.ToString() + "PRO_MEMBERSHIP_FEE\n" +
                   promembershipfees.ToString() + "ENROLLMENT_FEE\n" + enrollmentFee.ToString() +
                   "TOTAL\n" + total.ToString() + "";
        }
    }
}
//public string AddProgrammes(string programmeCategory, int count)
//{
//    ProgrammeFactory factory;

//    switch (programmeCategory)
//    {
//        case "CERTIFICATION":
//            factory = new CertificationFactory();
//            break;
//        case "DIPLOMA":
//            factory = new DiplomaFactory();
//            break;
//        case "DEGREE":
//            factory = new DegreeFactory();
//            break;
//        default:
//            throw new ArgumentException("Invalid programme category.");
//    }

//    for (int i = 0; i < count; i++)
//    {
//        Programme programme = factory.CreateProgramme();
//        programmes.Add(programme);
//    }

//    return $"{count} programmes added to {programmeCategory} category.";
//}

//public abstract class ProgrammeFactory
//{
//    public abstract Programme CreateProgramme();
//}

//public class CertificationFactory : ProgrammeFactory
//{
//    public override Programme CreateProgramme()
//    {
//        return new Certification();
//    }
//}