using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject ConnectButton;
    public GameObject LoginButton;
    public GameObject AddUserButton;
    public GameObject UserNameInput;
    public GameObject PasswordInput;
    public GameObject UserNameLabel;
    public GameObject PasswordLabel;
    public NetworkManagerr NtwkMngr;
    public InputField Username;
    public InputField Password;
    public Text Response;
    private bool LoggedIn;
    
    public void Connected()
    {
        UnityEngine.Debug.Log("Connected.");
        ConnectButton.SetActive(false);
        LoginButton.SetActive(true);
        AddUserButton.SetActive(true);
        PasswordInput.SetActive(true);
        PasswordLabel.SetActive(true);
        UserNameInput.SetActive(true);
        UserNameLabel.SetActive(true);
    } // hides connect button and shows login/add user stuff

    public void ButtomQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }//shuts the game down

    public void ButtonConnect()
    {
        NtwkMngr.Connect();
    } // runs connect from network manager script

    public void ButtonAddUser()
    {
        NtwkMngr.SendAddUserData(Username.text, Password.text);
    }// send request to server when player atempts to create a new user name and password

    public void ButtonLogin()
    {
        NtwkMngr.SendLoginData(Username.text,Password.text);
    }//send a request to the server whena  player attempts to login to the game

    public void ResponseHandler(string response)
    {
        Response.text = response;
    }//used to change the message that the player gets when they do something in the main menue
}
