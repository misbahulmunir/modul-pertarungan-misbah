using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class PlayerEditorManager:MonoBehaviour
	{
        public GameObject grid;
        public GameObject avatar;
        void Update()
        {
           
        }


        void Start()
        {
            for (int c = 0; c < 2; c++)
            {
                NGUITools.AddChild(grid,avatar);
            }
        }
	}
}
