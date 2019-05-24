package com.flame.WifiPlugin;

import android.Manifest;
import android.net.wifi.WifiConfiguration;
import android.net.wifi.WifiManager;
import android.content.Context; 
import android.app.Activity;

public class WifiPlugin
{	
	private Context context;

	public WifiPlugin(Context context)
	{
		this.context = context;
	}

	public void Connect(String ssid, String key, WifiPluginCallback callback)
	{
		WifiConfiguration wifiConfig = new WifiConfiguration();
		wifiConfig.SSID = String.format("\"%s\"", ssid);
		wifiConfig.preSharedKey = String.format("\"%s\"", key);

		WifiManager wifiManager = (WifiManager)context.getSystemService(Context.WIFI_SERVICE);
		//remember id
		int netId = wifiManager.addNetwork(wifiConfig);
		wifiManager.disconnect();
		wifiManager.enableNetwork(netId, true);
		wifiManager.reconnect();

		callback.onConnected(ssid);
	}  
}