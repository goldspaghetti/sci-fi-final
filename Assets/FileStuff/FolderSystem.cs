using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderSystem : File{

    public ArrayList files;
    public FolderSystem parentFolder;
    public string password = "";
    public bool hasPassword;
    public bool solved;
    public bool hasTrigger;
    public string triggerAudioName;
    public FolderSystem(ArrayList files, string name){
        this.name = name;
        this.files = files;
        this.type = "folder";
        foreach(File file in files){
            if (file.type == "folder"){
                ((FolderSystem) file).setParentFolder(this);
            }
        }
        hasPassword = false;
        solved = true;

        hasTrigger = false;
    }
    public FolderSystem(ArrayList files, string name, string password){
        this.name = name;
        this.files = files;
        this.type = "folder";
        foreach(File file in files){
            if (file.type == "folder"){
                ((FolderSystem) file).setParentFolder(this);
            }
        }
        this.password = password;
        hasPassword = true;
        solved = false;

        hasTrigger = false;
    }
    public FolderSystem(ArrayList files, string name, string password, string triggerAudioName){
        this.name = name;
        this.files = files;
        this.type = "folder";
        foreach(File file in files){
            if (file.type == "folder"){
                ((FolderSystem) file).setParentFolder(this);
            }
        }
        this.password = password;
        hasPassword = true;
        solved = false;

        hasTrigger = true;
        this.triggerAudioName = triggerAudioName;
    }

    public void setParentFolder(FolderSystem parentFolder){
        this.parentFolder = parentFolder;
    }
    public FolderSystem getSubfolder(string folderName){
        foreach(File file in files){
            if (file.name == folderName && file.type == "folder"){
                return (FolderSystem) file;
            }
        }
        return this;
    }
    public AudioFile getAudioFile(string fileName){
        foreach(File file in files){
            if (file.name == fileName && file.type == "AudioFile"){
                return (AudioFile) file;
            }
        }
        return null;
    }
    public TextFile getTextFile(string fileName){
        foreach(File file in files){
            if (file.name == fileName && file.type == "TextFile"){
                return (TextFile) file;
            }
        }
        return null;
    }

    public bool ifFolderExists(string folderName){
        foreach(File file in files){
            //should be a better way to find the class, but whatever
            if (file.name == folderName && file.type == "folder"){
                return true;
            }
        }
        return false;
    }
    public bool ifAudioFileExists(string fileName){
        foreach(File file in files){
            if (file.name == fileName && file.type == "AudioFile"){
                return true;
            }
        }
        return false;
    }
    public bool ifTextFileExists(string fileName){
        foreach(File file in files){
            if (file.name == fileName && file.type == "TextFile"){
                return true;
            }
        }
        return false;
    }
    public string toString(){
        string outputString = "";
        foreach(File file in files){
            outputString += file.name;
            outputString += '\n';
        }
        return outputString;
    }
}
