using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ConnGenerator : MonoBehaviour
{
    public GameObject connection;
    public float maxConnectionDistance;

    void Start()
    {
        StaticGameObjects.Connections = new List<Connection>();
        StaticGameObjects.MaxConnectionDistance = maxConnectionDistance;
    }

    void Update()
    {
        foreach (GameObject ball1 in StaticGameObjects.Balls)
        {
            foreach (GameObject ball2 in StaticGameObjects.Balls)
            {
                var distance = Vector3.Distance(ball1.transform.position, ball2.transform.position);

                if (distance < StaticGameObjects.MaxConnectionDistance && distance > 0)
                {
                    bool isExistConnection = false;
                    foreach (Connection connection in StaticGameObjects.Connections)
                    {
                        if ((connection.BallName1 == ball1.name && connection.BallName2 == ball2.name)
                            || (connection.BallName2 == ball1.name && connection.BallName1 == ball2.name))
                        {
                            isExistConnection = true;
                            break;
                        }
                    }

                    if (!isExistConnection)
                    {
                        var newConnection = (GameObject)Instantiate(connection, Vector3.zero, Quaternion.identity);
                        var connectionController = newConnection.GetComponent<ConnectionController>();
                        connectionController.ball1 = ball1;
                        connectionController.ball2 = ball2;
                        StaticGameObjects.Connections.Add(new Connection() { BallName1 = ball1.name, BallName2 = ball2.name });
                    }
                }
            }
        }
    }
}
