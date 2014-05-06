using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class ShowRoomtoText : MonoBehaviour
    {

        void OnClick()
        {
            GameObject.Find("RoomName").GetComponent<UILabel>().text = this.gameObject.name.Split('(')[0];
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}