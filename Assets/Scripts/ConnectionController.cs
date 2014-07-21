using UnityEngine;
using System.Collections;

public class ConnectionController : MonoBehaviour {

    public GameObject ball1;
    public GameObject ball2;
    private Vector3 v1;
    private Vector3 v2;
    private float maxConnectionDistance = 1.5f;

	void Start () {
        v1 = ball1.transform.position;
        v2 = ball2.transform.position;
	}

	void Update () {
        if (ball1.transform.position != v1 || ball2.transform.position != v2)
        {
            v1 = ball1.transform.position;
            v2 = ball2.transform.position;
            gameObject.GetComponent<LineRenderer>().SetPosition(0, v1);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, v2);
            if (Vector3.Distance(ball1.transform.position, ball2.transform.position) > maxConnectionDistance)
                Destroy(gameObject);
        }	    
	}
}
