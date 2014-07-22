using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class StaticGameObjects
{
    public static List<Connection> Connections { get; set; }
    public static List<GameObject> Balls { get; set; }
    public static int LastCreatedBallId;
    public static float MaxConnectionDistance;
}

public class Connection
{
    public string BallName1 { get; set; }
    public string BallName2 { get; set; }
}
