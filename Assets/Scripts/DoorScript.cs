using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public LevelSettingsEnum LevelLoad;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != 6)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log($"LoadScene {LevelLoad}");
            SceneManager.LoadScene(LevelLoad.ToString(), LoadSceneMode.Single);
        }
    }
}
