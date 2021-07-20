using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThreeDeePlatformerTest.Scripts
{
    public class Checkpoint : MonoBehaviour
    {
        public Material FlagActive;

        public Material FlagInActive;
        Renderer _flagPole;
        Renderer _flag;

        void Start()
        {
            _flagPole = GetComponent<Renderer>();
            _flag = _flagPole.GetComponentsInChildren<Renderer>().FirstOrDefault(x => x.name == "Flag");
            _flag.material = FlagInActive;
        }
        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.layer == 6)
            {
                _flag.material = FlagActive;
                DeathPlane.RespawnPositions.Add(_flag.transform.position);
            }
        }
    }
}