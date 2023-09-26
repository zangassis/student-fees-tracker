namespace StudentFeesTracker.Factories;
public class DiscountStudentFeeFactory : StudentFeeFactory
{
    public override decimal CalculateFeeAmount(decimal amount)
    {
        return amount * 0.9m; // Apply a 10% discount
    }
}