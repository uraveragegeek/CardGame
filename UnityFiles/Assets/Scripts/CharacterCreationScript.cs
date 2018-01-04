using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterClass;

public class CharacterCreationScript : MonoBehaviour{ //working on this, need to work on managing player inputs and stuff, and make a character creation menue, or something.

    public NetworkManagerr NMScript;
    public GameObject PlayerCreationModelMale;
    public GameObject PlayerCreationModelFemale;
    private GameObject SpawnedModel;
    public GameObject RenderingSpot;
    public Vector3 Scale;
    public GameObject QuitButton;
    public GameObject PlayButton;
    public GameObject CreateCharacterButton;
    public GameObject MaleCharacterButton;
    public GameObject FemaleCharacterButton;
    public GameObject PlayerSlot1Button;
    public GameObject PlayerSlot2Button;
    public GameObject PlayerSlot3Button;
    public GameObject PlayerSlot4Button;
    public GameObject characterPickBackround;
    public GameObject CCInputField;
    public GameObject EnterNameImage;
    public GameObject SubmitCCButton;
    public GameObject DeleteNotice;
    public Text DeleteResponce;
    public InputField DeleteInputField;
    public InputField CCName;
    public Text PlayerSlotText1;
    public Text PlayerSlotText2;
    public Text PlayerSlotText3;
    public Text PlayerSlotText4;
    public Text Responce;
    public Text CharName;
    string GenderStatus;

    public void Start ()
    {
        NMScript = GameObject.Find("NetworkManager").GetComponent<NetworkManagerr>();
        ChangeButtonTexts();
	}

