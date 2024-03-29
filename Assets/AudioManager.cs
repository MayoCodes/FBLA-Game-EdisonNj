using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Header("Area")]
    [SerializeField] private MusicArea area;
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxBus;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;

    private EventInstance ambienceEventInstance;
    private EventInstance musicEventInstance;

    public GameObject mControl;
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
    
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void Start()
    {
        InitializeMusic(FMODEvents.instance.music);
    }

    public void SetBGMusic(MusicArea area)
    {
        //musicEventInstance.setParameterByName("bgmusicarea", (float) area);
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    private void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop all of the event emitters, because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    public void DetectAndHandleColor(Color targetColor)
    {
        // Get the renderer component of the object
        Renderer renderer = mControl.GetComponent<Renderer>();

        // Ensure renderer is not null and it has a material
        if (renderer != null && renderer.material != null)
        {
            // Get the color of the material
            Color objectColor = renderer.material.color;

            // Check if the color matches the target color
            if (objectColor == targetColor)
            {
                musicEventInstance.setParameterByName("bgmusicarea", 1f);
            }
        }
    }

    void Update()
    {
        DetectAndHandleColor(Color.green);

        if (mControl != null)
        {
            // Get the renderer component of the object
            Renderer renderer = mControl.GetComponent<Renderer>();

            // Ensure renderer is not null and it has a material
            if (renderer != null && renderer.material != null)
            {
                // Get the color of the material
                Color objectColor = renderer.material.color;

                // Check if the color is red
                if (objectColor == Color.red)
                {

                    musicEventInstance.setParameterByName("bgmusicarea", 2f);
                }
            }

        }

    }

    private void OnDestroy()
    {
        CleanUp();
    }

}
