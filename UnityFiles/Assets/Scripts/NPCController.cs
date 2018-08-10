using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public float gravity;
    public float speed;
    private Vector3 lookat;
    private CharacterController CharContr;
    public GameObject FightCircle;
    private GameObject FightCircleSpawnedPrefab;
    private GameObject CurrentEnemy;
    private Collider[] spawnArea1;
    private Collider[] spawnArea2;
    private Collider[] spawnArea3;
    private Collider[] spawnArea4;
    private Collider[] spawnArea5;
    private Collider[] spawnArea6;
    private Collider[] spawnArea7;
    private Collider[] spawnArea8;
    private Collider[] spawnArea9;
    //public Collider[] spawnArea10;
    private bool AllTrue;
    private bool CanSpawn;
    public bool FightCircleSpawnedBool;
    public Vector3 BoxSize;
    private Vector3 Box1Position = new Vector3(0,0,0);
    private Vector3 Box2Position = new Vector3(10,0,0);
    private Vector3 Box3Position = new Vector3(-10,0,0);
    private Vector3 Box4Position = new Vector3(0,0,10);
    private Vector3 Box5Position = new Vector3(0,0,-10);
    private Vector3 Box6Position = new Vector3(20, 0, 0);
    private Vector3 Box7Position = new Vector3(0, 0, 20);
    private Vector3 Box8Position = new Vector3(-20, 0, 0);
    private Vector3 Box9Position = new Vector3(0, 0, -20);
    //private Vector3 Box10Position = new Vector3(0, 0, 0);
    private Vector3 MoveSpawnUp = new Vector3(0, .1f, 0);
    private int layermask;
    public float Rotation;
    public double Angle;
    public double X;
    public double Z;
    public int NPCPatrolPointActive;
    public GameObject NPCPatrol1;
    public GameObject NPCPatrol2;
    public float dx;
    public float dy;


    private void Start()
    {
        CharContr = GetComponent<CharacterController>();
        NPCPatrolPointActive = 1;
    }

    private void Update()
    {
        if (FightCircleSpawnedBool ==true)
        {
            MoveTowardsTarget();
        }
        else
        {
            UnitPatrol();
        }
    }

    private void LateUpdate()
    {
        spawnArea1 = Physics.OverlapBox(transform.position + Box1Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea2 = Physics.OverlapBox(transform.position + Box2Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea3 = Physics.OverlapBox(transform.position + Box3Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea4 = Physics.OverlapBox(transform.position + Box4Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea5 = Physics.OverlapBox(transform.position + Box5Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea6 = Physics.OverlapBox(transform.position + Box6Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea7 = Physics.OverlapBox(transform.position + Box7Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea8 = Physics.OverlapBox(transform.position + Box8Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        spawnArea9 = Physics.OverlapBox(transform.position + Box9Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
        //spawnArea10 = Physics.OverlapBox(transform.position + Box10Position, BoxSize, Quaternion.Euler(0, 0, 0), layermask);
    }

    private void OnTriggerEnter (Collider other)
    {
        UnityEngine.Debug.Log("Collided");
        if (other.gameObject.tag == "Player")
        {

            if (spawnArea1.Length == 0)
            {
                CanSpawn = true;
            }
            else
            {
                CanSpawn = Area1TagCheck("Player", "AgressiveNPC");
            }
            if (CanSpawn == true && FightCircleSpawnedBool == false)
            {
                FightCircleSpawnedBool = true;
                FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box1Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
            }
            else
            {
                UnityEngine.Debug.Log("Area1_Occupied");
                if (spawnArea2.Length == 0)
                {
                    CanSpawn = true;
                }
                else
                {
                    CanSpawn = Area2TagCheck("Player", "AgressiveNPC");
                }
                if (CanSpawn == true && FightCircleSpawnedBool == false)
                {
                    FightCircleSpawnedBool = true;
                    FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box2Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                }
                else
                {
                    UnityEngine.Debug.Log("Area2_Occupied");
                    if (spawnArea3.Length == 0)
                    {
                        CanSpawn = true;
                    }
                    else
                    {
                        CanSpawn = Area3TagCheck("Player", "AgressiveNPC");
                    }
                    if (CanSpawn == true && FightCircleSpawnedBool == false)
                    {
                        FightCircleSpawnedBool = true;
                        FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box3Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Area3_Occupied");
                        if (spawnArea4.Length == 0)
                        {
                            CanSpawn = true;
                        }
                        else
                        {
                            CanSpawn = Area4TagCheck("Player", "AgressiveNPC");
                        }
                        if (CanSpawn == true && FightCircleSpawnedBool == false)
                        {
                            FightCircleSpawnedBool = true;
                            FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box4Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                        }
                        else
                        {
                            UnityEngine.Debug.Log("Area4_Occupied");
                            if (spawnArea5.Length == 0)
                            {
                                CanSpawn = true;
                            }
                            else
                            {
                                CanSpawn = Area5TagCheck("Player", "AgressiveNPC");
                            }
                            if (CanSpawn == true && FightCircleSpawnedBool == false)
                            {
                                FightCircleSpawnedBool = true;
                                FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box5Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                            }
                            else
                            {
                                UnityEngine.Debug.Log("Area5_Occupied");
                                if (spawnArea6.Length == 0)
                                {
                                    CanSpawn = true;
                                }
                                else
                                {
                                    CanSpawn = Area6TagCheck("Player", "AgressiveNPC");
                                }
                                if (CanSpawn == true && FightCircleSpawnedBool == false)
                                {
                                    FightCircleSpawnedBool = true;
                                    FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box6Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                                }
                                else
                                {
                                    UnityEngine.Debug.Log("Area6_Occupied");
                                    if (spawnArea7.Length == 0)
                                    {
                                        CanSpawn = true;
                                    }
                                    else
                                    {
                                        CanSpawn = Area7TagCheck("Player", "AgressiveNPC");
                                    }
                                    if (CanSpawn == true && FightCircleSpawnedBool == false)
                                    {
                                        FightCircleSpawnedBool = true;
                                        FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box7Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                                    }
                                    else
                                    {
                                        UnityEngine.Debug.Log("Area7_Occupied");
                                        if (spawnArea8.Length == 0)
                                        {
                                            CanSpawn = true;
                                        }
                                        else
                                        {
                                            CanSpawn = Area8TagCheck("Player", "AgressiveNPC");
                                        }
                                        if (CanSpawn == true && FightCircleSpawnedBool == false)
                                        {
                                            FightCircleSpawnedBool = true;
                                            FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box8Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                                        }
                                        else
                                        {
                                            UnityEngine.Debug.Log("Area8_Occupied");
                                            if (spawnArea9.Length == 0)
                                            {
                                                CanSpawn = true;
                                            }
                                            else
                                            {
                                                CanSpawn = Area9TagCheck("Player", "AgressiveNPC");
                                            }
                                            if (CanSpawn == true && FightCircleSpawnedBool == false)
                                            {
                                                FightCircleSpawnedBool = true;
                                                FightCircleSpawnedPrefab = Instantiate(FightCircle, transform.position + Box9Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                                            }
                                            else
                                            {
                                                UnityEngine.Debug.Log("Area9_Occupied");
                                                /*if (spawnArea10.Length == 0)
                                                {
                                                    CanSpawn = true;
                                                }
                                                else
                                                {
                                                    CanSpawn = Area10TagCheck("Player", "AgressiveNPC");
                                                }
                                                if (CanSpawn == true && spawned == false)
                                                {
                                                    spawned = true;
                                                    FightCircleSpawned = Instantiate(FightCircle, transform.position + Box10Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
                                                }
                                                else
                                                {
                                                    UnityEngine.Debug.Log("Area10_Occupied");
                                                }*/
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            CurrentEnemy = other.gameObject;
        }
        else if (other.gameObject.tag == "PatrolPoints")
        {
            if (other.gameObject.name == "NPCPatrolPoint1")
            {
                NPCPatrolPointActive = 2;
            } else if ( other.gameObject.name == "NPCPatrolPoint2")
            {
                NPCPatrolPointActive = 1;
            }
        }

        
    }

    public bool Area1TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea1.Length; i++)
        {
            if (spawnArea1[i].gameObject.tag == tag || spawnArea1[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area2TagCheck (string tag,string tag2)
    {
        for (int i = 0; i < spawnArea2.Length; i++)
        {
            if (spawnArea2[i].gameObject.tag == tag || spawnArea2[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area3TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea3.Length; i++)
        {
            if (spawnArea3[i].gameObject.tag == tag || spawnArea3[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area4TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea4.Length; i++)
        {
            if (spawnArea4[i].gameObject.tag == tag || spawnArea4[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area5TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea5.Length; i++)
        {
            if (spawnArea5[i].gameObject.tag == tag || spawnArea5[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area6TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea6.Length; i++)
        {
            if (spawnArea6[i].gameObject.tag == tag || spawnArea6[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area7TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea7.Length; i++)
        {
            if (spawnArea7[i].gameObject.tag == tag || spawnArea7[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area8TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea8.Length; i++)
        {
            if (spawnArea8[i].gameObject.tag == tag || spawnArea8[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    public bool Area9TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea9.Length; i++)
        {
            if (spawnArea9[i].gameObject.tag == tag || spawnArea9[i].gameObject.tag == tag2)
            {
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }

    /*public bool Area10TagCheck(string tag, string tag2)
    {
        for (int i = 0; i < spawnArea10.Length; i++)
        {
            if (spawnArea10[i].gameObject.tag == tag || spawnArea10[i].gameObject.tag == tag2)
            {
            if (spawnArea10.Length == 0)
                {
                    AllTrue = true;
                    return AllTrue;
                }
                AllTrue = true;
            }
            else
            {
                AllTrue = false;
                break;
            }
        }
        if (AllTrue == true)
        {
            return AllTrue;
        }
        else
        {
            return AllTrue;
        }
    }*/

    private void MoveTowardsTarget() // gets vectors and rotates and moves target untell it is in position one, will have to add checks for already occupied positions later
    {
        lookat = (FightCircleSpawnedPrefab.transform.position - transform.position).normalized; 
        float step = speed * Time.deltaTime;
        Vector3 newRot = Vector3.RotateTowards(transform.forward, lookat, step, 0.0f);
        UnityEngine.Debug.DrawRay(transform.position, newRot, Color.red);
        newRot.y = newRot.y * 0;
        transform.rotation = Quaternion.LookRotation(newRot);
        dx = Mathf.Abs(transform.position.x - FightCircleSpawnedPrefab.transform.Find("Team2Slot1").transform.position.x);
        dy = Mathf.Abs(transform.position.y - FightCircleSpawnedPrefab.transform.Find("Team2Slot1").transform.position.y);

        if (dx > .1f || dy > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, FightCircleSpawnedPrefab.transform.Find("Team2Slot1").transform.position, step);
        }
    }
    
    public void UnitPatrol() // uses 2 points to move between patrol points.
    {
        if (NPCPatrolPointActive == 1)
        {
            //rotation controller
            Vector3 targetDir = NPCPatrol1.transform.position - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            UnityEngine.Debug.DrawRay(transform.position, newDir, Color.red);
            newDir.y = newDir.y * 0;
            transform.rotation = Quaternion.LookRotation(newDir);
            //rotation controler

            //MoveControler
            transform.position = Vector3.MoveTowards(transform.position, NPCPatrol1.transform.position, step);
            //MoveControler 
        } else if (NPCPatrolPointActive == 2)
        {
            //rotation controller
            Vector3 targetDir = NPCPatrol2.transform.position - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            UnityEngine.Debug.DrawRay(transform.position, newDir, Color.red);
            newDir.y = newDir.y * 0;
            transform.rotation = Quaternion.LookRotation(newDir);
            //rotation controler

            //MoveControler
            transform.position = Vector3.MoveTowards(transform.position, NPCPatrol2.transform.position, step);
            //MoveControler 
        }
    }
    
}
