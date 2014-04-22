package Chatroom;
import java.io.IOException;
import java.util.Scanner;

import com.esotericsoftware.kryo.Kryo;
import com.esotericsoftware.kryonet.*;
public class MpClient {

	private int UDPport=8888;
	private int TCPport=9999;
	
	public Client client;
	private ClientNetworkListener cnl;
	public static Scanner scan;
	
	public MpClient()
	{
		client=new Client();
		cnl= new ClientNetworkListener();
		cnl.initilization(client);
		scan=new Scanner(System.in);
		registerPacket();
		client.addListener(cnl);
		
		new Thread(client).start();
		
		try {
			client.connect(5000,"localhost",TCPport,UDPport);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	private void registerPacket()
	{
	   Kryo kryo= client.getKryo();
	   kryo.register(Packet.Packet00Request.class);
	   kryo.register(Packet.Packet01RequestAnswer.class);
	   kryo.register(Packet.Packet02Message.class);
	  
	}
}
