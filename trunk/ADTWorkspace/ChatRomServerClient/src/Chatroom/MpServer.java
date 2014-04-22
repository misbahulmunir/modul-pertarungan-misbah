package Chatroom;

import java.io.IOException;

import com.esotericsoftware.kryo.Kryo;
import com.esotericsoftware.kryonet.Server;

public class MpServer {
	private Server server;
	private int TCPport = 9999;
	private int UDPport = 8888;
	private ServerNetworkListener serverNetworkListener;
	public MpServer()
	{ System.out.println("Creating The Server.........");
	    server= new Server();
	    serverNetworkListener= new ServerNetworkListener();
	    try {
			server.bind(TCPport, UDPport);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    registerPacket();
	    server.start();
	    System.out.println("Server is working.....");
	}
	private void registerPacket()
	{
	   Kryo kryo= server.getKryo();
	   kryo.register(Packet.Packet00Request.class);
	   kryo.register(Packet.Packet01RequestAnswer.class);
	   kryo.register(Packet.Packet02Message.class);
	  
	}
}
