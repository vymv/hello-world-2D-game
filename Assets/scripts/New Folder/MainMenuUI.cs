using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingPanel;
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private Slider m_slider;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
        m_slider.value = PlayerPrefs.GetFloat("AudioVolume", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnStartBtnDown()
    {
        Application.LoadLevel(GameSetting.GameSceneIndex);
    }
    public void OnEndBtnDown()
    {
        Application.Quit();
    }
    public void OnSettingBtnDown()
    {
        ShowSettingMenu();
    }
    public void OnBackBtnDown()
    {
        PlayerPrefs.Save();
        ShowMainMenu();
    }
    public void OnSliderValueChanged()
    {
        PlayerPrefs.SetFloat("AudioVolume", m_slider.value);
    }

    private void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
    private void ShowSettingMenu()
    {
        MainMenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

}