using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // a float called movespeed which allows me to change the players speed in game
    [SerializeField] float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //floats  for the x and y axis to character move left and right
        float xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //makes it so when it detects the inputs from the x and y floats it moves the player character
        transform.Translate(xAxis, 0, yAxis);        
    }
}
