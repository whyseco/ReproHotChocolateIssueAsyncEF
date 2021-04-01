using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
	public class DemoContext : DbContext
	{
		public DemoContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var user = new User { Id = 1, Notes = new List<UserNote>() };
			modelBuilder.Entity<User>().HasData(user);
			modelBuilder.Entity<UserNote>().HasData(new UserNote() { Id = 1, Note = "Demo", UserId = user.Id }, new UserNote() { Id = 2, Note = "HotChocolate", UserId = user.Id });

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<User> Users { get; set; }
    }
}
