using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DockerGymApp.Service.Entities.Configurations
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(p => p.Id);
            builder.HasData
            (
                new Payments
                {
                    Id = 1,
                    UserId = 1,
                    Amount = 100.00m,
                    PaymentStatus = PaymentStatus.Completed,
                    PaymentDate = new DateTime(2025,01,01)
                },
                new Payments
                {
                    Id = 2,
                    UserId = 2,
                    Amount = 50.00m,
                    PaymentStatus = PaymentStatus.Pending,
                    PaymentDate = new DateTime(2025, 02, 01)
                },
                new Payments
                {
                    Id = 3,
                    UserId = 3,
                    Amount = 10.00m,
                    PaymentStatus = PaymentStatus.NotStarted,
                    PaymentDate = new DateTime(2025, 03, 01)
                }
            );
        }
    }
}
