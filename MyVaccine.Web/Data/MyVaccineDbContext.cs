using Microsoft.EntityFrameworkCore;
using MyVaccine.Web.Models;

namespace MyVaccine.Web.Data;

public class MyVaccineDbContext(DbContextOptions<MyVaccineDbContext> options) : DbContext(options)
{
    public DbSet<Vaccine> Vaccines { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<VaccinationCenter> VaccinationCenters { get; set; } = default!;
}
