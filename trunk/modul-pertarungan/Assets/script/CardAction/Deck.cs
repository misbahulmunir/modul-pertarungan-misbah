using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class Deck
    {

        // Use this for initialization
        private List<GameObject> card;
        public List<GameObject> Card
        {
            get { return card; }
            set { card = value; }
        }

        public void Shuffle()
        {
            for (int i = 0; i < card.Count; i++)
            {
                GameObject tempCard = card[Random.Range(0, card.Count)];
                card.Remove(tempCard);
                card.Insert(Random.Range(0, card.Count), tempCard);
            }
        }
        public GameObject Draw()
        {
            GameObject drawedcard = card[0];
            card.RemoveAt(0);
            return drawedcard;
        }
        public Deck(List<GameObject> card)
        {
            this.card = card;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}