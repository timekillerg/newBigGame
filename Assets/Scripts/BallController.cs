using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    private Vector3 _move;
    private Vector3 _startPosition;
    private readonly float WAIT_BEFORE_CHANGE_TO_KINEMATIC = 10f;
    private readonly float RETURN_BACK_SPEED = 10;

    void Start()
    {
        _move = Vector3.zero;
        StartCoroutine(MakeBallKinematicAfterWait(WAIT_BEFORE_CHANGE_TO_KINEMATIC));
    }

    void Update()
    {
        if (_move != Vector3.zero && _move != _startPosition)
            gameObject.transform.position = _move;
        else if (_move != Vector3.zero && _move == _startPosition)
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, _move, Time.time * RETURN_BACK_SPEED);
    }

    void OnMouseDrag()
    {
        _move = GetMousePositionAbsolute();
        _move.z = 0.5f;
    }

    void OnMouseDown()
    {
        _startPosition = GetMousePositionAbsolute();
        _startPosition.z = 0.5f;
    }

    void OnMouseUp()
    {
        _move = _startPosition;
    }

    IEnumerator MakeBallKinematicAfterWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.rigidbody.isKinematic = true;
        gameObject.rigidbody.useGravity = false;
    }

    private Vector3 GetMousePositionAbsolute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return (Physics.Raycast(ray, out hit, 100)) ? hit.point : Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " = " + other.name);
        if (Vector3.Distance(this.transform.position, other.transform.position) < 0.5)
            if (this.gameObject != null)
                Destroy(this.gameObject);

    }
}
