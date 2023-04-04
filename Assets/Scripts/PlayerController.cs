using System.Collections;
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
    private static float t = 0.0f;
    public bool setActive = false;

    public Animator gameObjectAnimation;

    // Start is called before the first frame update
    private void Start()
    {
        gameObjectAnimation.enabled = false;
    }

    private void UpdateXIncrement()
    {
        // transform.Translate(updatePosZ);
        StartCoroutine(UpdateXIncrementAnimation());
    }

    private IEnumerator UpdateXIncrementAnimation()
    {
        gameObjectAnimation.enabled = true;
        // Debug.Log(gameObjectAnimation.enabled);

        transform.position = transform.position + updatePosX / 5; ;
        //Debug.Log(transform.position);

        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosX / 5;
        // Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosX / 5;
        // Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosX / 5;
        // Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosX / 5;
        // Debug.Log(transform.position);

        gameObjectAnimation.enabled = false;
    }

    private void UpdateZIncrement()
    {
        // transform.Translate(updatePosX);
        StartCoroutine(UpdateZIncrementAnimation());
    }

    private IEnumerator UpdateZIncrementAnimation()
    {
        gameObjectAnimation.enabled = true;

        transform.position = transform.position + updatePosZ / 5; ;
        // Debug.Log(transform.position);

        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosZ / 5;
        //Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosZ / 5;
        //Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosZ / 5;
        // Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position + updatePosZ / 5;
        //Debug.Log(transform.position);

        gameObjectAnimation.enabled = false;
    }

    private void UpdateXDecrement()
    { // transform.Translate(-updatePosZ);
        StartCoroutine(UpdateXDecrementAnimation());
    }

    private IEnumerator UpdateXDecrementAnimation()
    {
        gameObjectAnimation.enabled = true;
        // Debug.Log(gameObjectAnimation.enabled);

        // Debug.Log(transform.position);

        transform.position = transform.position - updatePosX / 5; ;
        //Debug.Log(transform.position);

        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosX / 5;
        //Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosX / 5;
        // Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosX / 5;
        //Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosX / 5;
        // Debug.Log(transform.position);

        gameObjectAnimation.enabled = false;
    }

    private void UpdateZDecrement()
    {
        // transform.Translate(-updatePosX);

        StartCoroutine(UpdateZDecrementAnimation());
    }

    private IEnumerator UpdateZDecrementAnimation()
    {
        gameObjectAnimation.enabled = true;
        Debug.Log(gameObjectAnimation.enabled);
        //Vector3 updatePosition = gameObject.tr
        // Vector3 updatePosition = gameObject.transform.position - updatePosZ;

        // gameObject.transform.position = updatePosition;

        Debug.Log(transform.position);

        // transform.Translate(-updatePosX);

        Debug.Log(transform.position);

        //yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosZ / 5; ;
        Debug.Log(transform.position);

        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosZ / 5;
        Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosZ / 5;
        Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosZ / 5;
        Debug.Log(transform.position);
        yield return new WaitForSeconds(.4f);
        transform.position = transform.position - updatePosZ / 5;
        Debug.Log(transform.position);

        gameObjectAnimation.enabled = false;
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
            // Debug.Log(frontCollision.movement);
            // Debug.Log(" update positon z+ ");

            UpdateZIncrement();
        }
        else if (Input.GetKeyDown(KeyCode.S) && movement_In_Z_Pos && leftCollision.movement)
        {
            //Debug.Log(backCollision.movement);
            // Debug.Log(" update positon Z- ");
            UpdateZDecrement();
        }
        else if (Input.GetKeyDown(KeyCode.A) && movement_In_X_Pos && frontCollision.movement)
        {
            //Debug.Log(" update positon X+ ");

            UpdateXIncrement();
        }
        else if (Input.GetKeyDown(KeyCode.D) && movement_In_X_Pos && backCollision.movement)
        {
            // Debug.Log(" update positon X- ");
            UpdateXDecrement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collision Detceat ");
        if (collision.gameObject.CompareTag("GameController"))
        {
            Debug.Log("Collision Detceat ");

            //collidervalue = true;
        }
        else
        {
            // collidervalue = false;
        }
    }
}
