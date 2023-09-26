using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using StudentFeesTracker.Models;

namespace StudentFeesTracker.Repositories;

public class StudentFeeRepository : IStudentFeeRepository
{
    private readonly IDbConnection _dbConnection;

    public StudentFeeRepository(IOptions<ConnectionString> connectionString)
    {
        _dbConnection = new MySqlConnection(connectionString.Value.ProjectConnection);
    }

    public async Task<List<StudentFee>> FindAll()
    {
        string query = @"select 
                            id Id, 
                            student_id StudentId, 
                            amount Amount, 
                            due_date DueDate, 
                            is_paid IsPaid
                        from student_fees";

        var projects = await _dbConnection.QueryAsync<StudentFee>(query);
        return projects.ToList();
    }

    public async Task Create(StudentFee studentFee)
    {
        string query = @"insert into student_fees(id, student_id, amount, due_date, is_paid) 
                         values(@Id, @StudentId, @Amount, @DueDate, @IsPaid)";

        await _dbConnection.ExecuteAsync(query, studentFee);
    }
}