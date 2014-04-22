package ServePackage;

import com.esotericsoftware.kryonet.Connection;
import com.esotericsoftware.kryonet.Server;

public class CardWarlockSagaServer {
	private static Server server;
	static int udpPort=9988;
	static int tcpPort=9999;
	static PacketMessage pmessage;
	public static void main(String[] args)throws Exception
	{ System.out.println("Creating The Server.........");
	  server= new Server();
	  server.getKryo().register(PacketMessage.class);
	  server.bind(tcpPort,udpPort);
	  server.start();
	  System.out.println("Server is working.....");
	  server.addListener(new ServerApplication());
	  }
    public void connected(Connection c)
    {
       System.out.println("Get Message From"+c.getRemoteAddressTCP().getHostString());
       pmessage= new PacketMessage();
       pmessage.setMessage("Connected to server");
       c.sendUDP(pmessage);
    }
    public void received(Connection c,Object p)
	{
		if(p instanceof PacketMessage)
		{
			PacketMessage packet= (PacketMessage)p;
			System.out.print(packet.getMessage());
			
		}
	}
    public void disconnected(Connection c)
    {
      System.out.print("Disconnected from Server");
    }
}
