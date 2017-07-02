using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPoint {
    public string MAC;
    public StaticLocation Location;

    public AccessPoint(string mac, StaticLocation location)
    {
        MAC = mac;
        Location = location;
    }
}