    public void PlayButtonClicked()
    {
        if (NMScript.PlayerClass.SelectedHero != null)
        {
            NMScript.SendLoadLevelRequest();
        }
        else
        {
            Responce.text = "No hero selected";
        }
    }
    /* sets up the ui for cheating new charector when the button is clicked */
    public void CreatNewChampButtonClicked()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.H1 == null || NMScript.PlayerClass.H2 == null || NMScript.PlayerClass.H3 == null || NMScript.PlayerClass.H4 == null)
            {
                NMScript.PlayerClass.SelectedHero = null;
                Destroy(SpawnedModel);
                CharName.text = null;
                characterPickBackround.SetActive(false);
                CreateCharacterButton.SetActive(false);
                MaleCharacterButton.SetActive(true);
                FemaleCharacterButton.SetActive(true);
                CCInputField.SetActive(true);
                EnterNameImage.SetActive(true);
                SubmitCCButton.SetActive(true);
            }
            else
            {
                Responce.text = "Hero slots full";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* Spawns male model when button is clicked and despawns whatever model was there if any. */
    public void MaleButtonClicked()
    {
        try
        {
            Responce.text = null;
            if (SpawnedModel == null)
            {
                SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                SpawnedModel.transform.localScale = Scale;
                GenderStatus = "Male";
            }
            else
            {
                Destroy(SpawnedModel);
                SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                SpawnedModel.transform.localScale = Scale;
                GenderStatus = "Male";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* Does same thing as male button exept for female */
    public void FemaleButtonClicked()
    {
        try
        {
            Responce.text = null;
            if (SpawnedModel == null)
            {
                SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                SpawnedModel.transform.localScale = Scale;
                GenderStatus = "Female";
            }
            else
            {
                Destroy(SpawnedModel);
                SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                SpawnedModel.transform.localScale = Scale;
                GenderStatus = "Female";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* checks if name field is not empty, if gender is choosen and then sends request to server*/
    public void SubmitButtonClicked()
    {
        try
        {
            Responce.text = null;
            string name = CCName.text;
            if (name != "")
            {
                if (GenderStatus == "Male" || GenderStatus == "Female")
                {
                    if (NMScript.PlayerClass.H1 == null)
                    {
                        NMScript.SendCCRequest(name, GenderStatus, "H1");
                        UnityEngine.Debug.Log("Sending CCRequest for H1");
                    }
                    else if (NMScript.PlayerClass.H2 == null)
                    {
                        NMScript.SendCCRequest(name, GenderStatus, "H2");
                        UnityEngine.Debug.Log("Sending CCRequest for H2");
                    }
                    else if (NMScript.PlayerClass.H3 == null)
                    {
                        NMScript.SendCCRequest(name, GenderStatus, "H3");
                        UnityEngine.Debug.Log("Sending CCRequest for H3");
                    }
                    else if (NMScript.PlayerClass.H4 == null)
                    {
                        NMScript.SendCCRequest(name, GenderStatus, "H4");
                        UnityEngine.Debug.Log("Sending CCRequest for H4");
                    }
                }
                else
                {
                    Responce.text = "Must choose a gender!";
                }
            }
            else
            {
                Responce.text = "Character must have a name!";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* sends request to server */
    public void Character1ButtonClicked()
    {
        NMScript.SendHeroSelectionNotice("H1");
    }
    
    public void Character2ButtonClicked()
    {
        NMScript.SendHeroSelectionNotice("H2");
    }

    public void Character3ButtonClicked()
    {
        NMScript.SendHeroSelectionNotice("H3");
    }

    public void Character4ButtonClicked()
    {
        NMScript.SendHeroSelectionNotice("H4");
    }
    /* handles responce from server and changes name and model accordingly */
    public void Character1ButtonClickedResponceHandler()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.H1 != null)
            {
                if (NMScript.PlayerClass.H1.Gender == "Male")
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H1.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H1.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                }
                else
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H1.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H1.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }

    public void Character2ButtonClickedResponceHandler()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.H2 != null)
            {
                if (NMScript.PlayerClass.H2.Gender == "Male")
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H2.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H2.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                }
                else
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H2.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H2.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }

    public void Character3ButtonClickedResponceHandler()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.H3 != null)
            {
                if (NMScript.PlayerClass.H3.Gender == "Male")
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H3.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H3.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                }
                else
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H3.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H3.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }

    public void Character4ButtonClickedResponceHandler()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.H4 != null)
            {
                if (NMScript.PlayerClass.H4.Gender == "Male")
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H4.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelMale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H4.Name;
                        UnityEngine.Debug.Log("Male model spawned");
                        PlayButton.SetActive(true);
                    }
                }
                else
                {
                    if (SpawnedModel == null)
                    {
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H4.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                    else
                    {
                        Destroy(SpawnedModel);
                        SpawnedModel = Instantiate(PlayerCreationModelFemale, RenderingSpot.transform.position, Quaternion.Euler(0, 0, 0));
                        SpawnedModel.GetComponent<Player_Controller>().enabled = false;
                        SpawnedModel.GetComponentInChildren<Camera>().enabled = false;
                        SpawnedModel.GetComponentInChildren<AudioListener>().enabled = false;
                        SpawnedModel.transform.localScale = Scale;
                        CharName.text = NMScript.PlayerClass.H4.Name;
                        UnityEngine.Debug.Log("Female model spawned");
                        PlayButton.SetActive(true);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* opens another ui to make sure player really wants to delete hero */
    public void DeleteHeroButtonClicked()
    {
        try
        {
            Responce.text = null;
            if (NMScript.PlayerClass.SelectedHero != null)
            {
                Destroy(SpawnedModel);
                DeleteNotice.SetActive(true); 
            }
            else
            {
                Responce.text = "Must have hero selected!";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }

    public void GoBackButtonClicked()
    {
        try
        {
            Responce.text = null;
            DeleteNotice.SetActive(false);
            NMScript.PlayerClass.SelectedHero = null;
            DeleteInputField.text = null;
            CharName.text = null;
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* sends request if player has correctly filled the delete input field and has clicked delete button */
    public void DeleteButtonClicked()
    {
        try
        {
            Responce.text = null;
            if (DeleteInputField.text == NMScript.PlayerClass.SelectedHero.Name)
            {
                if (NMScript.PlayerClass.SelectedHero == NMScript.PlayerClass.H1)
                {
                    UnityEngine.Debug.Log("Sending delete request for H1");
                    NMScript.SendDeleteRequest("H1");
                }
                else if (NMScript.PlayerClass.SelectedHero == NMScript.PlayerClass.H2)
                {
                    UnityEngine.Debug.Log("Sending delete request for H2");
                    NMScript.SendDeleteRequest("H2");
                }
                else if (NMScript.PlayerClass.SelectedHero == NMScript.PlayerClass.H3)
                {
                    UnityEngine.Debug.Log("Sending delete request for H3");
                    NMScript.SendDeleteRequest("H3");
                }
                else if (NMScript.PlayerClass.SelectedHero == NMScript.PlayerClass.H4)
                {
                    UnityEngine.Debug.Log("Sending delete request for H4");
                    NMScript.SendDeleteRequest("H4");
                }
            }
            else
            {
                DeleteResponce.text = "Enter hero name correctly!";
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* Handles create charactor responce from server */
    public void SubmitButtonClickedResponceHandler(string responce)
    {
        try
        {
            Responce.text = null;
            if (responce == "Accepted")
            {
                characterPickBackround.SetActive(true);
                CreateCharacterButton.SetActive(true);
                MaleCharacterButton.SetActive(false);
                FemaleCharacterButton.SetActive(false);
                CCInputField.SetActive(false);
                EnterNameImage.SetActive(false);
                SubmitCCButton.SetActive(false);
                Destroy(SpawnedModel);
                ChangeButtonTexts();
                Responce.text = null;
                CCName.text = null;
            }
            else if (responce == "Declined")
            {
                Responce.text = "Failed to create character";
                characterPickBackround.SetActive(true);
                CreateCharacterButton.SetActive(true);
                MaleCharacterButton.SetActive(false);
                FemaleCharacterButton.SetActive(false);
                CCInputField.SetActive(false);
                EnterNameImage.SetActive(false);
                SubmitCCButton.SetActive(false);
                Destroy(SpawnedModel);
                ChangeButtonTexts();
                Responce.text = null;
                CCName.text = null;
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* handles delete responce form server */
    public void DeleteButtonClickedResponceHandler()
    {
        try
        {
            Responce.text = null;
            DeleteNotice.SetActive(false);
            ChangeButtonTexts();
            CharName.text = null;
            DeleteInputField.text = null;
            NMScript.PlayerClass.SelectedHero = null;
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }
    /* quits */
    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    /* sets charactor slots to there respective names, or clears the slot if player does not have a charactor in the slot */
    public void ChangeButtonTexts()
    {
        try
        {
            if (NMScript.PlayerClass.H1 == null)
            {
                PlayerSlotText1.text = "None";
            }
            else
            {
                PlayerSlotText1.text = NMScript.PlayerClass.H1.Name;
            }
            if (NMScript.PlayerClass.H2 == null)
            {
                PlayerSlotText2.text = "None";
            }
            else
            {
                PlayerSlotText2.text = NMScript.PlayerClass.H2.Name;
            }
            if (NMScript.PlayerClass.H3 == null)
            {
                PlayerSlotText3.text = "None";
            }
            else
            {
                PlayerSlotText3.text = NMScript.PlayerClass.H3.Name;
            }
            if (NMScript.PlayerClass.H4 == null)
            {
                PlayerSlotText4.text = "None";
            }
            else
            {
                PlayerSlotText4.text = NMScript.PlayerClass.H4.Name;
            }
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.Log(e);
            throw;
        }
    }

}
