using Api.Core;
using Api.Extensions;
using Api.Middlewares;
using Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();


builder.Configuration.Bind(settings);

builder.Services.AddSingleton(settings);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddApplicationUser();
builder.Services.AddJwt(settings);
builder.Services.AddBlogContext();
builder.Services.AddUseCases();

builder.Services.AddTransient<UseCaseHandler>();
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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseExceptionHandlerMiddleware();

app.Run();

