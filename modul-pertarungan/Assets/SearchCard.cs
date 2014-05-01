using UnityEngine;
using System.Collections;

public class SearchCard : MonoBehaviour
{

    // Use this for initialization
    public GameObject grid;
    public GameObject searchText;
    private string cardName;
    void OnClick()
    {
        RefreshCard();
        foreach (Transform trans in grid.transform)
        {
            if (!(trans.gameObject.name.ToLower().Contains(cardName.ToLower())))
            {
                trans.gameObject.SetActive(false);
            }
        }

        grid.GetComponent<UIGrid>().Reposition();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cardName = searchText.GetComponent<UILabel>().text;
    }
    public void RefreshCard()
    {
        foreach (Transform trans in grid.transform)
        {
            trans.gameObject.SetActive(true);
        }
    }
}
