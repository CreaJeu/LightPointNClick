using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : PointNClickable
{
    public bool isOn;
    public string levelToAdd;

    public void LoadLevel ()
    {
        Debug.Log("loading scene...");
        SceneManager.LoadScene(levelToAdd);
    }

	public override AudioSource Interact ()
    {
        if(isOn)
        {
            LoadLevel();
        }
		return null;
    }
}
