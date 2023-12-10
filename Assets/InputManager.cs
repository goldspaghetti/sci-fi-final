using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public FileSystem fileSystem;
    public TMPro.TextMeshPro textOutput;
    string currString = "";
    string currFunction = "";
    // Update is called once per frame
    void Awake(){
        textOutput.text += "name@test /" + fileSystem.rootFolder.name + "$ help";
        fileSystem.processInput("help");
    }
    void Update()
    {
        //process the input
        foreach(char c in Input.inputString){
            //output the char on the Text

            //if enter, process the line
            processOutput(c);
        }
        //check if lines are out of bounds, if so deleat first lines

    }
    public void processOutput(char c){
        if (c == '\b'){
            if (currString.Length > 0){
                currString = currString.Remove(currString.Length - 1);
                textOutput.text = textOutput.text.Remove(textOutput.text.Length - 1);
            }
        }
        else if(c == '\n'){
            //process output
            if (currFunction == ""){
                fileSystem.processInput(currString);
            }
            else if (currFunction == "checkPassword"){
                Debug.Log("check password");
                fileSystem.checkPassword(currString);
            }
            currString = "";
        }
        else{
            currString += c;
            textOutput.text += c;
        }
    }
    public void processOutput(string output){
        Debug.Log("printing output");
        textOutput.text += '\n';
        textOutput.text += output;
        textOutput.text += "name@test /" + fileSystem.rootFolder.name + "$ ";
        currFunction = "";
    }
    public void processOutput(string output, string newFunction){
        Debug.Log("printing output");
        textOutput.text += '\n';
        textOutput.text += output;
        currFunction = newFunction;
    }
}
