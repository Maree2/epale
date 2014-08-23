using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    public string talkTag = "Epale";
    public float speed = 10;
    bool talk = false;
    string nextMinigame;

    void Start()
    {
        nextMinigame = "";
        talk = false;
    }

    void Update()
    {
        float velX = Input.GetAxis("Horizontal");
        float velY = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(velX, 0.0f, velY);
        vec = Quaternion.AngleAxis(45, Vector3.up) * vec;
        Vector3 oldPos = gameObject.transform.position;
        gameObject.transform.Translate(vec * speed * Time.deltaTime, Space.World);
        Vector3 vel = gameObject.transform.position - oldPos;
        if (vel.sqrMagnitude > 0.0f)
        {
            vel = vel + gameObject.transform.position;
            gameObject.transform.LookAt(vel);
        }

        if (Input.GetButtonDown("Fire1") && talk)
        {
            Application.LoadLevel(nextMinigame);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals(talkTag))
        {
            talk = true;
            nextMinigame = c.gameObject.GetComponent<Epale>().minigame;
        }
            
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag.Equals(talkTag))
        {
            talk = false;
            nextMinigame = "";
        }
    }
}
