using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public float gravity;
    public float speed;
    private Vector3 target;
    private Vector3 lookat;
    private CharacterController CharContr;
    public GameObject FightCircle;
    public GameObject FightCircleSpawned;
    private GameObject CurrentEnemy;
    public Collider[] spawnArea1;
    public Collider[] spawnArea2;
    public Collider[] spawnArea3;
    public Collider[] spawnArea4;
    public Collider[] spawnArea5;
    public Collider[] spawnArea6;
    public Collider[] spawnArea7;
    public Collider[] spawnArea8;
    public Collider[] spawnArea9;
    //public Collider[] spawnArea10;
    private bool AllTrue;
    private bool CanSpawn;
    public bool spawned;
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
    public int layermask;

    private void Start()
    {
        CharContr = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var moveDirection = new Vector3(0, 0, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        CharContr.Move(moveDirection * Time.deltaTime * speed);
        if (spawned ==true)
        {
            MoveTowardsTarget();
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
        //UnityEngine.Debug.Log("Collided");
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
            if (CanSpawn == true && spawned == false)
            {
                spawned = true;
                FightCircleSpawned = Instantiate(FightCircle, transform.position + Box1Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                if (CanSpawn == true && spawned == false)
                {
                    spawned = true;
                    FightCircleSpawned = Instantiate(FightCircle, transform.position + Box2Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                    if (CanSpawn == true && spawned == false)
                    {
                        spawned = true;
                        FightCircleSpawned = Instantiate(FightCircle, transform.position + Box3Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                        if (CanSpawn == true && spawned == false)
                        {
                            spawned = true;
                            FightCircleSpawned = Instantiate(FightCircle, transform.position + Box4Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                            if (CanSpawn == true && spawned == false)
                            {
                                spawned = true;
                                FightCircleSpawned = Instantiate(FightCircle, transform.position + Box5Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                                if (CanSpawn == true && spawned == false)
                                {
                                    spawned = true;
                                    FightCircleSpawned = Instantiate(FightCircle, transform.position + Box6Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                                    if (CanSpawn == true && spawned == false)
                                    {
                                        spawned = true;
                                        FightCircleSpawned = Instantiate(FightCircle, transform.position + Box7Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                                        if (CanSpawn == true && spawned == false)
                                        {
                                            spawned = true;
                                            FightCircleSpawned = Instantiate(FightCircle, transform.position + Box8Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
                                            if (CanSpawn == true && spawned == false)
                                            {
                                                spawned = true;
                                                FightCircleSpawned = Instantiate(FightCircle, transform.position + Box9Position + MoveSpawnUp, Quaternion.Euler(90, 0, 0)) as GameObject;
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
            target = FightCircleSpawned.gameObject.transform.GetChild(4).transform.position;
            CurrentEnemy = other.gameObject;
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

    private void MoveTowardsTarget()
    {
        lookat = (CurrentEnemy.transform.position - transform.position).normalized;
        var offset = target - transform.position;
        if (offset.magnitude > .2f)
        {
            offset = offset.normalized * speed;
            CharContr.Move(offset * Time.deltaTime);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(lookat), speed * 5 * Time.deltaTime); //rotates to the wrong point with this, works with the rotat.lookat, but cant be slowed down.
    }//poiont the dude at the wronge point, i have no idea why

}
