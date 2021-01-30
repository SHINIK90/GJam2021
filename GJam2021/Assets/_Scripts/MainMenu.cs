using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;
    public GameObject ControlsPanel;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        ControlsPanel.SetActive(false);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickPlay() {
        click.Play();
        SceneManager.LoadScene(SceneName);
    }
    public void onClickControls() {
        click.Play();
        ControlsPanel.SetActive(true);
    }
    public void onClickExit() {
        click.Play();
    }
    public void onClickExitControls() {
        click.Play();
        ControlsPanel.SetActive(false);
    }
}
