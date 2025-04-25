namespace DockerGymApp.Service.Entities
{
    public class Payments
    {
        public Payments() { }
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.NotStarted;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }

    public enum PaymentStatus
    {
        NotStarted = 0,
        Pending,
        Completed,
        Failed
    }

    public class CreatePayment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } 
        public DateTime PaymentDate { get; set; }
    }
}