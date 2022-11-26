using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClaimItem : MonoBehaviour
{
    [SerializeField]
    private GameObject acceptancePanel;
    [SerializeField]
    private GameObject denialPanelWithoutKey;
    [SerializeField]
    private GameObject denialPanelWithKey;
    [SerializeField]
    private GameObject descriptionPanel;
    [SerializeField]
    private GameObject toBuyPanel;
    [SerializeField]
    private GameObject toClaimPanel;
    [SerializeField]
    private Text ownerText;
    private Player player;
    private KeyBehavior keyBehavior;
    private SceneManager sceneManager;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
        sceneManager = FindObjectOfType<SceneManager>();
    }
    public void ClaimClicked()
    {
        keyBehavior = FindObjectOfType<KeyBehavior>();
        descriptionPanel.SetActive(false);
        if (player.GetPlayerKey() == "0000")
        {
            denialPanelWithoutKey.SetActive(true);
            return;
        }
        if (keyBehavior.GetItemKey() == player.GetPlayerKey())
        {
            acceptancePanel.SetActive(true);
            toBuyPanel.SetActive(true);
            toClaimPanel.SetActive(false);
            ownerText.text = player.NickName;
            GameObject.FindGameObjectWithTag("Icon").SetActive(false);
            //keyBehavior.gameObject.SetActive(false);
            sceneManager.SetActiveObject();
            return;
        }
        denialPanelWithKey.SetActive(true);
    }
}
