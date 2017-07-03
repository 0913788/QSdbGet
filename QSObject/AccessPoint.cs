using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPoint {
    public string MAC;
    public Location Location;

    public AccessPoint(string mac, Location location)
    {
        MAC = mac;
        Location = location;
    }
}
