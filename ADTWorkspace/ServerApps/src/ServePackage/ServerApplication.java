package ServePackage;
import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.esotericsoftware.kryonet.*;
public class ServerApplication extends Listener  {
	public static Map<String,List<Player>> RoomList;
	private static Server server;
	static int udpPort=9988;
	static int tcpPort=9999;
	static PacketMessage pmessage;
	public static void main(String[] args)throws Exception
	{
	  Initialize();
	  System.out.println("Creating The Server.........");
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
       pmessage.setMessage("Connected to server");
       c.sendUDP(pmessage);
      
      
    }
    public void received(Connection c,Object p)
	{
		if(p instanceof PacketMessage)
		{
			PacketMessage packet= (PacketMessage)p;
			protocol(packet.getMessage(),c);
		    	
		}
	}
    public void disconnected(Connection c)
    {
      System.out.println("Disconnected from Server");
    }
    
    public void protocol(String message, Connection c)
    {
    	
    	String[] SpliteMessage=procees_string(message);
    	for(String s: SpliteMessage)
    	{
    	 System.out.println(s);
    	}
    	if(SpliteMessage[0].equals("JoinRoom"))
    	{
    	   for(Map.Entry<String,List<Player>> entry:RoomList.entrySet())
    	   {
    		   if(entry.getKey().equals("Room"+SpliteMessage[1]))
    		   {
    		      entry.getValue().add(new Player(SpliteMessage[2],c));
    		   }
    	   }
    	}
    	else if(SpliteMessage[0].equals("SendMessage"))
    	{
    		System.out.println("kirimPesan");
    		SendToRoom(RoomList.get("Room"+SpliteMessage[1]),SpliteMessage[2],SpliteMessage[3]);
    	}
    }
    public void SendToRoom(List<Player>PlayerRoom,String PlayerName,String Message)
    {
  
       for(Player p : PlayerRoom)
       {
           pmessage.setMessage(Message);
           System.out.println(Message);
           p.connection.sendUDP(pmessage);
       }
    }
    
    public static void Initialize()
    {
    	RoomList=new HashMap<String,List<Player>>();
        pmessage= new PacketMessage();
    	for(int c=0;c<5;c++)
    	{   
    		List player= new ArrayList<Player>();
    	    RoomList.put("Room"+c, player);
    	}
    	
    }
    public String[] procees_string(String message)
    {
    	 String[] result= message.split("-");
    	 return result;
    }
    }

