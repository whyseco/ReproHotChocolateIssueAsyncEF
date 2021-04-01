using Demo.Data;
using Demo.Models;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.GraphQL
{
	public class UserType : ObjectType<User>
	{
		private async Task<List<UserNote>> GetNotes(User user)
		{
			await Task.Delay(100);
			return user.Notes;
		}

		protected override void Configure(IObjectTypeDescriptor<User> descriptor)
		{
			descriptor.BindFieldsExplicitly();

			descriptor.Field(_ => _.Id);
			descriptor.Field("notesOne").UseDbContext<DemoContext>().Resolve(async _ => await GetNotes(_.Parent<User>())).Type(typeof(List<UserNote>));
			//descriptor.Field("notesOne").UseDbContext<DemoContext>().Resolve(_ => GetNotes(_.Parent<User>()).Result).Type(typeof(List<UserNote>));
			descriptor.Field("notesTwo").UseDbContext<DemoContext>().Resolve(async _ => await GetNotes(_.Parent<User>())).Type(typeof(List<UserNote>));
			//descriptor.Field("notesTwo").UseDbContext<DemoContext>().Resolve(_ => GetNotes(_.Parent<User>()).Result).Type(typeof(List<UserNote>));
		}
	}
}
