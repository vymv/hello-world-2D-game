using UnityEngine;
using System.Collections;

public class GameMenuUI : MonoBehaviour {

	[SerializeField]
	private GameObject FailPanel;
	[SerializeField]
	private GameObject WinPanel;
	// Use this for initialization
	void Start () {
		HideAllPanel();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			OnBackBtnDown();
		}
	}

	private void HideAllPanel()
	{
		WinPanel.SetActive(false);
		FailPanel.SetActive(false);
	}

	public void ShowWinPanel()
	{
		WinPanel.SetActive(true);
		FailPanel.SetActive(false);
	}
	public void ShowFailPanel()
	{
		WinPanel.SetActive(false);
		FailPanel.SetActive(true);
	}

	public void OnBackBtnDown()
	{
		Application.LoadLevel (GameSetting.MainMenuSceneIndex);
		//else code
	}
	public void OnRestartBtnDown()
	{
		Application.LoadLevel(GameSetting.GameSceneIndex);
	}
}
