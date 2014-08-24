using UnityEngine;
using System.Collections;

public class ObjectWithWeight : MonoBehaviour 
{
    public enum WeightType { LIGHT, MEDIUM, HEAVY };

    public WeightType typeOfWeight = WeightType.LIGHT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetWeight()
    {
        SetWeight(EnumHelper.GetRandomEnum<WeightType>());
    }

    public void SetWeight(WeightType wt)
    {
        typeOfWeight = wt;
    }

    public int WeightToNumber()
    {
        switch (typeOfWeight)
        {
            case WeightType.LIGHT:
                return 1;
            case WeightType.MEDIUM:
                return 2;
            case WeightType.HEAVY:
                return 3;
            default:
                return 0;
        }
    }
}
