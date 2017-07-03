using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Feeder
{
    Thread FeedThread;
    bool active = true;
    public int x;
    public Feeder(int employeeId)
    {
        FeedWatcher.NewInstance(employeeId);
        FeedThread = new Thread(() => Work(employeeId));
        FeedThread.Start();
    }

    private void Work(int employeeID)
    {
        GetDbData data = new GetDbData(); 
        while (true)
        {
            if (FeedWatcher.FeedStatus(employeeID)) FeedWatcher.ReplaceFeedData(employeeID, data.EmployeeFeedCall(employeeID));
            else active = false; Debug.Log("Quiting"); return;
        }
    }

     public bool kill()
    {
        try
        {
            FeedThread.Abort();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
