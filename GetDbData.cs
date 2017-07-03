using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using System.Threading;

public class GetDbData
{
    string _baseURL = "http://145.24.222.153/Webserver/",_extentionURL,JsonResult;
    WWW _wwwResult;

    private void waitForWWW(WWW site)
    {
        while (!site.isDone)
        {
            Thread.Sleep(10);
        }
    }

    //Full data set

    //Employees (int building)
    public List<Employee> getEmployeesAtBuilding(int BuildingID)
    {
        List<Employee> workingEmployees = new List<Employee>();
        _extentionURL = "Employees=" + BuildingID;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        waitForWWW(_wwwResult);

        var parsed = JSON.Parse(_wwwResult.text);
        for (int i = 0; i < parsed.AsArray.Count-1; i++)
        {
            Employee newEmp = new Employee(parsed[i]["Id"], parsed[i]["Name"], parsed[i]["Profession"]);
            newEmp.PersonnalLocation = new Location(parsed[i]["X"], parsed[i]["Y"]);
            workingEmployees.Add(newEmp);
        }
        return workingEmployees;
    }

    public Location EmployeeFeedCall(int employeeId)
    {
        _extentionURL = "Employee/Feed/?EmployeeID=" + employeeId;
        _wwwResult = new WWW(_baseURL + _extentionURL);
        JsonResult = _wwwResult.text;
        var parsed = JSON.Parse(_wwwResult.text);
        return new Location(parsed["feedemployee"]["X"], parsed["feedemployee"]["Y"]);
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
