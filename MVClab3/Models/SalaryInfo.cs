namespace MVClab3.Models
{
    public class SalaryInfo//dependent entitiy to Employee entity 1-1 rel.
    {
        public int Id { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }

        //Navigation Property
        public Employee Employee { get; set; }
    }
}
