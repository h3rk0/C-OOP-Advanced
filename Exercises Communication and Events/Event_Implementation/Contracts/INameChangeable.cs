﻿using System;
using System.Collections.Generic;
using System.Text;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public interface INameChangeable
{
	string Name { get; set; }

	event NameChangeEventHandler NameChange;

	void OnNameChange(NameChangeEventArgs args);
}

