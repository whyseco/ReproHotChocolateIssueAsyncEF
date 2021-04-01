using Demo.Models;
using Demo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.GraphQL
{
	public class Query
	{
		private readonly UserRepository repository;

		public Query(UserRepository repository)
		{
			this.repository = repository;
		}

		public async Task<User> GetUser(int id)
		{
			return await repository.GetUser(id);
		}
	}
}
