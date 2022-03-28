using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Car
{
	public string brand { get; set; }
	public Car(string brand)
	{
		this.brand = brand;
	}

    public override string ToString()
    {
		return this.brand;
    }
}
