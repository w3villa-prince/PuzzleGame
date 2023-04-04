using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator gameObjectAnimation;
    public PlayerController playerController;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerController.setActive)
        {
            gameObjectAnimation.enabled = true;
        }
        else
        {
            gameObjectAnimation.enabled = false;
        }
    }
}
