using UnityEngine;
using System.Collections;

public class ChooseSide : MiniGame 
{
    public bool leftIsSide = false;

    protected override void Awake()
    {
        base.Awake();
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (currentState == MiniGameState.PLAY)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CheckSelection(true);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckSelection(false);
            }
        }
	}

    void CheckSelection(bool selectedLeft)
    {
        if (selectedLeft == leftIsSide)
        {
            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("LOSE");
        }
        finishedGame = true;
    }
}
