using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Company
    {
        public string Name { get; set; }    
        public List<Customer> Customer { get; set; }=new List<Customer>();
    }
    class Customer
    {
        public string CustId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    class RegCustomer : Customer
    {
        public string DtReg { get; set; }
        public Membership membership { get; set; }
        public string getTypeOfMembership()
        {
            return membership.typeOfMembership;
        }
        public double getDiscount()
        {
            return membership.discount;
        }
        public double getFees()
        {
            return membership.fees;
        }
    }
    sealed class MembershipFactory
    {
        private MembershipFactory() { }
        private MembershipFactory _membershipFactory=null;
        public Dictionary<string,Membership> pool { get; set; }
        public MembershipFactory membershipFactory
        {
            get
            {
                if(_membershipFactory==null)
                    _membershipFactory=new MembershipFactory();
                return _membershipFactory;
            }
        }
        public Membership createMembership(string type,double fees,double discount)
        {
            return new Membership
            {
                typeOfMembership = type,
                fees = fees,
                discount = discount
            };
        }
        public Membership create(string type)
        {
            return new Membership { typeOfMembership = type };
        }
    }
    class Membership
    {
        public string typeOfMembership { get; set; }
        public double discount { get; set; }
        public double fees { get; set; }

    }
}
