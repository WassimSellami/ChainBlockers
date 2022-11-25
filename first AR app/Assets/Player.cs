using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string key = "0000";
    public string NickName = "7ammadi";

    public void SetPlayerKey(string keyToSet)
    {
        key = keyToSet;
    }
    public string GetPlayerKey()
    {
        return key;
    }
}
