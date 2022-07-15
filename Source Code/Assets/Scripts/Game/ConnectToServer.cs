using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

 public class ConnectToServer : MonoBehaviourPunCallbacks
    {
       
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }


        public override void OnConnectedToMaster(){
            PhotonNetwork.JoinLobby();
        }
    
        public override void OnJoinedLobby() {
           // SceneManager.LoadScene("Lobby");
        }

    public void Singleplayergame(){
        ButtonPressed();
        GameObject.Find("LevelManager").GetComponent<LevelManager>().StartNewGame();
        SceneManager.LoadScene("SampleScene");
    }

    public void Quitgame(){
        ButtonPressed();
        Application.Quit();
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