using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class CollidablePlayer : MonoBehaviour 
{
    [Range(1, 5)]
    public int levelLives = 3;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision!!");
    }
}
