package Chatroom;

import Chatroom.Packet.Packet00Request;
import Chatroom.Packet.Packet01RequestAnswer;
import Chatroom.Packet.Packet02Message;

import com.esotericsoftware.kryonet.Client;
import com.esotericsoftware.kryonet.Connection;
import com.esotericsoftware.kryonet.Listener;

public class ClientNetworkListener extends Listener{

	private Client client;
	public void initilization(Client client)
	{ 
	     this.client=client;
	}
	public ClientNetworkListener()
	{
		
	}
	public void connected(Connection c)
	{
		
		System.out.println("[client]>> you have connected to server");
		Packet.Packet00Request request= new Packet.Packet00Request();
		client.sendTCP(request);
	}
	
	public void disconnected(Connection c)
	{
		
	}
	
	public void received(Connection c,Object o)
	{
		if(o instanceof Packet.Packet01RequestAnswer){
			System.out.print(((Packet01RequestAnswer)o).accepted);
			 Packet01RequestAnswer answer= (Packet01RequestAnswer) o;
			if(answer.accepted==true)
			{while(true)
			{
				if(MpClient.scan.hasNext())
				{
				   Packet02Message message= new Packet02Message();
				   message.message=MpClient.scan.next();
				   message.clientName="uul";
				   c.sendTCP(message);
				}
			}
			}
			else
			c.close();
		}
		if(o instanceof Packet.Packet02Message){
			Packet02Message pa= (Packet02Message) o;
			System.out.println("[Server]>>"+pa.message);
			 		
		}
	   
		
	}
}
