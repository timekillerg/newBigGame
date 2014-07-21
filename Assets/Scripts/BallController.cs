using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 move;

    void Start()
    {
        move = Vector3.zero;
    }

    void Update()
    {
        if (move != Vector3.zero)
            gameObject.transform.position = move;
    }

    void OnMouseDrag()
    {
        move = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            move = hit.point;
            move.z = 0.5f;
        }
    }

    void OnMouseUp()
    {
        move = Vector3.zero;
    }
}
