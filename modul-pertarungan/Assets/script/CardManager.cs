using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class CardManager : MonoBehaviour
    {
        public GameObject gui;
        public GameObject Objectloader;
        public void SelectCard()
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("card"))
                    {
                        GameObject gobj=null;
                        CardsEffect card = hit.collider.gameObject.GetComponent<CardsEffect>();
                        GameManager.Instance().CurrentCard = card;
                        card.Effect();
                        
                        
                        foreach (GameObject obj in GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand)
                        {
                            if (hit.collider.name == obj.name+"(Clone)")
                            {
                                gobj = obj;
                                break;
                            }
                        }
                        GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand.Remove(gobj);
                        Destroy(hit.collider.gameObject);
                        Objectloader.GetComponent<ObjectLoader>().LoadDisplayedCards(GameManager.Instance().CurrentPawn);

                    }

                }
            }

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            SelectCard();
        }
    }
}
