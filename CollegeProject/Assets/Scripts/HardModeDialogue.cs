using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HardModeDialogue : MonoBehaviour
{
    GameManager GameManager;
    
    public int TextReadTimer = 15;

    [SerializeField] public Scene HardMode;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowDialogue()
    {
        GameManager.InfoText.text = "You beat the game!";
        StartCoroutine(TimeForReadDialogue());   
    }

    private IEnumerator TimeForReadDialogue()
    {
        yield return new WaitForSeconds(TextReadTimer);
        GameManager.InfoText.text = "Time to play hard mode!";
        yield return new WaitForSeconds(TextReadTimer);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Hard Mode");
    }
}
