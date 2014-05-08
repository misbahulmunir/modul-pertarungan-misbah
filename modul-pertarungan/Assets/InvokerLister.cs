using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class InvokerLister : MonoBehaviour
    {

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            string[] message = serverMessage.Split('-');
            if (serverMessage.Contains("CardEffect"))
            {
                Invoker invoke=new Invoker();
                Command cmd;
                if (message[1].Equals(GameManager.Instance().PlayerId))
                {
                    cmd = new CardExecuteCommand(message[2], "enemy");
                    
                }
                else
                {
                    cmd= new CardExecuteCommand(message[2],"player");
                }
                invoke.AddCommand(cmd);
                invoke.RunCommand();
                NetworkSingleton.Instance().ServerMessage = "";
            }
        }
    }
}