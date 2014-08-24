using UnityEngine;
using System.Collections;
public class SimilarObject : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer renderer;
    private Vector3 initPosition;
    private int layerMask;
    public bool isReset;

    public GameObject areaPolygon;
    public GameObject areaRectangle;

    void Start()
    {
        Screen.showCursor = false;
        initPosition = gameObject.transform.position;
        layerMask = 1 << LayerMask.NameToLayer("DropArea");
        initPosition = gameObject.transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z * -1;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up");
        areaPolygon.GetComponent<BoxCollider2D>().enabled = true;
        areaRectangle.GetComponent<BoxCollider2D>().enabled = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;
        Vector3 origin = Camera.main.ScreenToWorldPoint(mousePosition);
        Ray ray = new Ray(Camera.main.ScreenToWorldPoint(mousePosition), Vector3.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, layerMask);
        foreach (RaycastHit h in hits)
        {
            string nameSphere = gameObject.name;
            string nameArea = h.collider.gameObject.name;
            string tagSphere = gameObject.tag;
            string tagArea = h.collider.gameObject.tag;
            Debug.Log(nameSphere + " dropped on " + nameArea);
            if (tagSphere.Equals(tagArea))
            {
                Debug.Log("Increment points");
                // further logic for your game here
            }
            else
            {
                // return the object to its inital position
                if(isReset)
                    gameObject.transform.position = initPosition;
            }
        }
        areaPolygon.GetComponent<BoxCollider2D>().enabled = false;
        areaRectangle.GetComponent<BoxCollider2D>().enabled = false;
    }

}
