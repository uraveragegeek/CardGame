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
using System.Diagnostics;

[Serializable]
public class Player_Controller : MonoBehaviour {

    //Declairing variables
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float RotationSpeed;
    private bool ControlDisabled;
    private Vector3 moveDirection;
    public CharacterController CharContr;
    public Camera playercam;
    public NetworkManagerr NMScript;
    public AudioListener AudioListener;
    private TcpClient ServerConnection;
    public float rotation;
    private Rigidbody rb;
    public bool moving;
    public bool CloneMoving;
    private Vector3 FirstPosition;
    private Vector3 LastPosition;

    /* i really need to start remembering to comment more */

    private void Awake()
    {

    }

    private void Start()
    {
        NMScript = GameObject.Find("NetworkManager").GetComponent<NetworkManagerr>();
        ServerConnection = NMScript.TcpClnt;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        FirstPosition = transform.position;
        CameraAndListenerController();
        PlayerController();
        AnimationController();
        SendPlayerPosition();
        if (FirstPosition != LastPosition)
        {
            CloneMoving = true;
        }
        else
        {
            CloneMoving = false;
        }
        LastPosition = FirstPosition;
    }

    private void Update()
    {
        rotation = transform.rotation.eulerAngles.y;
    }

    public void PlayerController()
    {
        if (ServerConnection.Connected)
        {
            if (gameObject.name == NMScript.PlayerClass.SelectedHero.Name)
            {
                if (moving)
                {
                    moving = false;
                }
                MovementControllerPlayer();
                JumpControllerPlayer();
                RotationControllerPlayer();
                MovementFinalizer();
            } 
        }
    }

    public void MovementControllerPlayer()
    {
        if (CharContr.isGrounded)
        {
            moveDirection = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W)) 
            {
                moveDirection = moveDirection + new Vector3(0, 0, speed * Time.deltaTime);
                if (!moving)
                {
                    moving = true;
                }
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = moveDirection + new Vector3(0, 0, -speed * Time.deltaTime);
                if (!moving)
                {
                    moving = true;
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                moveDirection = moveDirection + new Vector3(-speed * Time.deltaTime, 0, 0);
                if (!moving)
                {
                    moving = true;
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                moveDirection = moveDirection + new Vector3(speed * Time.deltaTime, 0, 0);
                if (!moving)
                {
                    moving = true;
                }
            }

            moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection *= speed; 
        }

    }

    public void RotationControllerPlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
            if (!moving)
            {
                moving = true;
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
            if (!moving)
            {
                moving = true;
            }
        }
    }

    public void JumpControllerPlayer()
    {
        if (CharContr.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed * Time.deltaTime;
                if (!moving)
                {
                    moving = true;
                }
            }
        }
        else
        {
            if (!moving)
            {
                moving = true;
            }
        }
    }

    public void MovementFinalizer()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        CharContr.Move(moveDirection);
    }

    public void CameraAndListenerController()
    {
        if (gameObject.name == NMScript.PlayerClass.SelectedHero.Name)
        {
            if (playercam.enabled == false)
            {
                playercam.enabled = true;
            }
            if (AudioListener.enabled == false)
            {
                AudioListener.enabled = true;
            }
        }
        else
        {
            if (playercam.enabled == true)
            {
                playercam.enabled = false;
            }
            if (AudioListener.enabled == true)
            {
                AudioListener.enabled = false;
            }
        }
    }

    public void AnimationController()
    {
        Animator anim = GetComponent<Animator>();
        if (CloneMoving)
        {
            anim.Play("Walking");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    public void SendPlayerPosition()
    {
        if (NMScript.ClientSpawned)
        {
            if (moving)
            {
                try
                {
                    //Debug.Log("timer: " + Time.deltaTime);
                    NetworkStream NtwrkStrm = ServerConnection.GetStream();
                    IFormatter MyFormatter = new BinaryFormatter();

                    //UnityEngine.Debug.Log("Current Position Send Started");
                    string type = "Current Position";
                    MyFormatter.Serialize(NtwrkStrm, type); //Send
                    NtwrkStrm.Flush();
                    MyFormatter.Serialize(NtwrkStrm, NMScript.PlayerClass.SelectedHero.Name); //Send
                    NtwrkStrm.Flush();
                    float x = gameObject.transform.position.x;
                    MyFormatter.Serialize(NtwrkStrm, x); //Send
                    NtwrkStrm.Flush();
                    float y = gameObject.transform.position.y;
                    MyFormatter.Serialize(NtwrkStrm, y); //Send
                    NtwrkStrm.Flush();
                    float z = gameObject.transform.position.z;
                    MyFormatter.Serialize(NtwrkStrm, z); //Send
                    NtwrkStrm.Flush();
                    float yrot = gameObject.transform.rotation.eulerAngles.y;
                    MyFormatter.Serialize(NtwrkStrm, yrot); //Send
                    NtwrkStrm.Flush();
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.Log(e);
                    moving = false;
                    throw;
                }
            }
        }
    }
}
