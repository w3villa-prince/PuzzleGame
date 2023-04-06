using UnityEngine;

public class ExtraBoxColliderHandeller : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject extraBoxCollider1;
    [SerializeField] private GameObject extraBoxCollider2;
    // public bool extraBoxAction = true;

    private void Start()
    {
    }

    public void ExtraBoxColliderHandller(bool status)
    {
        extraBoxCollider1.SetActive(status);

        extraBoxCollider2.SetActive(status);
    }

    private void Update()
    {
        ExtraBoxColliderHandller(playerController.setActive);
    }
}
