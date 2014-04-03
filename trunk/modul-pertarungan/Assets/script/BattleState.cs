using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public abstract class BattleState:MonoBehaviour
    {
        private GameObject objectLoader;

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
        public  abstract void Action();
        public BattleState(GameObject CurrentPlayer)
        {
            this.CurrentPlayer = CurrentPlayer;
        }
        public BattleState(GameObject CurrentPlayer, List<GameObject> Enemy)
            : this(CurrentPlayer)
        {
            this.Enemy = Enemy;
        }
        public BattleState(GameObject CurrentPlayer, GameObject ObjectLoader)
            : this(CurrentPlayer)
        {
            this.ObjectLoader = ObjectLoader;
        }

	}
}
