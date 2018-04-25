using System;
using System.Collections.Generic;
using System.Text;


[AttributeUsage(AttributeTargets.Class)]
public class ReviewAttribute : Attribute
{
	public ReviewAttribute(string author, int revision, string description,params string[] reviewers)
	{
		this.Author = author;
		this.Revision = revision;
		this.Description = description;
		this.Reviewers = reviewers;
	}

	public string Author { get; private set; }
	public int Revision { get; set; }
	public string Description { get; set; }
	public string[] Reviewers { get; set; }
}

