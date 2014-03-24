using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceGameTa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    };
    [DataContract]
    public class card
    {
        private string cardName;

        [DataMember]
        public string CardName
        {
          get { return cardName; }
          set { cardName = value; }
        }
        private string cardCastCost;

        [DataMember]
        public string CardCastCost
        {
            get { return cardCastCost; }
            set { cardCastCost = value; }
        }
        private string cardDeckCost;

        [DataMember]
        public string CardDeckCost
        {
            get { return cardDeckCost; }
            set { cardDeckCost = value; }
        }
        private string cardCode;

        [DataMember]
        public string CardCode
        {
            get { return cardCode; }
            set { cardCode = value; }
        }
    }
    [DataContract]
    public class player
    {

        private string playerLvl;
        private string playerSouls;
        private string playerEnergy;
        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        private string playerMoney;

        public string PlayerMoney
        {
            get { return playerMoney; }
            set { playerMoney = value; }
        }
        private string playerClass;

        public string PlayerClass
        {
            get { return playerClass; }
            set { playerClass = value; }
        }
        private List<card> playerCards;

        public List<card> PlayerCards
        {
            get { return playerCards; }
            set { playerCards = value; }
        }
    }
}
