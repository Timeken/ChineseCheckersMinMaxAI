using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject NewGamePanel;
    [SerializeField]
    private GameObject MainMenuCanvas;
    [SerializeField]
    private GameObject InGameCanvas;
    [SerializeField]
    private GameObject OptionsPanel;
    [SerializeField]
    private GameObject GameOverText;

    private SetupScript setupScript;
    private GameSettingsScript settingsScript;
    private SaveLoadGameScript saveLoad;
    private void Start()
    {
        settingsScript = camera.GetComponent<GameSettingsScript>();
        setupScript = camera.GetComponent<SetupScript>();
        saveLoad = camera.GetComponent<SaveLoadGameScript>();
    }

    public void NewGame()
    {     
        MainMenuPanel.gameObject.SetActive(false);
        NewGamePanel.gameObject.SetActive(true);
    }
    
    public void SaveGame()
    {
        saveLoad.SaveFile();
    }

    public void LoadGame()
    {
        saveLoad.LoadFile();       
        OptionsPanel.gameObject.SetActive(false);
        InGameCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
    }
    public void GameOver(string turn)
    {
        GameOverText.GetComponent<Text>().text = turn + " wins!";
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenuBack()
    {
        MainMenuPanel.gameObject.SetActive(true);
        NewGamePanel.gameObject.SetActive(false);
    }

    public void InGameOptions()
    {
        OptionsPanel.gameObject.SetActive(true);
    }

    public void Resume()
    {
        OptionsPanel.gameObject.SetActive(false);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void TwoPlayer()
    {
        settingsScript.NumbersOfPlayers = NumbersOfPlayers.twoPlayers;
        setupScript.Setup(settingsScript.NumbersOfPlayers);
        InGameCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void ThreePlayer()
    {
        settingsScript.NumbersOfPlayers = NumbersOfPlayers.threePlayers;
        setupScript.Setup(settingsScript.NumbersOfPlayers);
        InGameCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void FourPlayer()
    {
        settingsScript.NumbersOfPlayers = NumbersOfPlayers.forePlayers;
        setupScript.Setup(settingsScript.NumbersOfPlayers);
        InGameCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void SixPlayer()
    {
        settingsScript.NumbersOfPlayers = NumbersOfPlayers.sixPlayers;
        setupScript.Setup(settingsScript.NumbersOfPlayers);
        InGameCanvas.gameObject.SetActive(true);
        MainMenuCanvas.gameObject.SetActive(false);
    }
}
