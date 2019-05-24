using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiTest : MonoBehaviour
{
    public InputField ssid;
    public InputField key;
    
    void Start()
    {
        WifiWrapper.RequestPermissions();       
    }

    public void Connect()
    {
        WifiWrapper.Connect(ssid.text, key.text);
    }


}
