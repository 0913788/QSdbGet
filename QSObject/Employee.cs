using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee
{
    public int Id;
    public string Name;
    public string Profession;
    public Building Office;
    public Location PersonnalLocation;

    public Employee (int id, string name, string profesion)
    {
        Id = id;
        Name = name;
        Profession = profesion;
    }

    public void UpdateLocation(Location newLocation)
    {
        
    }
}
