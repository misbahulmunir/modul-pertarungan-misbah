﻿using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiHandler : MonoBehaviour
    {

        private Vector2 scrollPosition = Vector2.zero;
        public GUIStyle style;
        public void OnGUI()
        {
            style.normal.textColor = Color.black;
            scrollPosition = GUI.BeginScrollView(new Rect(10, 300, 150, 170),
            scrollPosition, new Rect(0, 0, 220, 300));

            // Make four buttons - one in each corner. The coordinate system is defined
            // by the last parameter to BeginScrollView.
            if (GameManager.Instance().CurrentCard != null)
            {
                GUI.Label(new Rect(0, 0, 100, 20), GameManager.Instance().CurrentCard.CardEffect, style);
            }
            //GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
            //GUI.Button(new Rect(0,280, 100, 20), "Bottom-left");
            //GUI.Button(new Rect(120, 280, 100, 20), "Bottom-right");

            // End the scroll view that we began above.
            GUI.EndScrollView();

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
