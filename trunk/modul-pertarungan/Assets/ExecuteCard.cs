using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class ExecuteCard : MonoBehaviour
    {
        void OnClick()
        {
            CardFactory cardFactory= new CardFactory();
            cardFactory.InstatiateObject();
            cardFactory.CreateObject("SplitFireCard");
        }
        void Start()
        {
        }

        void Update()
        {
        }
    }
}


