using System;
using System.Collections.Generic;
using System.Text;

namespace Extended_Database.Models
{
    public class Person
    {
		public Person(int id,string username)
		{
			this.Id = id;
			this.Username = username;
		}

		public int Id { get; private set; }
		public string Username { get; set; }
	}
}
