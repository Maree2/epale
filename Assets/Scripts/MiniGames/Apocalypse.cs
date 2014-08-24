using UnityEngine;
using System.Collections;

public class Apocalypse : MonoBehaviour 
{
    [Range(1, 10)]
    public int totalLevelTime = 5;

    Timer prepareTimer, levelTimer;

    bool prepareTimeIsOver = false;    

    void Awake()
    {
        prepareTimer = new Timer(3);
        levelTimer = new Timer(totalLevelTime + 1f);
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (prepareTimeIsOver)
        {
            TimerState tState = levelTimer.Update();

            if (tState == TimerState.FINISHED)
            {
                Debug.Log("Level END");
                Destroy(gameObject);
            }
            else if (tState == TimerState.ONGOING)
            {
                gameObject.guiText.text = Mathf.FloorToInt(levelTimer.RemainingTime).ToString();
                //Debug.Log("Remaining: " + playStateTimer.RemainingTime);
            }
        }
        else 
        {
            TimerState tState = prepareTimer.Update();

            if (tState == TimerState.FINISHED)
            {
                Debug.Log("Level START");
                prepareTimeIsOver = true;
                gameObject.transform.position = new Vector3(0.1f, 0.1f, 0f);
                gameObject.guiText.fontSize = 50;
            }
            else if (tState == TimerState.ONGOING)
            {
                gameObject.guiText.text = (Mathf.FloorToInt(prepareTimer.RemainingTime) + 1).ToString();
                //Debug.Log("Remaining: " + preStateTimer.RemainingTime);
            }
        }
	}
}
