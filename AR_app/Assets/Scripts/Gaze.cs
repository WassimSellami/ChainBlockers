using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    private List<InfoBehavior> infos = new List<InfoBehavior>();   

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Claimable")
                {
                    openInfo(hit.collider.gameObject.GetComponent<InfoBehavior>());
                }
            }
            else
            {
                closeAllInfos();
            }
        }
    }
    public void UpdateInfosAndPanelsList()
    {
        infos.AddRange(FindObjectsOfType<InfoBehavior>());
    }
    private void openInfo(InfoBehavior desiredInfo)
    {
        foreach(InfoBehavior info in infos)
        {
            if(info == desiredInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }
    private void closeAllInfos()
    {
        foreach (InfoBehavior info in infos)
        {
            info.CloseInfo();
        }
    }
}
