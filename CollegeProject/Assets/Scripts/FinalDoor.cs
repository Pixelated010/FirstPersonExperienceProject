using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class FinalDoor : MonoBehaviour
{

    
    [Header("Scripts")]
    GameManager GameManager;
    DoorInteractions DoorInteractions;
    
    [Header("Door Values")]
    public int DoorValue;
    public int completionValue = 0;

    [Header("Door Assets")]
    public GameObject Door;
    public GameObject Lock;

    [Header("Materials")]
    [SerializeField] Material GoldenMaterial;
    [SerializeField] Material WhiteMaterial;
    [SerializeField] Material BlackMaterial;
    [SerializeField] Material BlueMaterial;
    [SerializeField] Material RedMaterial;
    [SerializeField] Material GreenMaterial;

    [Header("Keys")]
    [SerializeField] GameObject GoldenKey; 
    [SerializeField] GameObject WhiteKey;
    [SerializeField] GameObject BlackKey;
    [SerializeField] GameObject BlueKey;
    [SerializeField] GameObject RedKey;
    [SerializeField] GameObject GreenKey;

    [Header("Bools")]
    public bool GoldenFinalDoor;
    public bool WhiteFinalDoor;
    public bool BlackFinalDoor;
    public bool RedFinalDoor;
    public bool GreenFinalDoor;
    public bool BlueFinalDoor;

    public bool completedGoldFinalDoor;
    public bool completedWhiteFinalDoor;
    public bool completedBlackFinalDoor;
    public bool completedRedFinalDoor;
    public bool completedBlueFinalDoor;
    public bool completedGreenFinalDoor;

    public bool NearFinalDoor;

    public bool needNewColour = true;

    // Start is called before the first frame update
    void Start()
    {
        DoorInteractions = GetComponent<DoorInteractions>();     
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        RandomDoorColour();
    }

    private void RandomDoorColour()
    {
        DoorValue = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        SetDoorColour();
        OpenFinalDoor();
    }

    private void SetDoorColour()
    {
        if (DoorValue == 0 && !completedGoldFinalDoor) //0 = gold
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = GoldenMaterial;
            Lock.GetComponent<MeshRenderer>().material = GoldenMaterial;
            GoldenFinalDoor = true;
        }

        if (DoorValue == 0 && completedGoldFinalDoor) //0 = gold
        {
            RandomDoorColour();
        }
 
        if (DoorValue == 1 && !completedWhiteFinalDoor) //1 = White
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = WhiteMaterial;
            Lock.GetComponent<MeshRenderer>().material = WhiteMaterial;
            WhiteFinalDoor = true;
        }

        if (DoorValue == 1 && completedWhiteFinalDoor) //1 = White
        {
            RandomDoorColour();
        }
 
        if (DoorValue == 2 && !completedBlackFinalDoor) //2 = Black
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = BlackMaterial;
            Lock.GetComponent<MeshRenderer>().material = BlackMaterial;
            BlackFinalDoor = true;
        }

        if (DoorValue == 2 && completedBlackFinalDoor) //2 = Black
        {
            RandomDoorColour();
        }

        if (DoorValue == 3 && !completedBlueFinalDoor) //3 = Blue
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = BlueMaterial;
            Lock.GetComponent<MeshRenderer>().material = BlueMaterial;
            BlueFinalDoor = true;
        }

        if (DoorValue == 3 && completedBlueFinalDoor) //3 = Blue
        {
            RandomDoorColour();
        }        
    
        if (DoorValue == 4 && !completedRedFinalDoor) //4 = Red
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = RedMaterial;
            Lock.GetComponent<MeshRenderer>().material = RedMaterial;
            RedFinalDoor = true;
        }

        if (DoorValue == 4 && completedRedFinalDoor) //4 = Red
        {
            RandomDoorColour();
        }

        if (DoorValue == 5 && !completedGreenFinalDoor) //5 = Green
        {
            needNewColour = false;
            Door.GetComponent<MeshRenderer>().material = GreenMaterial;
            Lock.GetComponent<MeshRenderer>().material = GreenMaterial;
            GreenFinalDoor = true;
        }

        if (DoorValue == 5 && completedGreenFinalDoor) //5 = Green
        {
            RandomDoorColour();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("FinalDoor") && GoldenFinalDoor && GameManager.hasGoldenKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with Golden Key";
            NearFinalDoor = true;
        }


        if(other.gameObject.CompareTag("FinalDoor") && WhiteFinalDoor && GameManager.hasWhiteKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with White Key";
            NearFinalDoor = true;
        }

        
        if(other.gameObject.CompareTag("FinalDoor") && BlackFinalDoor && GameManager.hasBlackKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with Black Key";
            NearFinalDoor = true;
        }


        if(other.gameObject.CompareTag("FinalDoor") && BlueFinalDoor && GameManager.hasBlueKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with Blue Key";
            NearFinalDoor = true;
        }


        if(other.gameObject.CompareTag("FinalDoor") && RedFinalDoor && GameManager.hasRedKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with Red Key";
            NearFinalDoor = true;
        }

        
        if(other.gameObject.CompareTag("FinalDoor") && GreenFinalDoor && GameManager.hasGreenKey)
        {
            GameManager.InfoText.text = "Press E to unlock Door with Green Key";
            NearFinalDoor = true;
        }
    }

    
    private void OpenFinalDoor()
    {
        if(Input.GetKey(KeyCode.E) && GoldenFinalDoor && NearFinalDoor && GameManager.hasGoldenKey) //open gold door
        {
            GameManager.hasGoldenKey = false;
            GameManager.hasAKey = false; 
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedGoldFinalDoor = true;
            completionValue++;
            RandomDoorColour();
            GoldenFinalDoor = false;    
        }


        if(Input.GetKey(KeyCode.E) && WhiteFinalDoor && NearFinalDoor && GameManager.hasWhiteKey) //open white door
        {
            GameManager.hasWhiteKey = false;
            GameManager.hasAKey = false;  
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedWhiteFinalDoor = true;
            completionValue++;
            RandomDoorColour();    
            WhiteFinalDoor = false;    
        }

        
        if(Input.GetKey(KeyCode.E) && BlackFinalDoor && NearFinalDoor && GameManager.hasBlackKey) //open black door
        {
            GameManager.hasBlackKey = false;
            GameManager.hasAKey = false;  
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedBlackFinalDoor = true;
            completionValue++;
            RandomDoorColour(); 
            BlackFinalDoor = false;      
        }


        if(Input.GetKey(KeyCode.E) && BlueFinalDoor && NearFinalDoor && GameManager.hasBlueKey) //open Blue door
        {
            GameManager.hasBlueKey = false;
            GameManager.hasAKey = false;  
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedBlueFinalDoor = true;
            completionValue++;  
            RandomDoorColour(); 
            BlueFinalDoor = false;    
        }


        if(Input.GetKey(KeyCode.E) && RedFinalDoor && NearFinalDoor && GameManager.hasRedKey) //open Red door
        {
            GameManager.hasRedKey = false; 
            GameManager.hasAKey = false; 
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedRedFinalDoor = true;
            completionValue++;  
            RandomDoorColour(); 
            RedFinalDoor = false;   
        }

        
        if(Input.GetKey(KeyCode.E) && GreenFinalDoor && NearFinalDoor && GameManager.hasGreenKey) //open Green door
        {
            GameManager.hasGreenKey = false; 
            GameManager.hasAKey = false;
            GameManager.InfoText.text = "It seems that the key broke, try another coloured key";  
            completedGreenFinalDoor = true;
            completionValue++;    
            RandomDoorColour();  
            GreenFinalDoor = false;
        }

        if(completionValue == 6)
        {
            GameManager.InfoText.text = "The door opened, Escape!";
            gameObject.transform.position = gameObject.transform.position + DoorInteractions.DoorMover;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("FinalDoor"))
        {
            GameManager.InfoText.text = "";
            NearFinalDoor = false;    
        }        
    }
}
