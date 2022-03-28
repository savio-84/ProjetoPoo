using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CarsRepository
{
	private List<Car> repository = new List<Car>();

	public List<Car> getAll()
    {
		return this.repository;
    }
	
	public List<Car> getAllWithBrandFord()
    {
		return repository.Where(Car => Car.brand == "audi").ToList();		
    }

	public void addCar(string brand)
    {
		this.repository.Add(new Car(brand));
    }
}
