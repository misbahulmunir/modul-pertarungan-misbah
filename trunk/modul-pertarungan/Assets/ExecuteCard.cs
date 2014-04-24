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
            CardEffecFactory cardFactory= new CardEffecFactory();
            cardFactory.InstantiateObject();
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


