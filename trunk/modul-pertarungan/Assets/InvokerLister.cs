using System;
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
            
            //Debug.Log(serverMessage);
            if (NetworkSingleton.Instance().ServerMessage != null)
            {
                var serverMessage = NetworkSingleton.Instance().ServerMessage;
                try
                {
                    string[] message = serverMessage.Split('-');
                    if (serverMessage.Contains("CardEffect"))
                    {
                        NetworkSingleton.Instance().Chance = Int32.Parse(message[3]);
                        //text.GetComponent<UILabel>().text = NetworkSingleton.Instance().ServerMessage;
                        text.GetComponent<UILabel>().text = serverMessage;
                        _invoke = new Invoker();
                        _cmd = message[1].ToLower().Equals(GameManager.Instance().PlayerId.ToLower())
                            ? new CardExecuteCommand(message[2], "enemy")
                            : new CardExecuteCommand(message[2], "player");
                        _invoke.AddCommand(_cmd);
                        _invoke.RunCommand();
                       
                        NetworkSingleton.Instance().ServerMessage = "";
                    }
                    else if (serverMessage.Contains("EndTurn"))
                    {
                        text.GetComponent<UILabel>().text = serverMessage;
                        _invoke = new Invoker();
                        try
                        {
                            battleStateManager.GetComponent<BattleStateManager>().endButton.SetActive(true);
                            _cmd = new EndPhaseCommand(battleStateManager.GetComponent<BattleStateManager>());
                            _invoke.AddCommand(_cmd);
                            _invoke.RunCommand();
                        }
                        catch (Exception e)
                        {
                            
                            Debug.Log("Endturn Error"+e.Message);
                        }
                        
                        NetworkSingleton.Instance().ServerMessage = "";
                    }
                    else if (serverMessage.Contains("Chat"))
                    {
                        text.GetComponent<UILabel>().text = serverMessage;
                        textList.GetComponent<UITextList>().Add(message[1]);
                        NetworkSingleton.Instance().ServerMessage = "";
                    }
                }
                catch (Exception e)
                {

                    Debug.Log("errorInvokerListener" + e.Message);
                }
            }
        }
    }
}