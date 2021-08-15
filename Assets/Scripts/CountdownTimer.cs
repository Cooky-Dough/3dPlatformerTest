using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ThreeDeePlatformerTest.Scripts
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float _timeLimit = 120f;

        private Text _timer;

        // Start is called before the first frame update
        void Start()
        {
            _timer = GetComponent<Text>();
            _currentTime = _timeLimit;
        }

        // Update is called once per frame
        void Update()
        {

            if (_currentTime <= 0f)
            {
                GameOverScript.IsGameOver = true;
            }
            else
            {
                _currentTime -= 1 * Time.deltaTime;
                _timer.text = string.Format("{0:N1}" ,_currentTime);
            }
        }
    }
}