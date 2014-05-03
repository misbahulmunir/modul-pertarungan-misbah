using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class LobbyButtonManager:MonoBehaviour
	{

        void HostRoom()
        {
            Application.LoadLevel("HostRoom");
        }
	}
}
