using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFile : File
{
    public string textInfo;
    SoundManager soundManager;

    public TextFile(string name, string textInfo){
        this.name = name;
        this.textInfo = textInfo;
        this.type = "TextFile";
    }
}
