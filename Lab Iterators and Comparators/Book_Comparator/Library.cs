﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Library : IEnumerable<Book>
{
	public Library(params Book[] books)
	{
		this.books = new SortedSet<Book>(books , new BookComparator());
	}

	public SortedSet<Book> books { get; set; }

	public IEnumerator<Book> GetEnumerator()
	{
		return new LibraryIterator(this.books);
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	private class LibraryIterator : IEnumerator<Book>
	{

		private readonly List<Book> books;
		private int currentIndex;

		public LibraryIterator(IEnumerable<Book> books)
		{
			this.Reset();
			this.books = new List<Book>(books);
		}

		public Book Current => this.books[this.currentIndex];

		object IEnumerator.Current => this.Current;

		public void Dispose()
		{

		}

		public bool MoveNext()
		{
			return ++this.currentIndex < this.books.Count;
		}

		public void Reset()
		{
			this.currentIndex = -1;
		}
	}
}

