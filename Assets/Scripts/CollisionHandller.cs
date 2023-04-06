using UnityEngine;

public class CollisionHandller : MonoBehaviour
{
    [SerializeField] private GameObject levelDoneUI;
    public bool movement = true;
    [SerializeField] private bool gamePlayer = false;

    private void Start()
    {
        movement = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(" tigger enter" + other.name);
        movement = false;

        //Debug.Log(movement);

        if (other.name == "Target" && gamePlayer)
        {
            levelDoneUI.SetActive(true);
            // Debug.Log("target Done ");
        }
    }

    private void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(" tigger Exit");
        movement = true;
    }
}
