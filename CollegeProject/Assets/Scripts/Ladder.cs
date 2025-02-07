using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [Header("Player Info")]
    public GameObject Player;

    [Header("GameManager Script")]
    GameManager GameManager;

    [Header("Transform Floor Positions")]
    public Transform FirstFloor;
    public Transform SecondFloor;

    [Header("Floor Detection")]
    public GameObject floorOneDetection;
    public GameObject floorTwoDetection;

    [Header("Ladder Bools")]
    public bool nearLadderFirstFloor;
    public bool nearLadderSecondFloor;
    public bool AscendedLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.InfoText.text = " ";        
    }
    

    // Update is called once per frame
    void Update()
    {
        ascendLadder();   
        descendLadder();     
    }

    private void OnTriggerEnter(Collider other)
    {
        nearLadderText(other);

        if(other.gameObject.CompareTag("FirstFloor"))
        {
            AscendedLadder = false;
        }

        if(other.gameObject.CompareTag("SecondFloor"))
        {
            AscendedLadder = true;
        }
    }

    private void nearLadderText(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder") && !AscendedLadder && !GameManager.hasAKey)
        {
            GameManager.InfoText.text = "Press E to ascend to the second floor!";
            nearLadderFirstFloor = true;
        }

        if (other.gameObject.CompareTag("Ladder") && AscendedLadder && !GameManager.hasAKey)
        {
            GameManager.InfoText.text = "Press E to descend to the second floor!";
            nearLadderSecondFloor = true;
        }

        if (other.gameObject.CompareTag("Ladder") && GameManager.hasAKey)
        {
            GameManager.InfoText.text = "You need to drop the key in order to climb the ladder!";
        }
    }

    private void ascendLadder()
    {
        if(Input.GetKeyDown(KeyCode.E) && nearLadderFirstFloor && !AscendedLadder)
        {
            Player.GetComponent<CharacterController>().enabled = false;    
            Player.transform.position = SecondFloor.position;
            Player.GetComponent<CharacterController>().enabled = true; 
            AscendedLadder = true;
            nearLadderFirstFloor = false;
        }
    }

    private void descendLadder()
    {
        if(Input.GetKeyDown(KeyCode.E) && nearLadderSecondFloor && AscendedLadder)
        {
            Player.GetComponent<CharacterController>().enabled = false;    
            Player.transform.position = FirstFloor.position;
            Player.GetComponent<CharacterController>().enabled = true; 
            AscendedLadder = false;
            nearLadderSecondFloor = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        nearLadderFirstFloor = false;
        nearLadderSecondFloor = false;                
    }
}
