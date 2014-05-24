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
             {"GrassLand","Background/Grassland"}
            };
        }

        public override void CreateBackground(string backgroundName)
        {
            backgroundPathList.TryGetValue(backgroundName, out bgpath);
            var bg= Object.Instantiate(Resources.Load(bgpath, typeof (GameObject)), Vector2.zero, Quaternion.identity) as GameObject;
            bg.transform.localScale= new Vector3(3f,3f,0f);
            bg.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}