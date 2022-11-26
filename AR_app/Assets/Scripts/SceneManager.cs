using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject elephantIcon;
    [SerializeField]
    private GameObject worriorIcon;
    public void SetActiveObject()
    {
        worriorIcon.SetActive(true);
        elephantIcon.SetActive(true);
    }
}
