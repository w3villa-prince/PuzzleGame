using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 updatePosX = new Vector3(1, 0, 0);
    [SerializeField] private Vector3 updatePosZ = new Vector3(0, 0, 1);

    public GameObject gameObjectUI;

    [SerializeField] private bool movement_In_X_Pos = false;
    [SerializeField] private bool movement_In_Z_Pos = false;

    public CollisionHandller rightCollision;
    public CollisionHandller leftCollision;
    public CollisionHandller frontCollision;
    public CollisionHandller backCollision;

    public bool setActive = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void UpdateXIncrement()
    {
        // Vector3 updatePosition = gameObject.transform.position + updatePosX;

        // gameObject.transform.position = updatePosition;

        transform.Translate(updatePosZ);
    }

    private void UpdateZIncrement()
    {
        // Vector3 updatePosition = gameObject.transform.position + updatePosZ;

        //gameObject.transform.position = updatePosition;
        transform.Translate(updatePosX);
    }

    private void UpdateXDecrement()
    {
        //Vector3 updatePosition = gameObject.transform.position - updatePosX;

        // gameObject.transform.position = updatePosition;

        transform.Translate(-updatePosZ);
        Debug.Log(transform.position);
    }

    private void UpdateZDecrement()
    {
        // Vector3 updatePosition = gameObject.transform.position - updatePosZ;

        // gameObject.transform.position = updatePosition;

        Debug.Log(transform.position);

        transform.Translate(-updatePosX);

        Debug.Log(transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (setActive)
        {
            UpdatePositionValue();

            gameObjectUI.SetActive(true);
            gameObjectUI.transform.position = transform.position + new Vector3(0, .07f, 0);
        }
        else
        {
            gameObjectUI.SetActive(false);
        }
        ///
        /**/
    }

    public void UpdatePositionValue()
    {
        if (Input.GetKeyDown(KeyCode.W) && movement_In_Z_Pos && rightCollision.movement)
        {
            Debug.Log(frontCollision.movement);
            Debug.Log(" update positon z+ ");
            UpdateZIncrement();
        }

        if (Input.GetKeyDown(KeyCode.S) && movement_In_Z_Pos && leftCollision.movement)
        {
            Debug.Log(backCollision.movement);
            Debug.Log(" update positon Z- ");
            UpdateZDecrement();
        }

        if (Input.GetKeyDown(KeyCode.A) && movement_In_X_Pos && frontCollision.movement)
        {
            Debug.Log(" update positon X+ ");

            UpdateXIncrement();
        }
        if (Input.GetKeyDown(KeyCode.D) && movement_In_X_Pos && backCollision.movement)
        {
            Debug.Log(" update positon X- ");
            UpdateXDecrement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collision Detceat ");
        if (collision.gameObject.CompareTag("GameController"))
        {
            Debug.Log("Collision Detceat ");

            // collidervalue = true;
        }
        else
        {
            // collidervalue = false;
        }
    }
}
