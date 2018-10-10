using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnTriggerEnter2DEvent : MonoBehaviour {

    public delegate void TriggerEnter2DEvent(Collider2D collision);
    public event TriggerEnter2DEvent OnEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnEvent != null) OnEvent(collision);
        Debug.Log("OnTriggerEnter2DEvent:Triggered by: " + collision.name);

    }
}
