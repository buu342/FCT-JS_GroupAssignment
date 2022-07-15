using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class MultiplayerRoom: MonoBehaviourPunCallbacks{

    
    void Update(){
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2){
             SceneManager.LoadScene("SampleSceneMultiplayer");
        }
    }
 
   

    public void leaveRoom(){
        ButtonPressed();
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("StartMenu");
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
