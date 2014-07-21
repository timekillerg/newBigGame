using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ConnGenerator : MonoBehaviour
{
    public GameObject connection;
    public float maxConnectionDistance;
    private GameObject[] balls;
    private GameObject[] connections;

    void Start()
    {

    }

    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        connections = GameObject.FindGameObjectsWithTag("Connection");
            foreach (GameObject ball1 in balls)
                foreach (GameObject ball2 in balls)
                {
                    var distance = Vector3.Distance(ball1.transform.position, ball2.transform.position);

                    if (distance < maxConnectionDistance && distance > 0)
                    {
                        bool noSuchConnection = true;
                        foreach (GameObject connection in connections)
                        {
                            var connectionController = connection.GetComponent<ConnectionController>();
                            if ((connectionController.ball1 == ball1 && connectionController.ball2 == ball2)
                                || (connectionController.ball2 == ball1 && connectionController.ball1 == ball2))
                            {
                                noSuchConnection = false;
                                break;
                            }
                        }

                        if (noSuchConnection)
                        {
                            var newConnection = (GameObject)Instantiate(connection, Vector3.zero, Quaternion.identity);
                            var connectionController = newConnection.GetComponent<ConnectionController>();
                            connectionController.ball1 = ball1;
                            connectionController.ball2 = ball2;
                            return;
                        }
                    }
                }
    }
}
