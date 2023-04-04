using UnityEngine;

public class CollisionHandller : MonoBehaviour
{
    [SerializeField] private GameObject levelDoneUI;
    public bool movement = true;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(" tigger enter" + other.name);
        movement = false;

        Debug.Log(movement);

        if (other.name == "Target")
        {
            levelDoneUI.SetActive(true);
            // Debug.Log("target Done ");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log(" tigger Exit");
        movement = true;
    }
}
