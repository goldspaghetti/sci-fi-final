using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D testCollider;
    public BoxCollider2D playerCollider;
    bool textBoxEnabled = false;
    public string message = "test!!";
    //messageText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerCollider.IsTouching(testCollider));
        //Debug.Log(boxCollider.IsTouching(playerCollider));
        //(Input.GetKeyDown(KeyCode.Space) && boxCollider.IsTouching(playerCollider) && !textBoxEnabled)
        //Debug.Log(playerCollider.IsTouching(testCollider));
        if (playerCollider.IsTouching(testCollider)){
            
            Debug.Log("begining text thing");
            //trigger text box
            textBoxEnabled = true;
            //GameManager.displayText("s");
            //GameObject.FindGameObjectWithTag("Gamemanager").displayText();
                //StartCoroutine(displayText());
            
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && textBoxEnabled){
            //end text box
            textBoxEnabled = false;
        }*/
    }
    IEnumerator displayText(){
        char currChar;
        //messageText.text = "> ";
        for (int i = 0; i < message.Length; i++){
            currChar = message.ToCharArray()[i];
            yield return new WaitForSeconds(0.01f);
        }
    }
}
