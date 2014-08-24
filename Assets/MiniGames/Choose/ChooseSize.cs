using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChooseSize : ChooseSide
{
    public GameObject typeAPrefab, typeBPrefab;
    int numberOfObjects = 9;

    public Transform aSide, bSide;

    List<ObjectWithWeight> objectsA, objectsB;

    void Awake()
    {
        objectsA = new List<ObjectWithWeight>();
        objectsB = new List<ObjectWithWeight>();
        GenerateLevel();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update()
    {
        base.Update();
    }

    void GenerateLevel()
    {
        int numberOfA = 0;
        int numberOfB = 0;

        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject o;
            switch (RandomHelper.RandomSign())
            {
                case -1:
                    o = typeAPrefab.Clone(aSide);
                    numberOfA++;
                    break;
                case 1:
                    o = typeBPrefab.Clone(bSide);
                    numberOfB++;
                    break;
                default:
                    break;
            }
        }

        leftIsSide = numberOfA > numberOfB;

        Debug.Log("Left? " + leftIsSide);
    }
}
