using Microsoft.VisualBasic;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Mappers;
using myfinance_web_netcore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDBContext>();
//builder.Services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());
builder.Services.AddAutoMapper(typeof(FinancialRecordMap));
builder.Services.AddAutoMapper(typeof(TransactionMap));
//Services
builder.Services.AddTransient<IFinancialRecordService, FinancialRecordService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
