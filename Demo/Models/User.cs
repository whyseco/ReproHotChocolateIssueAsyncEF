using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
	public class UserNote
	{
		public virtual int Id { get; set; }

		public virtual string Note { get; set; }

		public virtual int UserId { get; set; }
	}

	public class User
	{
		public virtual int Id { get; set; }

		public virtual List<UserNote> Notes { get; set; }
	}
}
