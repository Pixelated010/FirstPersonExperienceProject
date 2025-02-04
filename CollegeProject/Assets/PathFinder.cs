using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    
    NavMeshAgent Agent;
    
    public int RWPP = 0;
    //RWPP = Random WayPoint Position
    public float movementSpeed = 5;

    public bool currentlyWalking = false;

    public List<Transform> MovementAreas;

    Transform target;

    bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();   

        RWPP = Random.Range(0, 2);
        target = MovementAreas[RWPP];
        currentlyWalking = true;
    }

    // Update is called once per frame
    void Update()
    {  
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance < 1f)
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
