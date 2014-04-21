using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class ConfirmDeck : MonoBehaviour
    {   

        // Use this for initialization
        public GameObject grid;
        public Vector2 size;
        public Vector2 center;
        public void OnClick()
        {
            GameManager.Instance().PlayerDeck = new List<GameObject>();

            foreach (Transform child in grid.transform)
            {

                DestroyBoxCollider(child.gameObject);

            }
            foreach (Transform child in grid.transform)
            {

                DestroyBoxCollider(Attach2DComponent(child.gameObject));

            }
            Application.LoadLevel("Battle");

        }
        public void DestroyBoxCollider(GameObject obj)
        {
            Destroy(obj.collider);
           
        }
        public GameObject Attach2DComponent(GameObject obj )
        {
            obj.AddComponent("BoxCollider2D");
            obj.GetComponent<UITexture>().autoResizeBoxCollider = true;
            return obj;
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