using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField]private Transform Player;
    [SerializeField]Vector3 Origin_Offset;
    float wave;
    [SerializeField]float Bobspeed, waveAmount,lerpTime;
    Vector3 Offset;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0 || y != 0) wave = Mathf.Lerp(wave , Mathf.Sin(Time.time * Bobspeed * player.Speed) * waveAmount , lerpTime);
        else wave = Mathf.Lerp(wave , 0 , lerpTime);
        Offset = new Vector3(Origin_Offset.x, Origin_Offset.y + wave, Origin_Offset.z);
        transform.position = Player.position + Offset;
    }
}
