using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Text Display")]
    public TMP_Text InfoText;  
    
    [Header("Doors")]
    public GameObject GoldenDoor;
    public GameObject WhiteDoor;
    public GameObject BlackDoor;
    public GameObject BlueDoor;
    public GameObject RedDoor;
    public GameObject GreenDoor;

    [Header("Door Locks")]
    public GameObject GoldenLock;
    public GameObject WhiteLock;
    public GameObject BlackLock;
    public GameObject BlueLock;
    public GameObject RedLock;
    public GameObject GreenLock;
    
    [Header("Near Door Bools")]
    public bool nearGoldenDoor = false;
    public bool nearWhiteDoor = false;
    public bool nearBlackDoor = false;
    public bool nearBlueDoor = false;
    public bool nearRedDoor = false;
    public bool nearGreenDoor = false;

    [Header("Unlocked Door Bools")]
    public bool unlockedGoldenDoor = false;
    public bool unlockedWhiteDoor = false;
    public bool unlockedBlackDoor = false;
    public bool unlockedBlueDoor = false;
    public bool unlockedRedDoor = false;
    public bool unlockedGreenDoor = false; 

    [Header("Destroy Lock bools")]
    public bool DestroyedLockGold = false;
    public bool DestroyedLockWhite = false;
    public bool DestroyedLockBlack = false;
    public bool DestroyedLockBlue = false;
    public bool DestroyedLockRed = false;
    public bool DestroyedLockGreen = false;

    [Header("Collectable Items")]
    public GameObject GoldenKey;
    public GameObject WhiteKey;
    public GameObject BlackKey;
    public GameObject BlueKey;    
    public GameObject RedKey;
    public GameObject GreenKey;  
    
    [Header("Has Key bools")]
    public bool hasAKey = false;    
    public bool hasGoldenKey = false;
    public bool hasWhiteKey = false;
    public bool hasBlackKey = false;
    public bool hasBlueKey = false;
    public bool hasRedKey = false;
    public bool hasGreenKey = false;

    [Header("Near Key bools")]
    public bool nearGoldenKey = false;
    public bool nearWhiteKey = false;
    public bool nearBlackKey = false;
    public bool nearBlueKey = false;
    public bool nearRedKey = false;
    public bool nearGreenKey = false;

    [Header("Key Icons")]
    public Image GoldenKeyIcon;
    public Image WhiteKeyIcon;
    public Image BlackKeyIcon;
    public Image BlueKeyIcon;
    public Image RedKeyIcon;
    public Image GreenKeyIcon;

    [Header("Interactable Objects")]
    public GameObject Lever;


}
