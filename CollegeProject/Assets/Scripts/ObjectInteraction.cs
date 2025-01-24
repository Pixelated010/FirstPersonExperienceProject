using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    
    public GameObject PlayerObject;
    
    Vector3 PlayerPosition;
    
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
        PlayerObject = this.gameObject;
        PlayerPosition = PlayerObject.transform.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("GoldenKey"))
        {
            GameManager.InfoText.text = "Pick up Golden Key with E";    


            
        }

        if(other.gameObject.CompareTag("WhiteKey"))
        {
            GameManager.hasWhiteKey = true;    
        } 

        if(other.gameObject.CompareTag("BlackKey"))
        {
            GameManager.hasBlackKey = true;
        } 

        if(other.gameObject.CompareTag("BlueKey"))
        {
            GameManager.hasBlueKey = true;
        } 

        if(other.gameObject.CompareTag("RedKey"))
        {
            GameManager.hasRedKey = true;
        }   

        if(other.gameObject.CompareTag("GreenKey"))
        {
            GameManager.hasGreenKey = true;
        }
    }

    private void PickUpKey()
        {
        if (Input.GetKey(KeyCode.E))
            {
                GameManager.hasGoldenKey = true;            
            }
        }
}
