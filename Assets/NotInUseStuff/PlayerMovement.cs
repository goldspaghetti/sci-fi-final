using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float moveSpeed;
    public BoxCollider2D playerCollider;
    public BoxCollider2D testCollider;
    //public Text messageText;
    bool textEnabled = false;
    Vector2 moveVector = new Vector2();
    public GameObject dialogue;
    public TextMesh messageText;
    public GameObject background;
    public Transform cameraTransform;

    void Start()
    {
        
    }
    void Update(){
        if (Input.GetKey(KeyCode.A)){
            moveVector.x = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D)){
            moveVector.x = moveSpeed;
        }
        else {
            moveVector.x = 0;
        }
        if (Input.GetKey(KeyCode.W)){
            moveVector.y = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S)){
            moveVector.y = -1 * moveSpeed;
        }
        else{
            moveVector.y = 0;
        }
    }

    void FixedUpdate(){
        move();
    }
    void OnCollisionStay2D(Collision2D collider){
        if (collider.gameObject.tag == "TextTrigger" && !textEnabled && Input.GetKeyDown(KeyCode.Space)){
            
            Debug.Log("AAAA");
            textEnabled = true;
            //animation thing
            dialogue.SetActive(true);
            background.transform.position = cameraTransform.position;
            messageText.transform.position = cameraTransform.position;

            //setting background and text to correct proportions



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
    void move(){
        /*Vector2 moveVector = new Vector2();
        if (Input.GetKey(KeyCode.A)){
            moveVector.x = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D)){
            moveVector.x = moveSpeed;
        }
        else {
            moveVector.x = 0;
        }
        if (Input.GetKey(KeyCode.W)){
            moveVector.y = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S)){
            moveVector.y = -1 * moveSpeed;
        }
        else{
            moveVector.y = 0;
        }*/
        this.rigidBody.velocity = moveVector * Time.deltaTime;
        /*if 
        if (rigidBody.velocity.x > maxVelocity){
            this.rigidBody.velocity = new Vector2(maxVelocity, this.rigidBody.velocity.y);
        }
        else{
            this.rigidBody.velocity = new Vector2();
        }*/
    }
}
