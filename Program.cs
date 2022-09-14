using Hangfire;
using Hangfire.PostgreSql;
using HangFirePostgresIssue;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHangfire(configuration => configuration
        .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("HangfireConnection")));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

var option = new RewriteOptions();
option.AddRedirect("^$", "hangfire");
app.UseRewriter(option);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});

RecurringJob.AddOrUpdate<JobThatCreatesOtherJobs>("JobThatCreatesOtherJob", c => c.CreateJobs(), Cron.Minutely);

app.Run();
