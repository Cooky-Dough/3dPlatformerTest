using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    private bool _messageSendForTrigger = false;
    private bool _enterDoor = false;
    private bool _isInDoorTrigger = false;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _isInDoorTrigger)
        {
            _enterDoor = Input.GetButtonDown("Jump");
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6)
        {
            return;
        }
        _isInDoorTrigger = true;
    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != 6 || _messageSendForTrigger)
        {
            return;
        }
        if (_enterDoor)
        {
            SendMessageUpwards("LoadSceneByDoorTrigger", other);
            _messageSendForTrigger = true;
        }
    }
    
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        _messageSendForTrigger = false;
        _enterDoor = false;
        _isInDoorTrigger = false;
    }
}
