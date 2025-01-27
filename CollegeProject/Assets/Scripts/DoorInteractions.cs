using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractions : MonoBehaviour
{
    
    public int LockFallTimer = 3;
    public float LockRemovalTimer = 5;
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
        KeyRemove();       
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


        if(other.gameObject.CompareTag("BlueDoor") && !GameManager.unlockedBlueDoor && GameManager.hasAKey)
        {
            GameManager.nearBlueDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with Blue Key";
        }

        if(other.gameObject.CompareTag("BlueDoor") && GameManager.unlockedBlackDoor)
        {
            GameManager.InfoText.text = " ";
        }


        if(other.gameObject.CompareTag("RedDoor") && !GameManager.unlockedRedDoor && GameManager.hasAKey)
        {
            GameManager.nearRedDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with Red Key";
        }

        if(other.gameObject.CompareTag("RedDoor") && GameManager.unlockedRedDoor)
        {
            GameManager.InfoText.text = " ";
        }

        
        if(other.gameObject.CompareTag("GreenDoor") && !GameManager.unlockedGreenDoor && GameManager.hasAKey)
        {
            GameManager.nearGreenDoor = true;
            GameManager.InfoText.text = "Press E to unlock Door with Green Key";
        }

        if(other.gameObject.CompareTag("GreenDoor") && GameManager.unlockedGreenDoor)
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
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedGoldenDoor = true;
            GameManager.GoldenDoor.transform.position = GameManager.GoldenDoor.transform.position + DoorMover; 
        }

        if(Input.GetKey(KeyCode.E) && GameManager.nearWhiteDoor && GameManager.hasWhiteKey && !GameManager.unlockedWhiteDoor)
        {
            GameManager.WhiteLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.WhiteLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedWhiteDoor = true;
            GameManager.WhiteDoor.transform.position = GameManager.WhiteDoor.transform.position + DoorMover; 
        }

        if(Input.GetKey(KeyCode.E) && GameManager.nearBlackDoor && GameManager.hasBlackKey && !GameManager.unlockedBlackDoor)
        {
            GameManager.BlackLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.BlackLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedBlackDoor = true;
            GameManager.BlackDoor.transform.position = GameManager.BlackDoor.transform.position + DoorMover;                       
        }

        if(Input.GetKey(KeyCode.E) && GameManager.nearBlueDoor && GameManager.hasBlueKey && !GameManager.unlockedBlueDoor)
        {
            GameManager.BlueLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.BlueLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedBlueDoor = true;
            GameManager.BlueDoor.transform.position = GameManager.BlueDoor.transform.position + DoorMover;                       
        }


        if(Input.GetKey(KeyCode.E) && GameManager.nearRedDoor && GameManager.hasRedKey && !GameManager.unlockedRedDoor)
        {
            GameManager.RedLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.RedLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedRedDoor = true;
            GameManager.RedDoor.transform.position = GameManager.RedDoor.transform.position + DoorMover;                       
        }

        
        if(Input.GetKey(KeyCode.E) && GameManager.nearGreenDoor && GameManager.hasGreenKey && !GameManager.unlockedGreenDoor)
        {
            GameManager.GreenLock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.GreenLock.GetComponent<Rigidbody>().useGravity = true;
            GameManager.InfoText.text = "You unlocked the door (you still have the key, drop it with F Key)";
            GameManager.unlockedGreenDoor = true;
            GameManager.GreenDoor.transform.position = GameManager.GreenDoor.transform.position + DoorMover;                       
        }

    }

    private void KeyRemove()
    {
        StartCoroutine(RemoveLockTimer());
    }

    private IEnumerator RemoveLockTimer()
    {
        if(GameManager.unlockedGoldenDoor && !GameManager.DestroyedLockGold)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.GoldenLock);
            GameManager.DestroyedLockGold = true;
        }
        if(GameManager.unlockedWhiteDoor && !GameManager.DestroyedLockWhite)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.WhiteLock);
            GameManager.DestroyedLockWhite = true;
        }
        if(GameManager.unlockedBlackDoor && !GameManager.DestroyedLockBlack)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.BlackLock);
            GameManager.DestroyedLockBlack = true;
        }
        if(GameManager.unlockedBlueDoor && !GameManager.DestroyedLockBlue)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.BlueLock);
            GameManager.DestroyedLockBlue = true;
        }
        if(GameManager.unlockedRedDoor && !GameManager.DestroyedLockRed)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.RedLock);
            GameManager.DestroyedLockRed = true;
        }
        if(GameManager.unlockedGreenDoor && !GameManager.DestroyedLockGreen)
        {
            yield return new WaitForSeconds(LockRemovalTimer);
            Destroy(GameManager.GreenLock);
            GameManager.DestroyedLockGreen = true;
        }
    }
}
