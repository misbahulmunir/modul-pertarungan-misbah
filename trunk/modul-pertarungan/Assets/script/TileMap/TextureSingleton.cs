﻿using System;
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
        private List<bool> questActive;

        public List<bool> QuestActive
        {
            get { return questActive; }
            set { questActive = value; }
        }
        
        private List<bool> questCleared;

        public List<bool> QuestCleared
        {
            get { return questCleared; }
            set { questCleared = value; }
        }

        private string idButton;

        public string IdButton
        {
            get { return idButton; }
            set { idButton = value; }
        }

        private int numQuest;

        public int NumQuest
        {
            get { return numQuest; }
            set { numQuest = value; }
        }

        private string backScene;

        public string BackScene
        {
            get { return backScene; }
            set { backScene = value; }
        }

        private Dictionary<string, bool> elementButton;

        public Dictionary<string, bool> ElementButton
        {
            get { return elementButton; }
            set { elementButton = value; }
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
