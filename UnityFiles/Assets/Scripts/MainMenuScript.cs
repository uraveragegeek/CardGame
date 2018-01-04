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
    }

    public void ButtonLogin()
    {
        NtwkMngr.SendLoginData(Username.text,Password.text);
    }

    public void LoginResponseHandler(string response)
    {
        if (response == "Logging in")
        {
            Response.text = response;
            
        }
        else
        if (response == "Password incorect")
        {
            Response.text = response;
        }
        else
        if (response == "Could not get password")
        {
            Response.text = response;
        }
        else
        if (response == "User name does not exist")
        {
            Response.text = response;
        }
        else
        if (response == "YAAAYYY!!! You are the first person to ever use the server!! Sadly you must create an account befor you log in.")
        {
            Response.text = response;
        }
        else
        if (response == "User name or password is blank.")
        {
            Response.text = response;
        }
        else
        if (response == "Player is already Logged in")
        {
            Response.text = response;
        }
    }

    public void AddUserResponseHandler(string response)
    {
        if (response == "Username Created")
        {
            Response.text = response;
        }
        else
        if (response == "Username is already taken")
        {
            Response.text = response;
        }
        else
        if (response == "User name or password is blank.")
        {
            Response.text = response;
        }
    }

    public void LoadingStartAreaResponceHandler(string responce)
    {
        if (responce == "Failed to add")
        {
            Response.text = responce;
        }
    }
}
