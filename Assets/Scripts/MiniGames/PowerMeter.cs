using UnityEngine;
using System.Collections;

public class PowerMeter : MiniGame 
{
    public Transform needle;
    public Renderer requiredPowerRenderer;

    [Range(1, 30)]
    public int meterSpeed = 1;
    
    float maxMeterPower = 10f;

    [Range(0, 10)]
    public int requiredMeterPower = 8;

    float currentMeterPower = 0f;
    bool charging = true;

    public Transform minPosition, maxPosition;

    bool needleStopped = false;

    protected override void Awake()
    {
        base.Awake();
    }

	// Use this for initialization
	void Start () 
    {
        needle.position = minPosition.transform.position;

        requiredPowerRenderer.material.SetFloat("_Progress", requiredMeterPower / 10f); 
	}
	
	// Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (currentState == MiniGameState.PLAY)
        {
            CheckInput();
            UpdateNeedle();
        }

	}

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            needleStopped = true;

            if (currentMeterPower >= requiredMeterPower)
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

    void UpdateNeedle()
    {
        if (needleStopped)
            return;

        if (charging)
        {
            currentMeterPower += meterSpeed * Time.deltaTime;
            if (currentMeterPower >= maxMeterPower)
            {
                charging = false;
                currentMeterPower = maxMeterPower;
                Debug.Log("MAX");
            }
        }
        else
        {
            currentMeterPower -= meterSpeed * Time.deltaTime;
            if (currentMeterPower <= 0f)
            {
                charging = true;
                currentMeterPower = 0f;
                Debug.Log("MIN");
            }
        }

        if (currentMeterPower >= requiredMeterPower)
        {
            Debug.Log("GOOD LEVEL");
        }

        needle.position = Vector3.Lerp(minPosition.transform.position, maxPosition.transform.position, currentMeterPower / 10f);

        Debug.Log("Power: " + Mathf.FloorToInt(currentMeterPower));
    }

}
