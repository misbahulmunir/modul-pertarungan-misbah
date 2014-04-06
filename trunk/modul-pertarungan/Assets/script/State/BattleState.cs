using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
    public abstract class BattleState : MonoBehaviour
    {
        private GameObject objectLoader;

        private List<GameObject> players;

        public List<GameObject> Players
        {
            get { return players; }
            set { players = value; }
        }
        private BattleStateManager battleManager;

        public BattleStateManager BattleManager
        {
            get { return battleManager; }
            set { battleManager = value; }
        }


        public GameObject ObjectLoader
        {
            get { return objectLoader; }
            set { objectLoader = value; }
        }

        private GameObject currentPlayer;

        public GameObject CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private List<GameObject> enemy;

        public List<GameObject> Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }
        public abstract void Action();
        public BattleState(GameObject CurrentPlayer)
        {
            this.CurrentPlayer = CurrentPlayer;
        }
        public BattleState(List<GameObject> Players, List<GameObject> Enemy, BattleStateManager BattleManager)
        {
            this.Enemy = Enemy;
            this.BattleManager = BattleManager;

        }
        public BattleState(GameObject CurrentPlayer, GameObject ObjectLoader, BattleStateManager BattleManager)
            : this(CurrentPlayer)
        {
            this.ObjectLoader = ObjectLoader;
            this.BattleManager = BattleManager;
        }

        public BattleState(GameObject CurrentPlayer, BattleStateManager BattleManager)
            : this(CurrentPlayer)
        {
            this.BattleManager = BattleManager;
        }

    }
}
