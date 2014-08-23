using UnityEngine;
using System.Collections;

public class CameraIsometric : MonoBehaviour
{

    public GameObject player;
    public float maxAccel = 4;
    public float maxSpeed = 10;
    public float targetRadius = 0.2f;
    public float actionRadius = 1.5f;
    private Vector3 velocity;
    private Vector3 displacement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No available player found");
            return;
        }
        velocity = Vector3.zero;
        displacement = new Vector3(-12.2f, 10f, -12.2f);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        FollowPoint(player.transform.position);
    }

    void FollowPoint(Vector3 point)
    {
        gameObject.transform.position = point + displacement;
        /*Vector3 cameraRefPos;
        Vector3 moveVector;
        cameraRefPos = GetScreenToWorldPos(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        moveVector = (point - cameraRefPos);
        gameObject.transform.position += moveVector;
        */
    }

    Vector3 GetScreenToWorldPos(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector2.up, Vector2.zero);
        float distance = 0;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }
}
