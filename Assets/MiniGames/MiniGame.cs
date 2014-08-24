using UnityEngine;
using System.Collections;

public class MiniGame : MonoBehaviour 
{
    public enum MiniGameState { PRE, PLAY, POST };
    public enum MiniGameResult { LOSE, WIN };


    [Range(1, 5)]
    public int preStateLength = 3;

    [Range(1, 10)]
    public int playStateLength = 5;

    [Range(1, 5)]
    public int postStateLength = 3;

    Timer preStateTimer, playStateTimer, postStateTimer;

    bool prepareTimeIsOver = false;    


    public bool finishedGame = false;

    protected MiniGameState currentState = MiniGameState.PRE;
    protected MiniGameResult result = MiniGameResult.LOSE;

    public GUIText hud;

    protected virtual void Awake()
    {
        currentState = MiniGameState.PRE;

        preStateTimer = new Timer(preStateLength);
        playStateTimer = new Timer(playStateLength);
        postStateTimer = new Timer(postStateLength);

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<GUIText>();
        hud.transform.position = new Vector3(0.5f, 0.5f, 0f);
        hud.fontSize = 100;
    }

	// Use this for initialization
	void Start () 
    {        

	}
	
	// Update is called once per frame
    protected virtual void Update() 
    {
        UpdateLevelTime();
	}

    void UpdateLevelTime()
    {
        if (currentState == MiniGameState.PLAY)
        {
            TimerState tState = playStateTimer.Update();

            if (tState == TimerState.FINISHED)
            {
                Debug.Log("State: POST");
                
                currentState = MiniGameState.POST;
                
                finishedGame = true;
            }
            else if (tState == TimerState.ONGOING)
            {
                hud.text = Mathf.FloorToInt(playStateTimer.RemainingTime + 1).ToString();
                //Debug.Log("Remaining: " + playStateTimer.RemainingTime);
            }
        }
        else if (currentState == MiniGameState.PRE)
        {
            TimerState tState = preStateTimer.Update();

            if (tState == TimerState.FINISHED)
            {
                Debug.Log("State: PLAY");

                preStateTimer.Reset();
                currentState = MiniGameState.PLAY;

                hud.transform.position = new Vector3(0.1f, 0.1f, 0f);
                hud.fontSize = 50;
            }
            else if (tState == TimerState.ONGOING)
            {
                hud.text = (Mathf.FloorToInt(preStateTimer.RemainingTime) + 1).ToString();
                //Debug.Log("Remaining: " + preStateTimer.RemainingTime);
            }
        } 
        else if (currentState == MiniGameState.POST)
        {
            TimerState tState = postStateTimer.Update();

            if (tState == TimerState.FINISHED)
            {
                Debug.Log("Returning to main game");
            }
            else if (tState == TimerState.ONGOING)
            {
                hud.text = "Post: " + (Mathf.FloorToInt(postStateTimer.RemainingTime) + 1).ToString();
            }
        }
    }

}
