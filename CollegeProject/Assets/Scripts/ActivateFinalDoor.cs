using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateFinalDoor : MonoBehaviour
{
    public GameObject playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<FinalDoor>().enabled = true;
            Destroy(this.gameObject);
        }        
    }
}
