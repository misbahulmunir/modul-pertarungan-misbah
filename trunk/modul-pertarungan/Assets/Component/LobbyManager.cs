using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class LobbyManager : MonoBehaviour
    {

        public GameObject grid;
        public GameObject roomButton;
        public MessageBoxScirpt messageBox;
        // Use this for initialization
        void Start()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetRoomList");
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
            GameManager.Instance().GameMode = "pvp";
        }

        // Update is called once per frame
        void Update()
        {
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            if (serverMessage.Contains("RoomList"))
            {
                RefreshGrid();
                string[] message = serverMessage.Split('-');
                foreach (string m in message)
                {
                    if (m != "RoomList"&&m!="")
                    {
                        foreach (Transform t in roomButton.transform)
                        {
                            t.GetComponent<UILabel>().text = m;
                        }
                        roomButton.name = m;
                        NGUITools.AddChild(grid, roomButton);
                    }
                    grid.GetComponent<UIGrid>().Reposition();
                }
                
                NetworkSingleton.Instance().ServerMessage = "";
               
            }
            else if (serverMessage.Contains("no room alvaible"))
            {
                NetworkSingleton.Instance().ServerMessage = "";
                foreach (Transform t in grid.transform)
                {
                    Destroy(t.gameObject);
                }
                
            }
            else if (serverMessage.Contains("JoinedRoom"))
            {
                NetworkSingleton.Instance().ServerMessage = "";
                Application.LoadLevel("WaitingRoom");

            }
            else if (serverMessage.Contains("Room full"))
            {
                NetworkSingleton.Instance().ServerMessage = "";
                var obj = new object[2];
                obj[0] = "Room full";
                obj[1] = " Room is full";
                messageBox.SendMessage("SetMessage", obj);
                messageBox.SendMessage("ShowMessageBox");
            }
            else if(serverMessage.Contains("is exist"))
            {   NetworkSingleton.Instance().ServerMessage = "";
                var obj = new object[2];
                obj[0] = "Room is already exist";
                obj[1] = " Room is exist";
                messageBox.SendMessage("SetMessage", obj);
                messageBox.SendMessage("ShowMessageBox");

            }
            grid.GetComponent<UIGrid>().Reposition();
        }
        public void RefreshGrid()
        {
            foreach (Transform t in grid.transform)
            {
                Destroy(t.gameObject);
            }
            
        }
    }
}