using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform sectionInfo;
    [SerializeField]
    private GameObject descriptionPanel;
    private float speed = 6f;
    private Vector3 desiredScale = Vector3.zero;

    void Update()
    {
        sectionInfo.localScale = Vector3.Lerp(sectionInfo.localScale, desiredScale, Time.deltaTime * speed);
    }
    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }

    public void OpenDescription()
    {
        descriptionPanel.gameObject.SetActive(true);
    }

}
