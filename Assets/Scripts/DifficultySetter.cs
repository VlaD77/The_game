using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DifficultySetter : MonoBehaviour 
{
	public void SetNoob()
	{
		AI.difficultyLevel = Difficulty.Noob;
		LoadGameplay();
	}
    
	public void SetSkilled()
	{
		AI.difficultyLevel = Difficulty.Skilled;
		LoadGameplay();
	}

	public void SetNotWinning()
	{
		AI.difficultyLevel = Difficulty.NotWinning;
		LoadGameplay();
	}

	private void LoadGameplay()
	{
		SoundManager.instance.PlayRandomButtonClickSFX();
		SceneManager.LoadScene("Game");
	}
}
