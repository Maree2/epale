using UnityEngine;
using System.Collections;

public class Boom : MiniGame 
{
    public BoomBomb bomb;
    public GameObject target;

    [Range(1f, 10f)]
    public float bombSpeed = 1f;

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
            bomb.transform.position += Vector3.up * bombSpeed * Time.deltaTime;
        }
        else if (currentState == MiniGameState.POST && !bomb.exploded)
        {
            bomb.exploded = true; 
            result = MiniGameResult.LOSE;
            finishedGame = true;
        }
	}

    void LateUpdate()
    {
        if (currentState == MiniGameState.PLAY && bomb.exploded)
        {            
            currentState = MiniGameState.POST;
            result = MiniGameResult.WIN;
            finishedGame = true;
        }
    }

}
