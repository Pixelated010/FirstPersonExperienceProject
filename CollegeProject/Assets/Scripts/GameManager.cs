using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Collectable Items")]
    public GameObject GoldenKey;
    public GameObject WhiteKey;
    public GameObject BlackKey;
    public GameObject BlueKey;    
    public GameObject RedKey;
    public GameObject GreenKey;   
         
    [Header("Interactable Objects")]
    public GameObject Lever;

    [Header("Text Display")]
    public TMP_Text InfoText;

    [Header("Key Icons")]
    public Image GoldenKeyIcon;
    public Image WhiteKeyIcon;
    public Image BlackKeyIcon;
    public Image BlueKeyIcon;
    public Image RedKeyIcon;
    public Image GreenKeyIcon;   

    [Header("Key bools")]
    public bool hasGoldenKey = false;
    public bool hasWhiteKey = false;
    public bool hasBlackKey = false;
    public bool hasBlueKey = false;
    public bool hasRedKey = false;
    public bool hasGreenKey = false;

    public bool nearGoldenKey = false;
    public bool nearWhiteKey = false;
    public bool nearBlackKey = false;
    public bool nearBlueKey = false;
    public bool nearRedKey = false;
    public bool nearGreenKey = false;

    public bool hasAKey = false;
}
