using UnityEngine;
using UnityEngine.SceneManagement;
using ThreeDeePlatformerTest.Scripts.TempSettings;

namespace ThreeDeePlatformerTest.Scripts
{
    public class DoorScript : MonoBehaviour
    {
        public LevelSettingsEnum LevelLoad;
        public Vector3 NextLevelPlayerVector;

        void LoadSceneByDoorTrigger(Collider other)
        {
            if (other.gameObject.layer != 6)
            {
                return;
            }
            PlayerSettings.PlayerStartPosition = NextLevelPlayerVector;
            Debug.Log($"LoadScene {LevelLoad}");
            SceneManager.LoadSceneAsync(LevelLoad.ToString(), LoadSceneMode.Single);
        }
    }
}