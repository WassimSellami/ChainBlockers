using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClaimable : MonoBehaviour
{
    [SerializeField]
    private GameObject goldenKeyImage;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject, 100))
                {
                    if (hitObject.collider.tag == "Claimable")
                    {
                        hitObject.collider.gameObject.GetComponent<InfoBehavior>().OpenDescription();
                        return;
                    }
                    if (hitObject.collider.tag == "Key")
                    {
                        GameObject go = hitObject.collider.gameObject;
                        player.SetPlayerKey(go.GetComponent<KeyBehavior>().GetItemKey());
                        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 100, go.transform.position.z);
                        goldenKeyImage.SetActive(true);
                    }
                }
            }
        }
    }
}
