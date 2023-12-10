using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MERGED WITH PlayerMovement !!!!
public class CollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public Text messageText;
    bool textEnabled = false;
    void OnCollisionStay2D(Collision2D collider){
        if (collider.gameObject.tag == "TextTrigger" && !textEnabled && Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("AAAA");
            textEnabled = true;
            //animation thing
            TriggerInfo triggerInfo = collider.gameObject.GetComponent<TriggerInfo>();
            StartCoroutine(displayText(triggerInfo.message));
            //do the thing!
        }
        if (textEnabled && Input.GetKeyDown(KeyCode.Space)){
            textEnabled = false;
            //reset Text
            messageText.text = "";
            //animation thing
        }
    }
    IEnumerator displayText(string message){
        char currChar;
        messageText.text = "> ";
        for (int i = 0; i < message.Length; i++){
            currChar = message.ToCharArray()[i];
            Debug.Log(currChar);
            yield return new WaitForSeconds(0.02f);
            messageText.text += currChar;
        }
        textEnabled = false;

    }
}
