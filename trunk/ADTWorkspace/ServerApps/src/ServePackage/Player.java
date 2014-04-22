package ServePackage;

import com.esotericsoftware.kryonet.Connection;

public class Player {

	public String Name;
	public Connection connection;
    
	public Player(String Name, Connection c)
	{
	    this.Name=Name;
	    this.connection=c;
	}
}
