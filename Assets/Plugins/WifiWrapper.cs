using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class WifiWrapper
{
    private static readonly string[] Permissions = new string[]
        {
            "android.permission.INTERNET",
            "android.permission.ACCESS_WIFI_STATE",
            "android.permission.CHANGE_WIFI_STATE",
            "android.permission.ACCESS_NETWORK_STATE"
        };

    public static void RequestPermissions()
    {
        foreach (var permission in Permissions)
        {
            if (!Permission.HasUserAuthorizedPermission(permission))
            {
                Permission.RequestUserPermission(permission);
            }
        }
    }

    public static void Connect(string ssid, string key)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var androidPlugin = new AndroidJavaObject("com.flame.WifiPlugin.WifiPlugin", currentActivity))
                    {
                        androidPlugin.Call("Connect", ssid, key, new AndroidPluginCallback());
                    }
                }
            }
        }
    }  
}

class AndroidPluginCallback : AndroidJavaProxy
{
    public AndroidPluginCallback() : base("com.flame.WifiPlugin.WifiPluginCallback") { }

    public void onConnected(string ssid)
    {
        Debug.Log("Connected to WIFI " + ssid);
    }   
}
