using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BoomBomb : MonoBehaviour 
{
    public bool exploded = false;

    void Awake()
    {
        particleSystem.Stop();
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (exploded)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            exploded = true;
            particleSystem.Play();
            renderer.enabled = false;
        }
    }
    
}
