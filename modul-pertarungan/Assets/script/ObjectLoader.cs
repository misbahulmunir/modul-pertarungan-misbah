﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ModelModulPertarungan;

namespace ModulPertarungan
{
    public class ObjectLoader : MonoBehaviour
    {

        // Use this for initialization
        private int pawnsnumber;
        public List<GameObject> enemies;
        public List<GameObject> enemiesplace;
        public List<GameObject> pawns;
        public List<GameObject> pawnsPosisition;
        public List<GameObject> cardpawns;
        private List<GameObject> DisplayedCards;
        private int currentPawnNumber;

        public void LoadPlayer()
        {
            for (int c = 0; c < pawns.Count; c++)
            {
                GameObject obj = Instantiate(pawns[c], pawnsPosisition[c].transform.position, Quaternion.identity) as GameObject;
                pawns[c] = obj;

            }
            GameManager.Instance().CurrentPawn = pawns[0];
            GameManager.Instance().Players = pawns;
    
        }
        public void LoadDisplayedCards(GameObject pawn)
        {
            for (int c = 0; c < pawn.GetComponent<PlayerAction>().CurrentHand.Count; c++)
            {
                GameObject obj = Instantiate(pawn.GetComponent<PlayerAction>().CurrentHand[c], cardpawns[c].transform.position, Quaternion.identity) as GameObject;
                obj.GetComponent<SpriteRenderer>().sortingOrder = 5;
                DisplayedCards.Add(obj);
            }
        }
        public void DestroyDisplayedCards()
        {
            foreach (GameObject obj in DisplayedCards)
            {
                Destroy(obj);
            }
        }

        public void LoadEnemy()
        {
            for (int c = 0; c < enemies.Count; c++)
            {
                GameObject obj = Instantiate(enemies[c], enemiesplace[c].transform.position, Quaternion.identity) as GameObject;
                enemies[c] = obj;

            }
            GameManager.Instance().Enemies = enemies;
        }
        void Start()
        {
            DisplayedCards = new List<GameObject>();
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            LoadEnemy();
            LoadPlayer();

        }

        // Update is called once per frame
        void Update()
        {

            //State Pattern untuk battle
        }


    }
}