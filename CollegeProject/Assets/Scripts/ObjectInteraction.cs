using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [Header("Player Info")]
    public GameObject PlayerObject;

    Vector3 PlayerPosition;

    [Header("Text Time Duration")]
    public float TextTimeDuration = 5;

    [Header("GameManager Script")]
    GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.InfoText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerObject = gameObject;
        PlayerPosition = PlayerObject.transform.position;

        DropKey();

        if(GameManager.hasGoldenKey)
        {
            GameManager.GoldenKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.GoldenKeyIcon.enabled = false;
        }

        if(GameManager.hasWhiteKey)
        {
            GameManager.WhiteKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.WhiteKeyIcon.enabled = false;
        }

        if(GameManager.hasBlackKey)
        {
            GameManager.BlackKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.BlackKeyIcon.enabled = false;
        }

        if(GameManager.hasBlueKey)
        {
            GameManager.BlueKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.BlueKeyIcon.enabled = false;
        }

        if(GameManager.hasRedKey)
        {
            GameManager.RedKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.RedKeyIcon.enabled = false;
        }
        
        if(GameManager.hasGreenKey)
        {
            GameManager.GreenKeyIcon.enabled = true;            
        }
        else
        {
            GameManager.GreenKeyIcon.enabled = false;
        }               
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("GoldenKey") && !GameManager.hasAKey)
        {
            GameManager.nearGoldenKey = true;
            GameManager.InfoText.text = "Pick up Golden Key with E";    
            PickUpKey();
        }

        if(other.gameObject.CompareTag("WhiteKey"))
        {
            GameManager.nearWhiteKey = true;
            GameManager.InfoText.text = "Pick up White Key with E";    
            PickUpKey(); 
        } 

        if(other.gameObject.CompareTag("BlackKey"))
        {
            GameManager.nearBlackKey = true;
            GameManager.InfoText.text = "Pick up Black Key with E";    
            PickUpKey(); 
        } 

        if(other.gameObject.CompareTag("BlueKey"))
        {
            GameManager.nearBlueKey = true;
            GameManager.InfoText.text = "Pick up Blue Key with E";    
            PickUpKey(); 
        } 

        if(other.gameObject.CompareTag("RedKey"))
        {
            GameManager.nearRedKey = true;
            GameManager.InfoText.text = "Pick up Red Key with E";    
            PickUpKey(); 
        }   

        if(other.gameObject.CompareTag("GreenKey"))
        {
            GameManager.nearGreenKey = true;
            GameManager.InfoText.text = "Pick up Red Key with E";    
            PickUpKey(); 
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        GameManager.InfoText.text = " ";
        GameManager.nearGoldenKey = false;
        GameManager.nearWhiteKey = false;
        GameManager.nearBlackKey = false;
        GameManager.nearBlueKey = false;
        GameManager.nearRedKey = false;
        GameManager.nearGreenKey = false;        
    }

    private void PickUpKey()
    {
        if (Input.GetKey(KeyCode.E) && GameManager.nearGoldenKey && !GameManager.hasAKey)
        {
            GameManager.GoldenKey.SetActive(false);

            GameManager.hasGoldenKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }

        if (Input.GetKey(KeyCode.E) && GameManager.nearWhiteKey && !GameManager.hasAKey)
        {
            GameManager.WhiteKey.SetActive(false);

            GameManager.hasWhiteKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }

        if (Input.GetKey(KeyCode.E) && GameManager.nearBlackKey && !GameManager.hasAKey)
        {
            GameManager.BlackKey.SetActive(false);

            GameManager.hasBlackKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }

        if (Input.GetKey(KeyCode.E) && GameManager.nearBlueKey && !GameManager.hasAKey)
        {
            GameManager.BlueKey.SetActive(false);

            GameManager.hasBlueKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }

        if (Input.GetKey(KeyCode.E) && GameManager.nearRedKey && !GameManager.hasAKey)
        {
            GameManager.RedKey.SetActive(false);

            GameManager.hasRedKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }

        if (Input.GetKey(KeyCode.E) && GameManager.nearGreenKey && !GameManager.hasAKey)
        {
            GameManager.GreenKey.SetActive(false);

            GameManager.hasGreenKey = true;
            GameManager.hasAKey = true;

            StartCoroutine("ShowCollectKeyText");
        }
    }

    private void DropKey()
    {
        if(Input.GetKey(KeyCode.F) && GameManager.hasGoldenKey)
        {
            GameManager.GoldenKey.SetActive(true);
            GameManager.GoldenKey.transform.position = PlayerPosition;
            GameManager.hasGoldenKey = false;
            GameManager.hasAKey = false;

            StartCoroutine("ShowDropKeyText");
        }

        if(Input.GetKey(KeyCode.F) && GameManager.hasWhiteKey)
        {
            GameManager.WhiteKey.SetActive(true);
            GameManager.WhiteKey.transform.position = PlayerPosition;
            GameManager.hasWhiteKey = false;
            GameManager.hasAKey = false;

            StartCoroutine("ShowDropKeyText");
        }

        if(Input.GetKey(KeyCode.F) && GameManager.hasBlackKey)
        {
            GameManager.BlackKey.SetActive(true);
            GameManager.BlackKey.transform.position = PlayerPosition;
            GameManager.hasBlackKey = false;
            GameManager.hasAKey = false;

            StartCoroutine("ShowDropKeyText");
        }

        if(Input.GetKey(KeyCode.F) && GameManager.hasBlueKey)
        {
            GameManager.BlueKey.SetActive(true);
            GameManager.BlueKey.transform.position = PlayerPosition;
            GameManager.hasBlueKey = false;
            GameManager.hasAKey = false;

            StartCoroutine("ShowDropKeyText");
        }

        if(Input.GetKey(KeyCode.F) && GameManager.hasRedKey)
        {
            GameManager.RedKey.SetActive(true);
            GameManager.RedKey.transform.position = PlayerPosition;
            GameManager.hasRedKey = false;
            GameManager.hasAKey = false;

            StartCoroutine("ShowDropKeyText");
        }
        
        if(Input.GetKey(KeyCode.F) && GameManager.hasGreenKey)
        {
            GameManager.GreenKey.SetActive(true);
            GameManager.GreenKey.transform.position = PlayerPosition;
            GameManager.hasGreenKey = false;
            GameManager.hasAKey = false;
            
            StartCoroutine("ShowDropKeyText");
        }
    }

    IEnumerator ShowCollectKeyText()
    {
        GameManager.InfoText.text = "You picked up a key, press F to drop it";        
        yield return new WaitForSeconds(TextTimeDuration);
        GameManager.InfoText.text = " ";
    }

    IEnumerator ShowDropKeyText()
    {
        GameManager.InfoText.text = "You dropped the key";        
        yield return new WaitForSeconds(TextTimeDuration);
        GameManager.InfoText.text = " ";
    }

}
