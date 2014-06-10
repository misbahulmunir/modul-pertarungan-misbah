using System.Collections.Generic;
using  UnityEngine;

namespace ModulPertarungan
{
    public class BackgroundFactory : AbstractFactory
    {
        private Dictionary<string, string> backgroundPathList;
        private string bgpath;
        public override void InstantiateObject()
        {
            backgroundPathList = new Dictionary<string, string>()
            {
             {"0_Greenland","Background/Prefab/0_Greenland"},
             {"0_Lavaland", "Background/Prefab/0_Lavaland"},
             {"0_Iceland", "Background/Prefab/0_Iceland"},
             {"0_Wetland", "Background/Prefab/0_Wetland"},
             {"0_Windyhill", "Background/Prefab/0_Windyhill"},             
             {"1_Desertland","Background/Prefab/1_Desertland"},
             {"1_Icemons", "Background/Prefab/1_Icemons"},
             {"1_Ominousmons", "Background/Prefab/1_Ominousmons"},
             {"1_Rokcymons", "Background/Prefab/1_Rokcymons"},
             {"1_Tropicland", "Background/Prefab/1_Tropicland"}
            };
        }

        public override void CreateBackground(string backgroundName)
        {
            //Debug.Log(backgroundName);
            backgroundPathList.TryGetValue(backgroundName, out bgpath);
            var bg = Object.Instantiate(Resources.Load(bgpath, typeof(GameObject)), Vector2.zero, Quaternion.identity) as GameObject;
            bg.transform.localScale= new Vector3(3f,3.2f,0f);
            bg.GetComponent<SpriteRenderer>().sortingOrder =-1;
        }
    }
}