using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour 
{
    public bool found = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseEnter()
    {
        found = true;
    }
}
