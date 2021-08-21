using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;
    public bool IsEnabled = true;

    private Text _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsEnabled)
        {
            _score.text = null;
            return;
        }
        _score.text = $"Score: {ScoreValue}";
    }
}
