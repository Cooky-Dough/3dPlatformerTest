using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public LevelSettingsEnum LevelLoad;

    void OnTriggerStayy(Collider other)
    {
        if (other.gameObject.layer != 6)
        {
            return;
        }
        // if (Input.GetButtonDown("Jump"))
        // {
            Debug.Log($"LoadScene {LevelLoad}");
            SceneManager.LoadSceneAsync(LevelLoad.ToString(), LoadSceneMode.Single);
        // }
    }
}
