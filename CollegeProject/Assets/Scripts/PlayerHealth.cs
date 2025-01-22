using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int HitCount = 3;
    [SerializeField] int TimeDuration = 5;

    public Slider HealthSlider;

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
            HealthSlider.value = HealthSlider.value-1;
            isAttackable = false;
            StartCoroutine("TimeDelay");
        }    
    }
    
    void loseAllHearts()
    {
        if(HitCount == 0)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(TimeDuration);
        isAttackable = true;
    }
}
