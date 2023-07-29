using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoogleConsole : MonoBehaviour 
{
	private int yes;
	private int no; 
	
	private void Awake()
    {
        PlayGamesPlatform.Activate();
    }

	private void Start () 
	{
		PlayGamesPlatform.DebugLogEnabled = true;
		Social.localUser.Authenticate((bool success) => {
		if (success) print("Logged into the console");
		else print ("Not logged into console");
		});
	}

	public void ShowLeaderboard()
	{
		Social.ShowLeaderboardUI();
	}

	public void ShowAchievement()
	{
		Social.ShowAchievementsUI();
	}

	public void ConsoleSystem ()
	{
		yes = PlayerPrefs.GetInt("yes");
		no = PlayerPrefs.GetInt("no");

		//	-- Achievements
		if (no >= 1) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQAg", 100.0f, (bool success) => {
		});
		}
		if (yes >= 1) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQAQ", 100.0f, (bool success) => {
		});
		}
		if (no >= 100) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQAw", 100.0f, (bool success) => {  
		});
		}
		if (yes >= 25) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQBw", 100.0f, (bool success) => {	        
		});
		}
		if (no >= 1000) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQBA", 100.0f, (bool success) => {     
		});
		}
		if (yes >= 100) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQCA", 100.0f, (bool success) => {
		});
		}
		if (no >= 10000) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQBg", 100.0f, (bool success) => {
		});
		}
		if (yes >= 1000) {
		Social.ReportProgress("CgkI2b6etZ0eEAIQCQ", 100.0f, (bool success) => {   
		});
		}

		// -- LeaderBoard
		Social.ReportScore(yes, "CgkI2b6etZ0eEAIQCg", (bool success) => {
    	});
	}
}
