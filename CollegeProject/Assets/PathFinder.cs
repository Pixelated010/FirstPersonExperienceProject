using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    
    public float RWPP = 0;
    //RWPP = Random WayPoint Position
    public float movementSpeed = 5;

    public bool currentlyWalking = false;

    public Vector3 CurrentPosition;
    public List<Vector3> MovementAreas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPosition = gameObject.transform.position;
        
        if(!currentlyWalking)
        {
            RWPP = Random.Range(1, 2);
        }
        if(RWPP == 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(CurrentPosition, MovementAreas[1], movementSpeed);
            currentlyWalking = true;
        }   
                      
    }
}
