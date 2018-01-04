using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System.Threading;
using System.Linq;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.Timers;

[Serializable]
public class PlayerManager : MonoBehaviour {

    public NetworkManagerr NWMScript;
    /* pretty sure this just lets the network manager know when the level loads. dont think i need to have it in here, will take it out eventually. */
    public void Start()
    {
        NWMScript = GameObject.Find("NetworkManager").GetComponent<NetworkManagerr>();
        NWMScript.SendLevelWasLoaded();
    }

    private void FixedUpdate()
    {
       
    }

    

    
}
