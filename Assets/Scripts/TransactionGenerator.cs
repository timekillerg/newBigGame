using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class TransactionGenerator : MonoBehaviour
{
    public GameObject transaction;

    private Vector3 v1;
    private Vector3 v2;
    private float _ballCreateTime;
    private bool isTransactionsCreated = false;

    void Start()
    {
        _ballCreateTime = Time.time;
    }

    void Update()
    {
        if ((_ballCreateTime + 20f < Time.time) && !isTransactionsCreated)
        {
            CreateTransaction();
            isTransactionsCreated = true;
        }
    }

    private Vector3 GetCenterPoint2Balls(Vector3 v1, Vector3 v2)
    {
        return (v1 + v2) / 2;
    }

    private float GetDistance(Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(v1, v2);
    }

    private void CreateTransaction()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            for (int j = 0; j < balls.Length; j++)
            {
                v1 = balls[i].transform.position;
                v2 = balls[j].transform.position;
                float distance = GetDistance(v1, v2);

                if (distance > 0 && distance < 1.5f)
                {
                    Vector3 instantiatePosition = GetCenterPoint2Balls(v1, v2);
                    instantiatePosition.z = 0;
                    GameObject tran = (GameObject)Instantiate(transaction, GetCenterPoint2Balls(v1, v2), Quaternion.identity);
                    Vector3 localScale = tran.transform.localScale;
                    localScale.y = distance/2;
                    tran.transform.localScale = localScale;

                    var v3 = v1 - v2;
                    float angle = Mathf.Rad2Deg * Mathf.Atan2(v3.y, v3.x);

                    tran.transform.Rotate(0f, 0f, angle-90);
                }
            }
        }
    }
}
