using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    private Vector3 position;

    private GameObject hitObject;

    public GameObject gameObjectActiveUI;
    private bool hit = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void ActivePlayerUI(GameObject hitGameObject)
    {
        Vector3 uiPosition = new Vector3(0, 0, 0);

        Debug.Log(" active Player position " + position);
        gameObjectActiveUI.transform.position = hitGameObject.transform.position + new Vector3(0, .06f, 0);
        gameObjectActiveUI.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //  if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))//
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "Player")
            {
                hit = true;
                if (hitObject != null)
                {
                    if (hitObject.GetComponentInParent<PlayerController>().setActive)
                    {
                        hitObject.GetComponentInParent<PlayerController>().setActive = false;
                    }
                }
                Debug.Log(hitInfo.collider.name);
                print("It's working");

                hitObject = hitInfo.collider.gameObject;
                // ActivePlayerUI(hitObject);

                hitObject.GetComponentInParent<PlayerController>().setActive = true;
            }
            else // (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag != "Player")
            {
                // hitInfo.collider.gameObject.GetComponentInParent<PlayerController>().setActive = false;

                if (hit)
                {
                    hitObject.GetComponentInParent<PlayerController>().setActive = false;
                    hit = false;
                }
            }
        }
    }
}
