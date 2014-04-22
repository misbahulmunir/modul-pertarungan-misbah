package Chatroom;

import Chatroom.Packet.Packet00Request;
import Chatroom.Packet.Packet01RequestAnswer;
import Chatroom.Packet.Packet02Message;

import com.esotericsoftware.kryonet.Connection;
import com.esotericsoftware.kryonet.Listener;

public class ServerNetworkListener extends Listener{

	
	public ServerNetworkListener()
	{
		
	}
	public void connected(Connection c)
	{
		
	}
	
	public void disconnected(Connection c)
	{
		
	}
	
	public void received(Connection c,Object o)
	{
		if(o instanceof Packet.Packet00Request){
			 Packet01RequestAnswer answer= new Packet01RequestAnswer();
			 answer.accepted=true;
			 c.sendTCP(answer);
		}
		if(o instanceof Packet.Packet02Message){
			Packet02Message pa= (Packet02Message) o;
			System.out.println("[" +pa.clientName+"]>>"+pa.message);
			 		
		}
	   
		
	}
}
