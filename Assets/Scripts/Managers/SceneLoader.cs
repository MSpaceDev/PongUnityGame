using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	public static SceneLoader instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Load(1);
		}
		else
			Destroy(gameObject);
	}

	public void LoadUnload(int sceneToLoad, int sceneToUnload)
	{
		StartCoroutine(LoadUnloadScene(sceneToLoad, sceneToUnload));
	}

	public void Reset(int sceneToReset)
	{
		StartCoroutine(LoadUnloadScene(sceneToReset, sceneToReset));
	}

	public void Load(int scene)
	{
		StartCoroutine(LoadScene(scene));
	}

	public void Unload(int scene)
	{
		StartCoroutine(UnloadScene(scene));
	}

	private IEnumerator LoadScene(int sceneBuildIndex)
	{
		// Gets scene
		Scene scene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);

		// If scene exists and is not loaded
		if ((scene != null) && (!scene.isLoaded))
		{
			// Loads scene and waits for it to load fully
			AsyncOperation loading = SceneManager.LoadSceneAsync(
				sceneBuildIndex, 
				LoadSceneMode.Additive
			);
			yield return loading;

			// Sets the active scene to the newly loaded scene
			Scene activeScene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
			SceneManager.SetActiveScene(activeScene);
		}
	}

	private IEnumerator UnloadScene(int scene)
	{
		// Waits till end of frame
		yield return null;

		// Unloads scene
		SceneManager.UnloadSceneAsync(scene);
	}

	private IEnumerator LoadUnloadScene(int sceneToLoad, int sceneToUnload)
	{
		// Waits till end of frame
		yield return null;

		// Unloads scene and waits for unload to finish
		var loading = SceneManager.UnloadSceneAsync(sceneToUnload);
		yield return loading;

		// Loads the scene
		Load(sceneToLoad);
	}
}
