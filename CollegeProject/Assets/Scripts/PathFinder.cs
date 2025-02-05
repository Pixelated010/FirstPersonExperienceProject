using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    
    NavMeshAgent Agent;
    GameManager GameManager;
    
    [Header("Room Movement Area GameObjects")]
    public Transform GreenRoom1;
    public Transform GreenRoom2;    
    public Transform BlueRoom1;
    public Transform BlueRoom2;
    public Transform WhiteRoom1;
    public Transform WhiteRoom2;
    public Transform BlackRoom1;
    public Transform GoldRoom1;

    [Header("Path Finding Stuff")]
    public int RWPP = 0;
    //RWPP = Random WayPoint Position

    public bool currentlyWalking = false;

    public List<Transform> MovementAreas;
    Transform target;

    bool active;
    bool GMB;
    //GREEN MOVEMENT BOOL
    bool BMB;
    //BLUE MOVEMENT BOOL
    bool WMB;
    bool BlkMB;
    bool GldMB;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Agent = GetComponent<NavMeshAgent>();   
        RWPP = Random.Range(0, 19);
        target = MovementAreas[RWPP];
        currentlyWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 1f)
        {
            Debug.Log("1");
            if (!active)
            {
                Debug.Log("2");
                StartCoroutine(Randomize());
            }
        }

        if (currentlyWalking)
        {
            Agent.destination = target.position;
        }

        AddGreenMovementPositions();
        AddBlueKeyMovementPositions();
        AddWhiteKeyMovementPositions();
        AddBlackKeyMovementPositions();
        AddGoldKeyMovenentPositions();
    }

    private void AddGreenMovementPositions()
    {
        if (GameManager.unlockedGreenDoor == true && !GMB)
        {
            MovementAreas.Add(GreenRoom1);
            MovementAreas.Add(GreenRoom2);
            GMB = true;
        }
    }
    
    private void AddBlueKeyMovementPositions()
    {
        if(GameManager.unlockedBlueDoor == true && !BMB)
        {
            MovementAreas.Add(BlueRoom1);
            MovementAreas.Add(BlueRoom2);
            BMB = true;    
        }
    }

    private void AddWhiteKeyMovementPositions()
    {
        if(GameManager.unlockedWhiteDoor == true && !WMB)
        {
            MovementAreas.Add(WhiteRoom1);
            MovementAreas.Add(WhiteRoom2);
            WMB = true;    
        }
    }

    private void AddBlackKeyMovementPositions()
    {
        if(GameManager.unlockedBlackDoor == true && !BlkMB)
        {
            MovementAreas.Add(BlackRoom1);
            BlkMB = true;    
        }
    }

    private void AddGoldKeyMovenentPositions()
    {
        if(GameManager.unlockedGoldenDoor == true && !GldMB)
        {
            MovementAreas.Add(GoldRoom1);
            GldMB = true;
        }
    }

    IEnumerator Randomize()
    {
        active = true;
        RWPP = Random.Range(0, MovementAreas.Count);
        target = MovementAreas[RWPP];
        yield return new WaitForSeconds(1.5f);

        active = false;
    }
}
