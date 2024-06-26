using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class VirtualSpaceSpawner : MonoBehaviour
{
    private static bool sceneLoaded = false;
    public GameObject insideEnvironment;

    private GameObject outsideEnvironment;
    // Start is called before the first frame update
    void Start()
    {
        if (!sceneLoaded)
        {
            sceneLoaded = true;
            StartCoroutine(LoadEnvironmentScene());
        }

        if(insideEnvironment != null)
            PlacePrefab(insideEnvironment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlacePrefab(GameObject prefabToPlace)
    {
        Vector3 thisPosition = transform.position;
        thisPosition.y = 0.0f;
        thisPosition.y += prefabToPlace.transform.position.y;
        Quaternion thisRotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        Instantiate(prefabToPlace, thisPosition, thisRotation);
    }

    private void RepositionGameObject(GameObject gameObjectToTransform)
    {
        Vector3 thisPosition = transform.position;
        thisPosition.y = 0.0f;
        thisPosition.y += gameObjectToTransform.transform.position.y;
        Quaternion thisRotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        gameObjectToTransform.transform.position = thisPosition;
        gameObjectToTransform.transform.rotation = thisRotation;
    }

    IEnumerator LoadEnvironmentScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        
        // Warte, bis das Laden abgeschlossen ist
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Scene loadedScene = SceneManager.GetSceneByBuildIndex(1);
        GameObject[] rootObjects = loadedScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            if (obj.CompareTag("Environment"))
            {
                Debug.Log("Hey Umgebung gefunden");
                outsideEnvironment = obj;
                RepositionGameObject(outsideEnvironment);
                break;
            }
        }
    }
}
