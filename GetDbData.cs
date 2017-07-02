using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using System.Threading;

public class GetDbData
{
    string _baseURL = "http://145.24.222.153/Webserver/",_extentionURL,JsonResult;
    WWW _wwwResult;

    //Full data set
    public string getFullEmployee(int employeeId)
    {
        Dictionary<string, object> retDict = new Dictionary<string, object>();
        _extentionURL = "Employee/?empId=" + employeeId;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        //Opzoek naar iets mooiers
        while (!_wwwResult.isDone)
        {
            Thread.Sleep(10);
        }
        JsonResult = _wwwResult.text;
        return JsonResult;
    }

    //Employees (int building)

    public DynamicLocation EmployeeFeedCall(int employeeId)
    {
        _extentionURL = "Employee/Feed/?EmployeeID=" + employeeId;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        JsonResult = _wwwResult.text;
        return JsonUtility.FromJson<DynamicLocation>(JsonResult);
    }

    public Room getRoom(int roomID)
    {
        _extentionURL = "Room/?Roomnr=" + roomID;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        JsonResult = _wwwResult.text;
        var x = JSON.Parse(JsonResult);
        string a = x["room"]["level"];
        return JsonUtility.FromJson<Room>(JsonResult);
    }

    public AccessPoint GetAccessPoints(int APId)
    {
        _extentionURL = "AP/?APId=" + APId;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        JsonResult = _wwwResult.text;
        return JsonUtility.FromJson<AccessPoint>(JsonResult);
    }

    public Building GetBuilding(int EmployeeID)
    {
        _extentionURL = "AP/?APId=" + EmployeeID;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        JsonResult = _wwwResult.text;
        return JsonUtility.FromJson<Building>(JsonResult);
    }
}
