using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractions : MonoBehaviour
{
    //important stuff
    //nearGoldenDoor
    //nearWhiteDoor 
    //nearBlackDoor
    //nearBlueDoor 
    //nearRedDoor
    //nearGreenDoor 
    
    public int LockFallTimer = 3;
    public Vector3 DoorMover;

    [Header("Scripts")]
    GameManager GameManager;


    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();       
    }

    private void Update() 
    {
        OpenDoor();        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("GoldenDoor") && !GameManager.unlockedGoldenDoor && GameManager.hasAKey)
        {
            GameManager.nearGoldenDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with Golden Key";
        }

        if(other.gameObject.CompareTag("GoldenDoor") && GameManager.unlockedGoldenDoor)
        {
            GameManager.InfoText.text = " ";
        }


        if(other.gameObject.CompareTag("WhiteDoor") && !GameManager.unlockedWhiteDoor && GameManager.hasAKey)
        {
            GameManager.nearWhiteDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with White Key";
        }

        if(other.gameObject.CompareTag("WhiteDoor") && GameManager.unlockedWhiteDoor)
        {
            GameManager.InfoText.text = " ";
        }


        if(other.gameObject.CompareTag("BlackDoor") && !GameManager.unlockedBlackDoor && GameManager.hasAKey)
        {
            GameManager.nearBlackDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with Black Key";
        }

        if(other.gameObject.CompareTag("BlackDoor") && GameManager.unlockedBlackDoor)
        {
            GameManager.InfoText.text = " ";
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        GameManager.nearGoldenDoor = false;
        GameManager.nearWhiteDoor = false;
        GameManager.nearBlackDoor = false;
        GameManager.nearBlueDoor = false;
        GameManager.nearRedKey = false;
        GameManager.nearGreenDoor = false;    
    }

    private void OpenDoor()
    {
        if(Input.GetKey(KeyCode.E) && GameManager.nearGoldenDoor && GameManager.hasGoldenKey && !GameManager.unlockedGoldenDoor)
        {
            GameManager.GoldenLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.GoldenLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key btw, drop it with F Key)";
            GameManager.unlockedGoldenDoor = true;
            GameManager.GoldenDoor.transform.position = GameManager.GoldenDoor.transform.position + DoorMover; 
        }

        if(Input.GetKey(KeyCode.E) && GameManager.nearWhiteDoor && GameManager.hasWhiteKey && !GameManager.unlockedWhiteDoor)
        {
            GameManager.GoldenLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.GoldenLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key btw, drop it with F Key)";
            GameManager.unlockedWhiteDoor = true;
            GameManager.WhiteDoor.transform.position = GameManager.WhiteDoor.transform.position + DoorMover; 
        }

        if(Input.GetKey(KeyCode.E) && GameManager.nearBlackDoor && GameManager.hasBlackKey && !GameManager.unlockedBlackDoor)
        {
            GameManager.BlackLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.BlackLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key btw, drop it with F Key)";
            GameManager.unlockedBlackDoor = true;
            GameManager.BlackDoor.transform.position = GameManager.BlackDoor.transform.position + DoorMover; 
        }
    }
}
