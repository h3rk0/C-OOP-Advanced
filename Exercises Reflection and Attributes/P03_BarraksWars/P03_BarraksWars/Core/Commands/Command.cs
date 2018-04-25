﻿using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Commands
{
	public abstract class Command : IExecutable
	{
		//private string[] data;
		//private IRepository repository;
		//private IUnitFactory unitFactory;

		private string[] data;

		public Command(string[] data)
		{
			this.Data = data;
		}

		public string[] Data
		{
			get { return data; }
			set { data = value; }
		}




		public abstract string Execute();
	}
}
