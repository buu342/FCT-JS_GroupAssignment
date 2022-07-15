using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class JoinMultiplayer: MonoBehaviourPunCallbacks{
public TMP_InputField createInput;
public TMP_InputField JoinInput;    
public static bool RoomCreator=false;
public static bool Multiplayer=false;
    public void createRoom(){
        ButtonPressed();
        PhotonNetwork.CreateRoom(createInput.text);
        RoomCreator=true;
        Multiplayer=true;
    }

    public void JoinRoom(){
        ButtonPressed();
        PhotonNetwork.JoinRoom(JoinInput.text);
        Multiplayer=true;
    }

    
   
 
    public override void OnJoinedRoom(){
        ButtonPressed();
        SceneManager.LoadScene("WaitingRoom");
    }

   
    public void LeaveLobby(){
        ButtonPressed();
        PhotonNetwork.LeaveLobby();
        Multiplayer=false;
    }

    public bool RoomOwner(){
        return RoomCreator;
    }


    /*==============================
        ButtonPressed
        Plays a sound when the menu button is pressed
    ==============================*/
    
    public void ButtonPressed()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Gameplay/Menu_Select");
    }


    /*==============================
        ButtonHighlighted
        Plays a sound when the menu button is highlighted
    ==============================*/
    
    public void ButtonHighlighted()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Gameplay/Menu_Highlight");
    }
}
