using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public string Name;
    public List<Room> Rooms;
    public List<AccessPoint> AccessPoints;

    public Building(string name)
    {
        Name = name;
        Rooms = new List<Room>();
        AccessPoints = new List<AccessPoint>();
    }
}
