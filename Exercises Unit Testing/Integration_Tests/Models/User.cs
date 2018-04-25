using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Tests.Models
{
    public class User
    {
		public User(string name)
		{
			this.Name = name;
			this.Categories = new List<Category>();
		}

		public string Name { get; set; }

		public List<Category> Categories { get;private set; }

		public void AddCategory(Category category)
		{
			this.Categories.Add(category);
		}
	}
}
