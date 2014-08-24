using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimilarDirector : MonoBehaviour {

    public bool isResetPiece = true;
    public GameObject areaPolygon;
    public GameObject areaRectangle;
    public GameObject cursor;
    public GameObject[] objects;
    public Sprite[] sprites;

    int selected = 0;
    
    private SpriteRenderer renderer;

    void Start()
    {
        int i;
        List<int> spritesId = new List<int>();
        for (i = 0; i < sprites.Length; i++)
            spritesId.Add(i);

        for (i = 0; i < objects.Length; i++)
        {
            int rand = Random.Range(0, spritesId.Count - 1);
            int n = spritesId[rand];
            spritesId.RemoveAt(rand);
            renderer = objects[i].GetComponent<SpriteRenderer>();
            renderer.sprite = sprites[n];
            objects[i].tag = "DragPentagon";
            if (!renderer.sprite.name.Contains("polygon"))
                objects[i].tag = "DragSquare";
            objects[i].GetComponent<SimilarObject>().isReset = isResetPiece;
            objects[i].GetComponent<SimilarObject>().areaPolygon = areaPolygon;
            objects[i].GetComponent<SimilarObject>().areaRectangle = areaRectangle;
        }

    }

    
}
