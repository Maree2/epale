using UnityEngine;
using System.Collections;

public class FindIt : MiniGame 
{
    public GameObject alienPrefab;
    public Transform mask;

    Alien alien;

    protected override void Awake()
    {
        base.Awake();

        GameObject o = alienPrefab.Clone(transform);
        o.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), -0.4f);

        alien = o.GetComponent<Alien>();
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
            UpdateMask();

            if (alien.found)
            {
                currentState = MiniGameState.POST;
                result = MiniGameResult.WIN;
            }
        }
        else if (currentState == MiniGameState.POST && !alien.found)
        {
            alien.found = true;
            result = MiniGameResult.LOSE;
            finishedGame = true;
        }
	}
    
    void UpdateMask()
    {
        mask.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        mask.position = mask.position.WithZ(-0.5f);
    }

}
