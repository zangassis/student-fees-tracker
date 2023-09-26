using StudentFeesTracker.Factories;
using StudentFeesTracker.Models;
using StudentFeesTracker.Repositories;

namespace StudentFeesTracker.Services;

public class StudentFeeService
{
    private readonly IStudentFeeRepository _repository;
    private readonly StudentFeeFactory _lateStudentFeeFactory;
    private readonly StudentFeeFactory _discountStudentFeeFactory;

    public StudentFeeService(IStudentFeeRepository repository, LateStudentFeeFactory lateStudentFeeFactory, DiscountStudentFeeFactory discountStudentFeeFactory)
    {
        _repository = repository;
        _lateStudentFeeFactory = lateStudentFeeFactory;
        _discountStudentFeeFactory = discountStudentFeeFactory;
    }

    public async Task<List<StudentFee>> FindAll()
    {
        var studentFees = await _repository.FindAll();
        return studentFees;
    }

    public async Task<Guid> Create(StudentFee studentFee)
    {
        CalculateFee(studentFee);
        GenerateId(studentFee);
        await _repository.Create(studentFee);
        return studentFee.Id;
    }

    private void CalculateFee(StudentFee studentFee)
    {
        if (IsLate(studentFee.DueDate))
        {
            studentFee.Amount = _lateStudentFeeFactory.CalculateFeeAmount(studentFee.Amount);
        }
        else if (IsDiscount(studentFee.DueDate))
        {
            studentFee.Amount = _discountStudentFeeFactory.CalculateFeeAmount(studentFee.Amount);
        }
    }

    private bool IsLate(DateTime dueDate)
    {
        const int lateDayThreshold = 29;
        return dueDate.Day > lateDayThreshold;
    }

    private bool IsDiscount(DateTime dueDate)
    {
        const int discountDayThreshold = 5;
        return dueDate.Day < discountDayThreshold;
    }

    private void GenerateId(StudentFee studentFee)
    {
        studentFee.Id = Guid.NewGuid();
    }
}