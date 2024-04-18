namespace COMMSFinalProject.Models
{
    public class AddLoan
    {
        public string LoanType { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
    }
}
