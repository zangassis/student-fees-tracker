using StudentFeesTracker.Factories;
using StudentFeesTracker.Models;
using StudentFeesTracker.Repositories;
using StudentFeesTracker.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStudentFeeRepository, StudentFeeRepository>();
builder.Services.AddSingleton<StudentFeeService>();
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddTransient<LateStudentFeeFactory>();
builder.Services.AddTransient<DiscountStudentFeeFactory>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/v1/student/fees", async (StudentFeeService service) =>
{
    var fees = await service.FindAll();
    return fees.Any() ? Results.Ok(fees) : Results.NotFound("No fees found");
})
.WithName("FindAllFees");

app.MapPost("/v1/student/fees", async (StudentFeeService service, StudentFee newStudentFee) =>
{
    var createdId = await service.Create(newStudentFee);
    return Results.Created($"/v1/contacts/{createdId}", createdId);
})
.WithName("CreateNewFee");

app.Run();
