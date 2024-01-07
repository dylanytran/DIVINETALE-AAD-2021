using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject helpMenu;
    public GameObject helpBackButton;
    public GameObject logo;

    public void OnClickPlay() {
        SceneManager.LoadScene("1");
    }

    public void OnClickHelp() {
        mainMenu.SetActive(false);
        logo.SetActive(false);
        helpMenu.SetActive(true);
        helpBackButton.SetActive(true);
    }

    public void OnClickBack() {
        helpMenu.SetActive(false);
        helpBackButton.SetActive(false);
        mainMenu.SetActive(true);
        logo.SetActive(true);
    }
}
