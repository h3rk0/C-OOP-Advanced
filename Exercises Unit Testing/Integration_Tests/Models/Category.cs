using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Tests.Models
{
    public class Category
    {
		public Category(string name)
		{
			this.Name = name;
			this.Users = new List<User>();
			this.ChildrenCategories = new List<Category>();
		}

		public string Name { get; }

		public List<User> Users { get; private set; }

		public List<Category> ChildrenCategories { get; private set; }

		public Category ParentCategory { get; private set; }

		public void AssignChildCategory(Category category)
		{
			this.ChildrenCategories.Add(category);
		}

		public void AssignUser(User user)
		{
			this.Users.Add(user);
		}
	}
}
