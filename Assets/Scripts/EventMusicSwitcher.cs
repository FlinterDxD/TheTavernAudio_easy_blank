using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class EventMusicSwitcher : MonoBehaviour
{
    private EventInstance musicEvent;
    [SerializeField] EventReference musicPath;
    // Start is called before the first frame update
    void Start()
    {
        musicEvent = RuntimeManager.CreateInstance(musicPath);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!musicEvent.isValid())
            {
                musicEvent = RuntimeManager.CreateInstance(musicPath);
                musicEvent.start();
            }
            else
            {
                musicEvent.start();
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicEvent.release();
        }

        switch (true)
        {
            case true when Input.GetKeyDown(KeyCode.Z):
                musicEvent.setParameterByNameWithLabel("orcLayer", "Value A");
                break;
            case true when Input.GetKeyDown(KeyCode.X):
                musicEvent.setParameterByNameWithLabel("orcLayer", "Value B");
                break;
            case true when Input.GetKeyDown(KeyCode.C):
                musicEvent.setParameterByNameWithLabel("orcLayer", "Value C");
                break;
        }
    }
}
