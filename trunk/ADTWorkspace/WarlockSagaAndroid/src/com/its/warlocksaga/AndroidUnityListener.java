package com.its.warlocksaga;
import java.io.*;
import com.esotericsoftware.kryonet.*;
import java.net.*;
import android.os.*;
import android.util.Log;
import com.unity3d.player.*;
public class AndroidUnityListener extends UnityPlayerActivity
{


	private static final String TAG="Bullshit";
	private volatile DataInputStream _dataInputStream;
	private volatile DataOutputStream _dataOutputStream;
	private volatile int _port;
	private volatile String _host;
	private volatile Socket _socket;
	private Client client;
	private volatile int _UDPport;
	private volatile int _TCPport;
	private Thread _listener;
	private PacketMessage pm;
    
	public AndroidUnityListener(String host, String TCPport,String UDPport)
	{
		//_host=host;
		//_port=Integer.parseInt(port);
		_host=host;
		pm= new PacketMessage();
		_UDPport=Integer.parseInt(UDPport);
		_TCPport=Integer.parseInt(TCPport);
		if(Looper.myLooper()==null)
			Looper.prepare();
		
		_listener= new Thread()
		{
			@Override 
			public void run()
			{
			 try
			 {
				 //_socket=new Socket(_host, _port);
				// _dataInputStream= new DataInputStream(_socket.getInputStream());
				// _dataOutputStream= new DataOutputStream(_socket.getOutputStream());
				 client= new Client();
				 client.getKryo().register(PacketMessage.class);
				 client.start();
				 client.connect(5000, _host, _TCPport,_UDPport);
				 client.addListener(new NetworkListener(TAG));
				 
				 while(true)
				 {
				 //  Log.i(TAG,"retriving message from server....");
				 //  String line= _dataInputStream.readUTF();
				//   Log.i(TAG, "message from server = "+line);
				  // UnityPlayer.UnitySendMessage("serverfromeclipse", "ReceiveMessage", line);
					
				 }
			 }
			 catch(IOException i)
			 {
				 Log.e(TAG, i.getLocalizedMessage());
				 Thread.currentThread().interrupt();
			 }
			return;
			}
		};
		_listener.start();
	}
	
	public boolean sendMessage(String Message)
	{
		try
		{
			Log.i(TAG,"Sending Message to server, Message ="+Message);
			//_dataOutputStream.writeUTF(Message);
			//_dataOutputStream.flush();
			pm= new PacketMessage();
			pm.setMessage(Message);
			client.sendUDP(pm);
			return true;
		}
		catch(Exception i)
		{
			Log.e(TAG,"unable to send message"+i.getLocalizedMessage());
			_listener.interrupt();
			return false;
		}
	
	}
	

	}
	


