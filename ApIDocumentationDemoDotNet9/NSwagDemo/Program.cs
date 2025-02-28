var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

List<PersonRecord> people = [
    new PersonRecord(1,"John", "Doe", "Erandika1986@gmail.com"),
    new PersonRecord(2,"ABC", "Doe", "abc@gmail.com"),
    new PersonRecord(3,"XYZ", "Doe", "xyz@gmail.com")
    ];

app.MapGet("/people", () => people);
app.MapGet("/people/{id}", (int id) => people[id]);
app.MapPost("/people", (PersonRecord person) => people.Add(person));
app.MapDelete("/people/{id}", (int id) => people.RemoveAt(id));

app.Run();


public record PersonRecord(int Id, string FirstName, string LastName, string Email);
