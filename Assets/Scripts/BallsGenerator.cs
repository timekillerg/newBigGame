using UnityEngine;
using System.Collections;

public class BallsGenerator : MonoBehaviour
{
    public GameObject[] balls;
    public Vector3 ballPosition;
    public float minXPosition;
    public float maxXPosition;
    public int ballsCount;
    private readonly float PERIOD_BETWEEN_BALLS = 0.25f;
    private float _instantiateTime;

    void Start()
    {
        _instantiateTime = Time.time;
    }

    void Update()
    {
        InstatiateAnyBall();
    }

    private void InstatiateAnyBall()
    {
        if (_instantiateTime + PERIOD_BETWEEN_BALLS < Time.time && GameObject.FindGameObjectsWithTag("Ball").Length < ballsCount)
        {
            int ballId = Random.Range(0, balls.Length);
            float xPosition = Random.Range(minXPosition, maxXPosition);
            Vector3 newBallPosition = ballPosition;
            newBallPosition.x = xPosition;
            Instantiate(balls[ballId], newBallPosition, Quaternion.identity);
            _instantiateTime = Time.time;
        }
    }
}
