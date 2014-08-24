using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountThem : MiniGame 
{
    public GameObject objectPrefab;

    int numberOfObjects;

    List<GameObject> movingObjects;

    int playerCounter = 0;

    bool x = false;

    protected override void Awake()
    {
        base.Awake();

        numberOfObjects = Random.Range(5, 15);

        movingObjects = new List<GameObject>();

        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject o = objectPrefab.Clone(this.transform);

            movingObjects.Add(o);
        }
    }

	// Use this for initialization
	void Start () 
    {
        Debug.Log("Total: " + numberOfObjects);
	}
	
	// Update is called once per frame
	protected override void Update () 
    {
        base.Update();

        if (currentState == MiniGameState.PLAY)
        {
            PlayerInput();
        }
        else if (currentState == MiniGameState.POST && !x)
        {
            Debug.Log("Recorded: " + playerCounter);
            if (playerCounter == numberOfObjects)
            {
                Debug.Log("WIN");
            }
            else
            {
                Debug.Log("FAIL");
            }
            x = true;
        }
	}

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCounter++;
            Debug.Log("Recorded: " + playerCounter);        
        }
    }

}
