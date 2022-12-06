namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Order
    {
        public long Id { get; set; }  
        public string PaymentID { get; set; }
        public string MerchantOrderID { get; set; }
        public string PreferenceID { get; set; }
        public long UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ChildID { get; set; }
        public long IdLicensesType { get; set; }
        public int IdCourse { get; set; }
        //Muy probablemente necesita rediseño 
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string LicenseType { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set; }

    }
}
