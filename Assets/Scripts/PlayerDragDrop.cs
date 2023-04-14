using UnityEngine;

public class PlayerDragDrop : MonoBehaviour
{
    private Vector2 startTouchPos = new Vector2();
    private Vector2 finalTouchPos = new Vector2();
    public Vector3 currentTouchPos = new Vector3(0, 0, 0);
    public Vector3 setPos;
    [SerializeField] private DragHandller dragHandller;

    private GameObject hit;

    //  public DragHandller dragHandller;

    // Start is called before the first frame update
    private void Start()
    {
        // setPos = GetComponentInChildren<DragHandller>().SetPos;
        // setPos = dragHandller.SetPos;
    }

    public void MouseDragEvent(GameObject hit)
    {
        Debug.Log(" MouseDragEvent___________________________________________________________________________________");
        Debug.Log(Input.mousePosition.normalized);
        hit.transform.position = Input.mousePosition.normalized;
    }

    public void MouseDownEvent(GameObject hit)
    {
        Debug.Log("MouseDownEvent___________________________________________________________________________________");
        Debug.Log(Input.mousePosition.normalized);
        startTouchPos = Input.mousePosition.normalized;
    }

    public void MouseUpEvent(Vector3 pos)
    {
        Debug.Log(" MouseUpEvent___________________________________________________________________________________");

        if (pos != hit.transform.position)
        {
            hit.transform.position = currentTouchPos;
        }
        hit.transform.position = currentTouchPos;

        /* Debug.Log(Input.mousePosition.normalized);
         currentTouchPos = Input.mousePosition;

         if (currentTouchPos.x > startTouchPos.x)
         {
             finalTouchPos = currentTouchPos;
         }
         else
         {
             finalTouchPos = startTouchPos;
         }

         hit.transform.Translate(finalTouchPos);*/
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log(Input.mousePosition);
            RaycastHit hitInfo;  // = new RaycastHit();

            //  if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))//
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10f))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("Hit Info" + hitInfo.collider.name);

                    hit = hitInfo.collider.gameObject;
                    //  hit.transform.position = currentTouchPos;

                    /* if (dragHandller.SetPos != currentTouchPos)
                     {
                         Debug.Log(hit.tag);
                         hit.transform.position = currentTouchPos;
                     }*/

                    /* Debug.Log(hit.tag);
                     MouseDownEvent(hit);
                     MouseDragEvent(hit);*/
                }
            }
        }
    }
}
