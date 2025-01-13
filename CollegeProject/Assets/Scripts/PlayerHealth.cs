using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int HitCount = 3;
    [SerializeField] int TimeDuration = 5;

    bool isAttackable = true;

    private void Start() 
    {
        
    }

    void Update()
    {
        loseAllHearts();     
    }

    void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.CompareTag("Enemy"))
        {
            attack();
        }             
    }

    void attack()
    {
        if(isAttackable == true)
        {
            HitCount = HitCount-1;
            isAttackable = false;
            StartCoroutine("TimeDelay");
        }    
    }
    
    void loseAllHearts()
    {
        if(HitCount == 0)
        {
            SceneManager.LoadScene("CurrentScene");
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(TimeDuration);
        isAttackable = true;
    }
}
