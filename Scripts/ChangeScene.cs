using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : PointNClickable
{
    public bool isOn;
    public string levelToAdd;

	public static string currentSceneName;
	private static System.Collections.Generic.Dictionary<string, GameObject>
		loadedScenesRoots = new System.Collections.Generic.Dictionary<string, GameObject>();

	public void Start()
	{
		GameObject[] roots = gameObject.scene.GetRootGameObjects();
		for (int i = 0; i < roots.Length; i++)
		{
			if (roots [i].activeSelf && roots[i].tag == "Untagged")
			{
				currentSceneName = gameObject.scene.name;
				if(!loadedScenesRoots.ContainsKey(currentSceneName))
				{
					loadedScenesRoots.Add(currentSceneName, roots[i]);
				}
				return;
			}
		}
		Debug.LogError("ChangeScene error : scene " +
			SceneManager.GetActiveScene().name +" must have " +
			"exactly one !!Untagged!! root GameObject, but none was found.");
	}

    public void LoadLevel ()
    {
		//Debug.Log("loading scene "+levelToAdd);
		GameObject tmpRoot;
		loadedScenesRoots.TryGetValue (currentSceneName, out tmpRoot);
		tmpRoot.SetActive (false);
		if (!loadedScenesRoots.ContainsKey (levelToAdd))
		{
			SceneManager.LoadScene (levelToAdd, LoadSceneMode.Additive);
			currentSceneName = levelToAdd;
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
