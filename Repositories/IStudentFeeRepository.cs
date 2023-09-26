using StudentFeesTracker.Models;

namespace StudentFeesTracker.Repositories;

public interface IStudentFeeRepository
{
    Task<List<StudentFee>> FindAll();
    Task Create(StudentFee studentFee);
}