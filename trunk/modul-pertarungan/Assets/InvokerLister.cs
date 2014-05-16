using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class InvokerLister : MonoBehaviour
    {
        public  GameObject text;
        public GameObject battleStateManager;
        private Invoker _invoke;
        private Command _cmd;
        public GameObject textList;
        // Use this for initialization
        private void Start()
        {
            NetworkSingleton.Instance().ServerMessage="";
            
        }

        // Update is called once per frame
        private void Update()
        {
            var serverMessage = NetworkSingleton.Instance().ServerMessage;
            //Debug.Log(serverMessage);
            string[] message = serverMessage.Split('-');
            if (serverMessage.Contains("CardEffect"))
            {
                //text.GetComponent<UILabel>().text = NetworkSingleton.Instance().ServerMessage;
                text.GetComponent<UILabel>().text = serverMessage;
                _invoke= new Invoker();
                _cmd = message[1].ToLower().Equals(GameManager.Instance().PlayerId.ToLower()) ? new CardExecuteCommand(message[2], "enemy") : new CardExecuteCommand(message[2],"player");
                _invoke.AddCommand(_cmd);
                _invoke.RunCommand();
               
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if(serverMessage.Contains("EndTurn"))
            {
                text.GetComponent<UILabel>().text = serverMessage;
                _invoke=new Invoker();
                battleStateManager.GetComponent<BattleStateManager>().endButton.SetActive(true);
                _cmd=new EndPhaseCommand(battleStateManager.GetComponent<BattleStateManager>());
                _invoke.AddCommand(_cmd);
                _invoke.RunCommand();
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if (serverMessage.Contains("Chat"))
            {
                text.GetComponent<UILabel>().text = serverMessage;
                textList.GetComponent<UITextList>().Add(message[1]);
                NetworkSingleton.Instance().ServerMessage = "";
            }
        }
    }
}