using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
public class HoverCard : MonoBehaviour {

	// Use this for initialization
    public GameObject cardName;
    public GameObject cardCost;
    public GameObject cardEffect;
    private Ray ray;
    private RaycastHit hit;

    
    public void OnClick()
    {

        cardName.GetComponent<UILabel>().text = this.GetComponent<CardsEffect>().CardName;
        cardEffect.GetComponent<UILabel>().text = " " + this.GetComponent<CardsEffect>().CardEffect;
    }
	void Start () {
	     

	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
}
