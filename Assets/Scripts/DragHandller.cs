using System;
using UnityEngine;

public class DragHandller : MonoBehaviour
{
    //  [SerializeField] private GameObject resize;
    private Vector3 startTouchPos = new Vector3();

    private Vector3 mousePosition;
    private Vector3 currentMousePosition;
    private Vector3 lastMousePostion;

    // public CollisionHandller rightCollision;
    // / public CollisionHandller leftCollision;

    [SerializeField] private CollisionHandller frontCollision;
    [SerializeField] private CollisionHandller backCollision;
    [SerializeField] private bool moveDirectionX = true;

    // [SerializeField] private PlayerDragDrop playerDrag;

    private void start()
    {
    }

    private Vector3 GetMousePOs()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        Debug.Log(currentMousePosition);
        mousePosition = Input.mousePosition - GetMousePOs();

        /// resize.transform.localScale = new Vector3(.8f, .8f, .8f);
    }

    private void OnMouseDrag()
    {
        /* startTouchPos.x = transform.position.x;
         startTouchPos.z = transform.position.z;
         startTouchPos.y = transform.position.y;*/

        // Debug.Log("Mouse Drag ");
        startTouchPos = transform.position;
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        lastMousePostion = currentMousePosition;
        //transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);

        if (moveDirectionX)
        {
            Debug.Log("starTouchPOs_________________________" + startTouchPos + "----------" + currentMousePosition.x);

            if (frontCollision.movement && currentMousePosition.x > startTouchPos.x)
            {
                Debug.Log("FrontCollider working __________________________");
                transform.position = new Vector3(currentMousePosition.x, 0, startTouchPos.z);
            }
            else if (backCollision.movement && currentMousePosition.x < startTouchPos.x)
            {
                Debug.Log("BackCollider working __________________________");
                transform.position = new Vector3(currentMousePosition.x, 0, startTouchPos.z);
            }
        }
        else
        {
            if (frontCollision.movement && currentMousePosition.x > startTouchPos.x)
            {
                Debug.Log("FrontCollider working __________________________");
                transform.position = new Vector3(startTouchPos.x, 0, currentMousePosition.z);
            }
            else if (backCollision.movement && currentMousePosition.x < startTouchPos.x)
            {
                Debug.Log("BackCollider working __________________________");
                transform.position = new Vector3(startTouchPos.x, 0, currentMousePosition.z);
            }
        }

        /*     if (backCollision.movement)
             {
                 transform.position = new Vector3(startTouchPos.x, 0, SetPos.z);
             }*/
        // transform.position = SetPos;
    }

    private void OnMouseUp()
    {
        //resize.transform.localScale = new Vector3(1, 1, 1);
        SetLastPositionOfActivePlayer(lastMousePostion);
        // playerDrag.MouseUpEvent(SetPos);
        Debug.Log(lastMousePostion);
    }

    public void SetLastPositionOfActivePlayer(Vector3 pos)
    {
        Debug.Log(" On Mouse UP_______________________________________ " + (int)Math.Round(pos.x) + "------------------------" + (int)pos.x + "-------------------");
        if (moveDirectionX)
        {
            float check = pos.x - (int)pos.x;
            Debug.Log(check);
            if (check > .5f)
            {
                transform.position = new Vector3((int)Math.Round(pos.x), 0, startTouchPos.z);
            }
            else
            {
                transform.position = new Vector3((int)pos.x, 0, startTouchPos.z);
            }
        }
        else
        {
            float check = pos.z - (int)pos.z;
            Debug.Log(check);
            if (check > .5f)
            {
                transform.position = new Vector3(startTouchPos.x, 0, (int)Math.Round(pos.z));
            }
            else
            {
                transform.position = new Vector3(startTouchPos.x, 0, (int)pos.z);
            }
        }
    }
}
