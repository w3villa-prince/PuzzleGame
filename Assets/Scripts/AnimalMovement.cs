using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private bool moveLeft = false;
    [SerializeField] private bool moveRight = false;
    [SerializeField] private bool moveForward = false;
    [SerializeField] private bool moveBackward = false;

    [SerializeField] private bool movement = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (movement)
        {
            if (moveForward)
            {
                transform.Translate(new Vector3(0.001f, 0f, 0f));
            }
            if (moveBackward)
            {
                transform.Translate(new Vector3(-0.001f, 0f, 0f));
            }
            if (moveRight)
            {
                transform.Translate(new Vector3(0, 00f, 0.001f));
            }
            if (moveLeft)
            {
                transform.Translate(new Vector3(0f, 0f, -0.001f));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("*****************************************" + other.tag + "*******************************" + other.name);

        if (other.tag == "Player")
        {
            movement = true;
        }
        else
        {
            movement = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movement = true;
    }
}
