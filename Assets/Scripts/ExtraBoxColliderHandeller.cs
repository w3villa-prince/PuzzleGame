using UnityEngine;

public class ExtraBoxColliderHandeller : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject extraBoxCollider1;
    [SerializeField] private GameObject extraBoxCollider2;
    public bool extraBoxAction = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void ExtraBoxColliderHandller(bool status)
    {
        /* }*/
        extraBoxCollider1.SetActive(status);
        // extraBoxCollider1.GetComponent<CollisionHandller>().enabled = status;

        extraBoxCollider2.SetActive(status);
        // extraBoxCollider2.GetComponent<CollisionHandller>().enabled = status;
    }

    // Update is called once per frame
    private void Update()
    {/*
        if (!extraBoxCollider1.GetComponent<CollisionHandller>().movement)
        {
            extraBoxCollider1.GetComponent<CollisionHandller>().movement = true;
        }
        if (!extraBoxCollider2.GetComponent<CollisionHandller>().movement)
        {
            extraBoxCollider2.GetComponent<CollisionHandller>().movement = true;
        }*/
        ExtraBoxColliderHandller(playerController.setActive);
    }
}
