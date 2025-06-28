using DataDriven.Data;
using DataDriven.Models;
using DataDriven.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataDriven.Repositories;

public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
{
}