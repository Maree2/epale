using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChooseWeight : ChooseSide
{
    public GameObject weightPrefab;
    int numberOfObjects = 3;

    public Transform leftSide, rightSide;

    List<ObjectWithWeight> objectsToTheLeft, objectsToTheRight;

    void Awake()
    {
        objectsToTheLeft = new List<ObjectWithWeight>();
        objectsToTheRight = new List<ObjectWithWeight>();
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
        int leftSideWeight = 0;
        int rightSideWeight = 0;

        //Generate Left side
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject o = weightPrefab.Clone(leftSide);
            ObjectWithWeight ow = o.GetComponent<ObjectWithWeight>();
            ow.SetWeight();
            leftSideWeight += ow.WeightToNumber();
            //objectsToTheLeft.Add(ow);
        }

        do
        {
            objectsToTheRight.Clear();

            //Generate right side
            for (int i = 0; i < numberOfObjects; i++)
            {
                GameObject o = weightPrefab.Clone(rightSide);
                ObjectWithWeight ow = o.GetComponent<ObjectWithWeight>();
                ow.SetWeight();
                rightSideWeight += ow.WeightToNumber();
                //objectsToTheRight.Add(ow);  
            }
            leftIsSide = leftSideWeight > rightSideWeight;

        }
        while (leftSideWeight == rightSideWeight);

        Debug.Log("Left? " + leftIsSide);
    }
}
