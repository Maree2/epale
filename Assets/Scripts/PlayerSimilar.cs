using UnityEngine;
using System.Collections;

public class PlayerSimilar : MonoBehaviour
{
    public Sprite handOpened;
    public Sprite handClosed;
    public float speed = 10;
    public float maxJitter = 3.0f;
    private bool isJoystick;
    private Vector3 velocity;
    private Vector3 mousePos;
    private Vector3 mousePosPrev;
    private Vector3 mousePosWorld;
    private SpriteRenderer sprt;

    void Start()
    {
        velocity = Vector3.zero;
        mousePos = Input.mousePosition;
        mousePosPrev = mousePos;
        sprt = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sprt.sprite = handClosed;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            sprt.sprite = handOpened;
        }

        mousePos.z = 0f;
        mousePosPrev = mousePos;
        mousePos = Input.mousePosition;
        if ((mousePos - mousePosPrev).sqrMagnitude > maxJitter)
        {
            mousePos.z = Camera.main.transform.position.z * -1;
            mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
            mousePosWorld.z = transform.position.z;
            gameObject.transform.position = mousePosWorld;
        }
        else
        {
            /*velocity.x = Input.GetAxis("Horizontal");
            velocity.y = Input.GetAxis("Vertical");
            gameObject.transform.position += velocity * speed * Time.deltaTime;*/
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("collision 2d");
    }
}
