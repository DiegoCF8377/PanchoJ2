using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
/// <summary>
/// This class inherits from TargetObject and represents a PickupObject.
/// </summary>
public class PickupFinalObject : TargetObject
{
    static public bool isFinal = false; 
    
    [Header("PickupObject")]

    [Tooltip("New Gameobject (a VFX for example) to spawn when you trigger this PickupObject")]
    public GameObject spawnPrefabOnPickup;

    [Tooltip("Gameobject that indicates the end and obscures the screen")]
    public GameObject finalScreen;

    [Tooltip("Destroy the spawned spawnPrefabOnPickup gameobject after this delay time. Time is in seconds.")]
    public float destroySpawnPrefabDelay = 10;
    
    [Tooltip("Destroy this gameobject after collectDuration seconds")]
    public float collectDuration = 0f;

    [Tooltip("The name of the main menu scene")]
    public string sceneName;

    public TextMeshProUGUI recordsText;
    TimeManager m_TimeManager;

    void Start() {
        Register();
        m_TimeManager = FindObjectOfType<TimeManager>();
    }

    void OnCollect()
    {
        if (CollectSound)
        {
            AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        if (spawnPrefabOnPickup)
        {
            var vfx = Instantiate(spawnPrefabOnPickup, CollectVFXSpawnPoint.position, Quaternion.identity);
            Destroy(vfx, destroySpawnPrefabDelay);
        }
               
        Objective.OnUnregisterPickup(this);
        int timeRemaining = (int)Math.Ceiling(m_TimeManager.TimeRemaining);
        recordsText.text += string.Format("\n{0}:{1:00}", timeRemaining / 60, timeRemaining % 60);
        finalScreen.SetActive(true);
        isFinal = true;
        StartCoroutine(Wait());


    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(FinalScreen.tiempoPantalla);
        Destroy(gameObject, collectDuration);
        SceneManager.LoadSceneAsync(sceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
        {
            OnCollect();
        }
    }
}
