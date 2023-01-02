using WebApiTemplate.Api.Authentication;
using WebApiTemplate.DataAccess.Infrastructure;
using WebApiTemplate.Domain.Infrastructure;
using WebApiTemplate.Domain.Middleware;
using WebApiTemplate.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceBindings.Register(builder.Services);
RepositoryBindings.Register(builder.Services);
DomainBindings.Register(builder.Services);
RepositoryBindings.Register(builder.Services);
Authentication.Authenticate(builder);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.ConfigureExceptionHandler(logger);
app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
