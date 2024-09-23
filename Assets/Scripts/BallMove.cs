
using Unity.VisualScripting;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    public GameObject[] objectsToPlace; // Assign these in the inspector
    private GameObject selectedObject;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            if (selectedObject == null)
            {
                // Select an object
                SelectObject();
            }
            else
            {
                // Place the selected object
                PlaceObjectAtMousePosition();
            }
        }
    }

    void SelectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                selectedObject = hit.collider.gameObject;
                return;
            }
            
        }
    }

    void PlaceObjectAtMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject.CompareTag("place"))
            {

                if(hit.collider.gameObject.GetComponent<BallPlaced>().isEmptySpace==true)
                {
                    Debug.Log("Ball Color " + selectedObject.GetComponent<Ball>().ballcolor);
                    Debug.Log("Placed Color " + hit.collider.gameObject.GetComponent<BallPlaced>().placedColor);

                    if (selectedObject.GetComponent<Ball>().ballcolor == hit.collider.gameObject.GetComponent<BallPlaced>().placedColor)
                    {
                        // Check if the hit point is on a valid surface
                        Vector3 placementPosition = hit.point;
                        string currentcolor;
                        selectedObject.GetComponent<Ball>().ballplacedobj.isEmptySpace = true;
                        selectedObject.GetComponent<Ball>().ballplacedobj = hit.collider.gameObject.GetComponent<BallPlaced>();
                        selectedObject.GetComponent<Ball>().ballplacedobj.isEmptySpace = false;
                        // Instantiate the selected object at the hit point
                        // Instantiate(selectedObject, placementPosition, Quaternion.identity);
                        selectedObject.transform.position = hit.collider.gameObject.transform.GetChild(0).transform.position;
                        selectedObject = null; // Deselect the object
                        if (LevelManager.levelManagerInstance.WrongsBalls == 0)
                        {
                            Debug.Log("Level Won");
                        }
                        else
                        {
                            LevelManager.levelManagerInstance.WrongsBalls--;
                        }
                        
                        
                    }
                    else
                    {
                        selectedObject = null;
                    }
                }
            }
            
        }
    }
}
