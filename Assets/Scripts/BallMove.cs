
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
                // Check if the hit point is on a valid surface
                Vector3 placementPosition = hit.point;

                // Instantiate the selected object at the hit point
                // Instantiate(selectedObject, placementPosition, Quaternion.identity);
                selectedObject.transform.position = hit.collider.gameObject.transform.GetChild(0).transform.position;
                selectedObject = null; // Deselect the object
            }
            
        }
    }
}
