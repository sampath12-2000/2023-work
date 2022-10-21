using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using CropDealWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// below code will read the connection string from appsetting.json file
builder.Services.AddDbContext<CropDealDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));




builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CropDealDatabaseContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(option =>
     {
         // var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]);
         option.SaveToken = true;
         option.RequireHttpsMetadata = false;
         option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidAudience = builder.Configuration["JWT:Audience"],
             ValidIssuer = builder.Configuration["JWT:Issuer"],
             IssuerSigningKey = new
             SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

         };

     });
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "CropDealWebAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(a => a.AddPolicy("corspolicy", build => {
    build.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
})) ;

builder.Services.AddScoped<IUserRepository<UserProfile>, UserProfileRepository>();
builder.Services.AddScoped<UserProfileService, UserProfileService>();
builder.Services.AddScoped<IRepository<Crop>, CropRepository>();
builder.Services.AddScoped<CropService, CropService>();
builder.Services.AddScoped<IInvoiceRepository<Invoice>, InvoiceRepository>();
builder.Services.AddScoped<InvoiceService, InvoiceService>();
builder.Services.AddScoped<IRepository<CropOnSale>, CropOnSaleRepository>();
builder.Services.AddScoped<CropOnSaleService, CropOnSaleService>();
builder.Services.AddScoped<IViewCropRepository, ViewCropRepository>();
builder.Services.AddScoped<CropViewService, CropViewService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
