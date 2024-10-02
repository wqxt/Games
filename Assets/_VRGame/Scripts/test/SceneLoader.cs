using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start() => SceneManager.LoadScene(4, LoadSceneMode.Additive);
}