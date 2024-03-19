using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add NHibernate configuration
var sessionFactory = ConfigureNHibernate(builder.Configuration);
builder.Services.AddSingleton<ISessionFactory>(sessionFactory);

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

// Use CORS middleware
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();

// Method to configure NHibernate
ISessionFactory ConfigureNHibernate(IConfiguration configuration)
{
    var cfg = new Configuration();
    cfg.Configure("NHibernate.cfg.xml");
    cfg.AddAssembly(Assembly.GetCallingAssembly());
    return cfg.BuildSessionFactory();
}
