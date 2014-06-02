using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public class TextureSingleton
	{
        
        private string textureTiles;

        public string TextureTiles
        {
            get { return textureTiles; }
            set { textureTiles = value; }
        }

        public TextureSingleton()
        {

        }
        public static TextureSingleton _instanceTexture;
        public static TextureSingleton Instance()
        {
            if (_instanceTexture == null)
            {
                _instanceTexture = new TextureSingleton();
            }
            return _instanceTexture;
        }
	}
}
