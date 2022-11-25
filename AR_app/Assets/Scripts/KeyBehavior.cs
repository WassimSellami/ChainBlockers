using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    private float speed = 6f;
    private Vector3 desiredScale = Vector3.zero;
    private string validItemKey = "9999";

    private void Start()
    {
        validItemKey = key.name;
    }
    public string GetItemKey()
    {
        return validItemKey;
    }
void Update()
    {
        //clickMePanel.localScale = Vector3.Lerp(clickMePanel.localScale, desiredScale, Time.deltaTime * speed);
    }
    public void OpenClickMePanel()
    {
        desiredScale = Vector3.one;
    }

    public void CloseClickMePanel()
    {
        desiredScale = Vector3.zero;
    }
}
