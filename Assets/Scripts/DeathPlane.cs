using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThreeDeePlatformerTest.Scripts
{
    public class DeathPlane : MonoBehaviour
    {
        public static List<Vector3> RespawnPositions;

        // Start is called before the first frame update
        void Start()
        {
            RespawnPositions = new List<Vector3> { Component.FindObjectsOfType<Transform>().First(x => x.name == "Player").transform.position };
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 6)
            {

                if (Score.ScoreValue <= 0)
                {
                    GameOverScript.IsGameOver = true;
                }
                else
                {
                    other.gameObject.GetComponentInParent<Transform>().transform.position = RespawnPositions.Last();
                    Score.ScoreValue -= 10;
                }
            }
        }
    }
}