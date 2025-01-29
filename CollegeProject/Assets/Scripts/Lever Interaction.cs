using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    [Header("GameManager")]
    GameManager GameManager;

    [Header("ObjectInteraction")]
    ObjectInteraction ObjInt;

    [Header("Animator")]
    public Animator Animator;

    [Header("Interactable Objects")]
    public GameObject Lever;
    public GameObject Key;

    [Header("Player Character")]
    public GameObject Player;

    [Header("Key Remove Float")]
    public int KeyDisappearTimer = 10;

    bool isLeverActive = false;
    bool nearLeverRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Animator = GetComponent<Animator>();
        Key.SetActive(false);          
    }

    // Update is called once per frame
    void Update()
    {
        LeverActive();
        removeMechanics();
    }

    private void OnTriggerEnter(Collider other) 
    {
        GameManager.InfoText.text = "press E to flick the lever on!";
        nearLeverRange = true;   
    }

    private void OnTriggerExit(Collider other) 
    {
        nearLeverRange = false;        
    }
  
    private void LeverActive()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isLeverActive && nearLeverRange)
        {
            isLeverActive = true;
            Animator.SetBool("Lever On", true);   
            Key.SetActive(true);
            StartCoroutine("DisappearKey");           
        }                
    }

    IEnumerator DisappearKey()
    {
        yield return new WaitForSeconds(KeyDisappearTimer);
        Animator.SetBool("Lever On", false);   
        Key.SetActive(false);
        isLeverActive = false;
    }

    private void removeMechanics()
    {
        if(GameManager.hasGreenKey)
        {   
            gameObject.GetComponent<LeverInteraction>().enabled = false;             
        }
    }
}
