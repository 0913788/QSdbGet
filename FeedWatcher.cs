﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedWatcher
{
    private static readonly object CreateLock = new object();
    private static readonly object AddDataLock = new object();
    private static readonly object AddFeedLock = new object();
    private static FeedWatcher ActiveFeedWatcher = null;
    private static Dictionary<int,bool> EmployeeFeeds = new Dictionary<int,bool>();
    private static Dictionary<int, Location> FeedData = new Dictionary<int, Location>();

    private FeedWatcher(int employeeID) {
        EmployeeFeeds.Add(employeeID, true);
        FeedData.Add(employeeID, new Location((float)0.000, (float)0.000));
    }

    public static void RemoveFeed(int employeeID)
    {
        lock (AddFeedLock)
        {
            EmployeeFeeds[employeeID] = false;
            Debug.Log("Feed removed");
        }
    }

    public static void  ReplaceFeedData(int employeeId,Location location)
    {
        lock (AddDataLock)
        {
            FeedData[employeeId] = location;
        }
    }

    public static Location GetLastFeedData(int employeeId)
    {
        lock (AddFeedLock)
        {
            return FeedData[employeeId];
        }
    }
    public static bool FeedStatus(int employeeId)
    {
        lock (AddFeedLock)
        {
            return EmployeeFeeds[employeeId];
        }
    }

    public static FeedWatcher NewInstance(int employeeID)
    {
        if (ActiveFeedWatcher == null)
        {
            lock (CreateLock)
            {
                Debug.Log("Locking");
                if (ActiveFeedWatcher == null) ActiveFeedWatcher = new FeedWatcher(employeeID);
            }
        }
        Debug.Log("returning");
        return ActiveFeedWatcher;
    }

    public static void RemoveActiveSingleton()
    {
        ActiveFeedWatcher = null;
    }

}
