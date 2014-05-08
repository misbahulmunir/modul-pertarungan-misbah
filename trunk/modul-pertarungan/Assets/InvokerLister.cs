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
            var serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            string[] message = serverMessage.Split('-');
            if (serverMessage.Contains("CardEffect"))
            {
                var invoke=new Invoker();
                Command cmd = message[1].Equals(GameManager.Instance().PlayerId) ? new CardExecuteCommand(message[2], "enemy") : new CardExecuteCommand(message[2],"player");
                invoke.AddCommand(cmd);
                invoke.RunCommand();
                NetworkSingleton.Instance().ServerMessage = "";
            }
        }
    }
}