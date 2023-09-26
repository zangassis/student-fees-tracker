namespace StudentFeesTracker.Models;

public class StudentFee : EntityDto
{
    public Guid StudentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
}
