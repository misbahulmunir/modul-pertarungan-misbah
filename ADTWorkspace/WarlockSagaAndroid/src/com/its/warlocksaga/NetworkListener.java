package com.its.warlocksaga;


import android.util.Log;

import com.esotericsoftware.kryonet.Client;
import com.esotericsoftware.kryonet.Connection;
import com.esotericsoftware.kryonet.Listener;
import com.unity3d.player.UnityPlayer;

public class NetworkListener extends Listener {

	private  String TAG;
	
	public NetworkListener(String TAG)
	{
		this.TAG=TAG;
	}
	public void connected(Connection c)
	{
		
	//  Log.i(TAG,"[client]>> you have connected to server");
		
	}
	
	public void disconnected(Connection c)
	{
		
	}
	
	public void received(Connection c,Object o)
	{
	if(o instanceof PacketMessage)
	{
	String message=((PacketMessage)o).getMessage();
	Log.i(TAG,"retriving message from server....");
	   Log.i(TAG, "message from server = "+message);
        UnityPlayer.UnitySendMessage("serverfromeclipse", "ReceiveMessage", message);
		}
	}
}
