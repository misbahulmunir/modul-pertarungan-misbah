using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class CardManager : MonoBehaviour
    {
        public void SelectCard()
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("card"))
                    {
                        CardsEffect card = hit.collider.gameObject.GetComponent<CardsEffect>();
                        card.Effect();
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
