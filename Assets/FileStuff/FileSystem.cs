using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public InputManager inputManager;
    public FolderSystem rootFolder;
    public FolderSystem selectedFolder;
    public SoundManager soundManager;
    public MusicController musicController;
    /*public FileSystem(){
        //init the root folder!
        FolderSystem folder1 = new FolderSystem(new ArrayList(), "folder1");
        ArrayList folder2files = new ArrayList();

        AudioFile test1 = new AudioFile("billards.mp3", "billards", soundManager);

        folder2files.Add(folder1);
        folder2files.Add(test1);

        FolderSystem folder2 = new FolderSystem(folder2files, "folder2");
        rootFolder = folder2;
    }*/
    void Awake(){
        //init the root folder!
        //test folder system
        /*FolderSystem folder1 = new FolderSystem(new ArrayList(), "folder1", "test");
        ArrayList folder2files = new ArrayList();

        AudioFile test1 = new AudioFile("billards.mp3", "billards", soundManager);

        folder2files.Add(folder1);
        folder2files.Add(test1);

        FolderSystem folder2 = new FolderSystem(folder2files, "folder2");
        folder2.setParentFolder(folder2);
        rootFolder = folder2;*/
        
        //ACTUAL FOLDERS

        //RIDDLES
        FolderSystem resign = new FolderSystem(new ArrayList(), "RESIGN", "shrek", "f3end");


        ArrayList ItsTimeFiles = new ArrayList();
        ItsTimeFiles.Add(resign);

        string shrekStr = "I am big, and I am green.\nI am an onion in a swamp.\nA princess married me instead of a super short king.\nWho am I?\n";
        AudioFile getOutSwamp = new AudioFile("GetOutOfMySwamp.mp3", "shrek", soundManager, shrekStr);
        ItsTimeFiles.Add(getOutSwamp);

        string timeStr = "I have the tools. It’s time. (cuts out) is going to pay.\n";
        AudioFile time = new AudioFile("itsTime.mp3", "itsTime", soundManager, timeStr);
        ItsTimeFiles.Add(time);

        FolderSystem itsTime = new FolderSystem(ItsTimeFiles, "ItsTime", "shark", "f2end");


        ArrayList myPlanFiles = new ArrayList();
        myPlanFiles.Add(itsTime);

        /*string passwordStr = "<Cthon98> hey, if you type in your pw, it will show as stars\n<Cthon98> ********* see!\n<AzureDiamond> hunter2\n<AzureDiamond> doesnt look like stars to me\n<Cthon98> <AzureDiamond> *******\n<Cthon98> thats what I see\n<AzureDiamond> oh, really?\n<Cthon98> Absolutely\n<AzureDiamond> you can go hunter2 my hunter2-ing hunter2\n<AzureDiamond> haha, does that look funny to you?\n<Cthon98> lol, yes. See, when YOU type hunter2, it shows to us as *******\n<AzureDiamond> thats neat, I didnt know IRC did that\n<Cthon98> yep, no matter how many times you type hunter2, it will show to us as *******\n<AzureDiamond> awesome!\n<AzureDiamond> wait, how do you know my pw?\n<Cthon98> er, I just copy pasted YOUR ******'s and it appears to YOU as hunter2 cause its your pw\n<AzureDiamond> oh, ok.\n";
        TextFile password = new TextFile("244321.txt", passwordStr);
        myPlanFiles.add(password);*/

        string passwordStr = "<jeebus> the \"bishop\" came to our church today\n<jeebus> he was a fucken impostor\n<jeebus> never once moved diagonally\n";
        TextFile password = new TextFile("261501.txt", passwordStr);
        myPlanFiles.Add(password);

        string sharkStr = "I love the ocean blue.\nI can only go one way.\nTo stop is to die.\nI kill 10, coconuts kill 150.\nWhat am I?\n";
        AudioFile shark = new AudioFile("Endangered.mp3", "shark", soundManager, sharkStr);
        myPlanFiles.Add(shark);

        AudioFile randomPlug = new AudioFile("hmmst.mp3", "hmmst", soundManager);
        myPlanFiles.Add(randomPlug);

        string planStr = "I am going to do it in three days.\n";
        AudioFile plan = new AudioFile("myPlan.mp3", "myPlan", soundManager, planStr);
        myPlanFiles.Add(plan);


        FolderSystem myPlan = new FolderSystem(myPlanFiles, "MyPlan", "wind", "f1end");

        ArrayList whistlingFiles = new ArrayList();
        whistlingFiles.Add(myPlan);

        string windStr = "what is silent but always present.\nMakes the trees whistle it’s tune.\nRefreshing on a blazing day.\n";
        AudioFile wind = new AudioFile("Rustling.mp3", "wind", soundManager, windStr);
        whistlingFiles.Add(wind);

        /*string passwordStr = "<jeebus> the "bishop" came to our church today\n<jeebus> he was a fucken impostor\n<jeebus> never once moved diagonally\n";
        TextFile password = new TextFile("261501.txt", passwordStr);
        whistlingFiles.Add(password);*/
        string robotStr = "<Patrician|Away> what does your robot do, sam\n<bovril> it collects data about the surrounding environment, then discards it and drives into walls\n";
        TextFile robot = new TextFile("240849.txt", robotStr);
        whistlingFiles.Add(robot);

        FolderSystem whistling = new FolderSystem(whistlingFiles, "Whisling");

        whistling.setParentFolder(whistling);
        rootFolder = whistling;

        //
        
    }
    void Start(){
        //MUSIC
        musicController.startMusic("computerFan");
    }
    //maybe make processinput return a string and make inputmanager act off that? Means it could be static
    public void processInput(string input){
        string command = "";
        string argument = "";
        if (input.IndexOf(' ') != -1){
            command = input.Substring(0, input.IndexOf(' '));
            if (input.Length >= input.IndexOf(' ') + 1){
                argument = input.Substring(input.IndexOf(' ') + 1);
            }
        }
        else{
            command = input;
        }
        Debug.Log("command: " + command);
        Debug.Log("argument: " + argument);
        if(command == "ls"){
            //display files
            //process if input works
            inputManager.processOutput(rootFolder.toString());
        }
        else if (command == "cd"){
            if (argument == "" || argument == " " || argument == ".."){
                rootFolder = rootFolder.parentFolder;
                inputManager.processOutput("");
            }
            else if (rootFolder.ifFolderExists(argument)){
                //add password stuff
                FolderSystem newFolder = rootFolder.getSubfolder(argument);
                if (newFolder.hasPassword && !newFolder.solved){
                    Debug.Log("folder has password");
                    selectedFolder = newFolder;
                    inputManager.processOutput("enter folder password > ", "checkPassword");

                }
                else{
                    rootFolder = newFolder;
                    inputManager.processOutput("");
                }
            }
            else{
                inputManager.processOutput("no such directory exists\n");
            }
        }
        else if (command == "help" || command == "cmd"){
            inputManager.processOutput("help: displays this message\nls: displays files\ncd [foldername]: selects a folder\nreadfile [filename]: plays an mp3 file or reads a text file\n");
        }
        else if (command == "readfile"){
            //play the file
            if (rootFolder.ifAudioFileExists(argument)){
                AudioFile currAudioFile = rootFolder.getAudioFile(argument);
                currAudioFile.playAudio();
                if (currAudioFile.containsStr){inputManager.processOutput("metadata detected\nprocessing metadata...\n" + currAudioFile.audioInfo);}
                else{inputManager.processOutput("");}
            }
            else if (rootFolder.ifTextFileExists(argument)){
                TextFile currTextFile = rootFolder.getTextFile(argument);
                inputManager.processOutput(currTextFile.textInfo);
            }
            else{
                inputManager.processOutput("no such file exists\n");
            }
        }
        else{
            //cmd not found
            inputManager.processOutput("command not found\n");
        }
    }
    public void checkPassword(string input){
        if (selectedFolder.password == input){
            //unlock it, output unlocked
            selectedFolder.solved = true;
            rootFolder = selectedFolder;
            inputManager.processOutput("folder unlocked\n");

            //play trigger audio
            if(rootFolder.hasTrigger){
                triggerAudio(rootFolder.triggerAudioName);
            }
        }
        else{
            inputManager.processOutput("wrong password\n");
        }
    }
    public void triggerAudio(string audioName){
        soundManager.playSound(audioName);
    }
}
