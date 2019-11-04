using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : PointNClickable
{
    public bool isOn;
    public string levelToAdd;
    public Vector3 nextScenePos;
    public static Vector3 newScenePos;

    public void Awake ()
    {
        newScenePos = nextScenePos;
    }

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
