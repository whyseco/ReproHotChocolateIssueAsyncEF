using Demo.Data;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
	public class UserRepository
	{
		private readonly DemoContext dbContext;

		public UserRepository(DemoContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<User> GetUser(int id)
		{
			return await this.dbContext.FindAsync<User>(id);
		}
	}
}
