using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{

    public float ShakeTime;     //Lenght of time shake lasts
    public float ShakeAmp;      //Cinemachine noise profile parameter
    public float ShakeFreq;     //Cinemachine Noise Profile parameter

    private float ShakeTimeElapsed;

    //Cinemachine shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;


    // Start is called before the first frame update
    void Start()
    {
        //Get virtual camera noise profile
        if (VirtualCamera != null)
        {
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShakeTimeElapsed = ShakeTime;
        }

        //If cinemachine component is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeTimeElapsed > 0)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmp;
                virtualCameraNoise.m_FrequencyGain = ShakeFreq;

                // Update Shake Timer
                ShakeTimeElapsed -= Time.deltaTime;
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeTimeElapsed = 0f;
            }
        }
    }
}
