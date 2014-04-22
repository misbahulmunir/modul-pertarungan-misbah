package Chatroom;

public class Packet {
  public static class Packet00Request{public String clientName;}
  public static class Packet01RequestAnswer{public boolean accepted;}
  public static class Packet02Message{public String message; public String clientName;}
}
