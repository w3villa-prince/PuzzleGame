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

    [SerializeField] private AudioSource moveSounds;
    [SerializeField] private AudioSource wrongSounds;

    public bool setActive = false;

    // Start is called before the first frame update
    private void Start()
    {
        moveSounds.Stop();
        wrongSounds.Stop();
    }

    private void UpdateXIncrement()
    {
        // Vector3 updatePosition = gameObject.transform.position + updatePosX;

        // gameObject.transform.position = updatePosition;
        // DOTween.KillAll();
        // Debug.Log(transform.position.x);
        StartCoroutine(MoveAmimation(updatePosZ));
        //transform.DOMoveX(updatePosX.x, .1f);
        // Debug.Log(transform.position.x);
        // transform.Translate(updatePosZ);
    }

    private void UpdateZIncrement()
    {
        // Vector3 updatePosition = gameObject.transform.position + updatePosZ;

        //gameObject.transform.position = updatePosition;
        // transform.Translate(updatePosX);
        //  DOTween.KillAll();
        // Debug.Log(transform.position.z);
        //transform.DOMoveZ(updatePosZ.z, .1f);
        StartCoroutine(MoveAmimation(updatePosX));
        // Debug.Log(transform.position.z);
    }

    private void UpdateXDecrement()
    {
        //Vector3 updatePosition = gameObject.transform.position - updatePosX;

        // gameObject.transform.position = updatePosition;

        // transform.Translate(-updatePosZ);
        //Debug.Log(transform.position);
        // DOTween.KillAll();
        //Debug.Log(transform.position.x);
        //transform.DOMoveX(-updatePosX.x, .1f);
        StartCoroutine(MoveAmimation(-updatePosZ));
        // Debug.Log(transform.position.x);
    }

    private void UpdateZDecrement()
    {
        // Vector3 updatePosition = gameObject.transform.position - updatePosZ;

        // gameObject.transform.position = updatePosition;

        //Debug.Log(transform.position);

        //transform.Translate(-updatePosX);

        // Debug.Log(transform.position);
        // DOTween.KillAll();
        //  Debug.Log(transform.position.z);

        StartCoroutine(MoveAmimation(-updatePosX));
        //transform.DOMoveZ(-updatePosZ.z, .1f);
        // Debug.Log(transform.position.z);
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

            if (GetComponentInChildren<ExtraBoxColliderHandeller>())
            {
                rightCollision.movement = true;
                leftCollision.movement = true;
                backCollision.movement = true;
                frontCollision.movement = true;
            }
        }
    }

    public void UpdatePositionValue()
    {
        if (Input.GetKeyUp(KeyCode.W) && movement_In_Z_Pos && rightCollision.movement)
        {
            moveSounds.Play();
            wrongSounds.Stop();
            Debug.Log("rightCollision.movement" + rightCollision.movement);
            Debug.Log(" update positon z+ ");
            UpdateZIncrement();
        }
        else if (Input.GetKeyUp(KeyCode.W) && movement_In_Z_Pos)
        {
            moveSounds.Stop();
            wrongSounds.Play();
            StartCoroutine(WrongMoveAmimation(updatePosX));
        }

        if (Input.GetKeyUp(KeyCode.S) && movement_In_Z_Pos && leftCollision.movement)
        {
            moveSounds.Play();
            wrongSounds.Stop();
            Debug.Log(" leftCollision.movement" + leftCollision.movement);
            Debug.Log(" update positon Z- ");
            UpdateZDecrement();
        }
        else if (Input.GetKeyUp(KeyCode.S) && movement_In_Z_Pos)
        {
            moveSounds.Stop();
            wrongSounds.Play();
            StartCoroutine(WrongMoveAmimation(-updatePosX));
        }

        if (Input.GetKeyUp(KeyCode.A) && movement_In_X_Pos && backCollision.movement)
        {
            moveSounds.Play();
            wrongSounds.Stop();
            Debug.Log("backCollision.movement" + backCollision.movement);
            Debug.Log(" update positon X+ ");

            UpdateXDecrement();
        }
        else if (Input.GetKeyUp(KeyCode.A) && movement_In_X_Pos)
        {
            StartCoroutine(WrongMoveAmimation(-updatePosZ));
            moveSounds.Stop();
            wrongSounds.Play();
        }

        if (Input.GetKeyUp(KeyCode.D) && movement_In_X_Pos && frontCollision.movement)
        {
            moveSounds.Play();
            wrongSounds.Stop();
            Debug.Log("frontCollision.movement" + frontCollision.movement);
            Debug.Log(" update positon X- ");
            UpdateXIncrement();
        }
        else if (Input.GetKeyUp(KeyCode.D) && movement_In_X_Pos)
        {
            moveSounds.Stop();
            wrongSounds.Play();
            StartCoroutine(WrongMoveAmimation(-updatePosZ));
        }
    }

    private IEnumerator MoveAmimation(Vector3 pos)
    {
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
    }

    private IEnumerator WrongMoveAmimation(Vector3 pos)
    {
        transform.Translate(pos / 5);
        yield return new WaitForSeconds(.01f);
        transform.Translate(-pos / 5);
    }
}
