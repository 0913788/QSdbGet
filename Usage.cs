using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Usage : MonoBehaviour {

    Employee emp;
    Building NewBuilding;
    //Feeds
    List<Feeder> feeders = new List<Feeder>();

    void Start()
    {
        string jsonString = new GetDbData().getFullEmployee(1);
        var parsed = JSON.Parse(jsonString);

        feeders.Add(new Feeder(1));

        var Employee = parsed["employee"];
        var building = parsed["building"];
        var APS = parsed["ap"].AsArray;

        //Create employee
        emp = new Employee(Employee["Id"], Employee["Name"], Employee["Profession"]);

        //Create building
        NewBuilding = new Building(building["Name"]);

        //Add access points to the building
        for (int i = 0; i < APS.AsArray.Count-1; i++)
        {
            NewBuilding.AccessPoints.Add(new AccessPoint(APS[i]["MAC"], new StaticLocation(APS[i]["X"], APS[i]["Y"])));
        }

        Debug.Log(emp.Name);
        for (int i = 0; i < NewBuilding.AccessPoints.Count-1; i++)
        {
            Debug.Log(NewBuilding.AccessPoints[i].MAC);
            Debug.Log(NewBuilding.AccessPoints[i].Location.X+" "+ NewBuilding.AccessPoints[0].Location.Y);

        }
        Debug.Log("");


    }
        // Update is called once per frame
        void Update () {
        //feed threading testing.
        try
        {
            if (FeedWatcher.FeedStatus(1))
            {
                if (feeders[0].x > 30000) FeedWatcher.RemoveFeed(1);
                Debug.Log("Yay");
                Debug.Log(FeedWatcher.GetLastFeedData(1).TimeStamp.ToString());
            }
            else try
                {
                    feeders[0].kill();
                    feeders.Remove(feeders[0]);
                    Debug.Log("yay");
                }
                catch
                {
                    feeders.Add(new Feeder(1));
                }
            //FeedWatcher.RemoveFeed(1);
        }
        catch
        {
            //Debug.Log("Nog niets");
        }
	}
}
