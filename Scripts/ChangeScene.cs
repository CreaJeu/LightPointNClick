using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : PointNClickable
{
    public bool isOn;
    public string levelToAdd;

	private static string currentSceneName;
	private static System.Collections.Generic.Dictionary<string, GameObject>
		loadedScenesRoots = new System.Collections.Generic.Dictionary<string, GameObject>();

	public void Awake()
	{
		GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < roots.Length; i++)
		{
			if (roots [i].activeSelf && roots[i].tag == "Untagged")
			{
				currentSceneName = SceneManager.GetActiveScene().name;
				loadedScenesRoots.Add(currentSceneName, roots[i]);
				return;
			}
		}
		Debug.LogError("ChangeScene error : scene " +
			SceneManager.GetActiveScene().name +" must have " +
			"exactly one !!Untagged!! root GameObject, but none was found.");
	}

    public void LoadLevel ()
    {
		Debug.Log("loading scene "+levelToAdd);
		GameObject tmpRoot;
		loadedScenesRoots.TryGetValue (currentSceneName, out tmpRoot);
		tmpRoot.SetActive (false);
		if (!loadedScenesRoots.ContainsKey (levelToAdd))
		{
			SceneManager.LoadScene (levelToAdd, LoadSceneMode.Additive);
			//new root gameobject not yet accessible here, see Awake()
		}
		else
		{
			currentSceneName = levelToAdd;
			loadedScenesRoots.TryGetValue (currentSceneName, out tmpRoot);
			tmpRoot.SetActive (true);
		}
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
