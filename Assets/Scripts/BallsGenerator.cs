using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallsGenerator : MonoBehaviour
{
    public GameObject[] balls;
    public Vector3 ballPosition;
    public float maxXPosition;
    public int maxBallsCount;
    private readonly float PERIOD_BETWEEN_BALLS = 0.1f;
    private float _instantiateTime;

    void Start()
    {
        _instantiateTime = Time.time;
        StaticGameObjects.Balls = new List<GameObject>();
        StaticGameObjects.LastCreatedBallId = 0;
    }

    void Update()
    {
        InstatiateAnyBall();
    }

    private void InstatiateAnyBall()
    {
        if (_instantiateTime + PERIOD_BETWEEN_BALLS < Time.time
            && StaticGameObjects.Balls.Count < maxBallsCount)
        {
            int randomBallId = Random.Range(0, balls.Length);
            float randomXPosition = Random.Range(-maxXPosition, maxXPosition);
            Vector3 newBallPosition = ballPosition;
            newBallPosition.x = randomXPosition;
            var ball = Instantiate(balls[randomBallId], newBallPosition, Quaternion.identity);
            ball.name = ball.name + StaticGameObjects.LastCreatedBallId.ToString();
            StaticGameObjects.Balls.Add((GameObject)ball);
            StaticGameObjects.LastCreatedBallId++;
            _instantiateTime = Time.time;
        }
    }
}
