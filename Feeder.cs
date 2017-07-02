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
        x = 0;
        while (true)
        {
            if (FeedWatcher.FeedStatus(employeeID))
            {
                DynamicLocation z = new DynamicLocation((float)0.000, (float)0.000, 0);
                z.TimeStamp = x;
                FeedWatcher.ReplaceFeedData(employeeID, z);
                if (x > 50000) x = 0;
                else x++;
                continue;
            } /*FeedWatcher.ReplaceFeedData(employeeID, new GetDbData().getLastKnowEmployeeLocation(employeeID));*/
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
