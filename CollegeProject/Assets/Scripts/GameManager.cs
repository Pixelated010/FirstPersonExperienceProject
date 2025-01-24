using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [Header("PlayerPosition")]
    Vector3 PlayerPosition;
    public GameObject Player;

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

    public bool hasAKey = false;
    
    // Update is called once per frame
    void Update()
    {
        PlayerPosition = transform.position;        
    }
}
