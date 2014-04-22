package ServePackage;

import com.esotericsoftware.kryonet.*;
import java.io.*;
import java.util.*;
public class ClientApplication extends Listener {
	private static Client client;
	static int udpPort=9988;
	static int tcpPort=9999;
	public static boolean messageReceived;
	static volatile PacketMessage pmessage;
	static volatile Scanner scan;
	public static void main(String[] args)throws Exception
	{ System.out.println("connect to The Server.........");
	  client= new Client();
	  
	  client.getKryo().register(PacketMessage.class);
	  client.start();
	  client.connect(5000,"localhost",tcpPort,udpPort);
	  
	  System.out.println("client is connected.....");
	  client.addListener(new ClientApplication());
	  scan= new Scanner(System.in);
	  pmessage= new PacketMessage();
	  new Thread(){
	@Override
	  public void run()
    	{
		  while(true)
		  {
		  		pmessage.setMessage(scan.next());
		  		client.sendTCP(pmessage);    
		  }
    	}
	  }.start();
	  
	 }
	public void received(Connection c,Object p)
	{
		if(p instanceof PacketMessage)
		{
			PacketMessage packet= (PacketMessage)p;
			System.out.println(((PacketMessage) p).getMessage());
			messageReceived=true;
		}
	}
}
