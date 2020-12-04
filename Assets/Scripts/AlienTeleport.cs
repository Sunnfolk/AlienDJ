using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTeleport : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] private float timerTime = 0f;

    public Shader shader;

    [SerializeField] private float TeleportValue = 0f;

    [SerializeField] private GameObject _CharacterStill;
    [SerializeField] private GameObject _CharacterAnimated;

    [SerializeField] private float GlobalTimer = 3f;
    private bool globaltimer = true;

    private bool hasArrived = false;

    private void OnEnable()
    {
        // Reset Values
        _CharacterAnimated.SetActive(false);
        _CharacterStill.SetActive(true);
        TeleportValue = 1f;
       // shader = _CharacterStill.GetComponent<MeshRenderer>().material.shader;

        globaltimer = true;

        timer = Random.Range(1f, timerTime);

        // Run the TeleportIn Function
        StartCoroutine("TeleportIn");
    }

    private void Update()
    {
        Material mat = _CharacterStill.GetComponent<MeshRenderer>().material;
        mat.SetFloat("Vector1_FEFF47F1", TeleportValue);

        if (TeleportValue <= 0f)
        {
            // STOP VFX
            StopCoroutine("TeleportIn");
            _CharacterAnimated.SetActive(true);
            _CharacterStill.SetActive(false);

            print(transform.name + "Has Arrived");
        }

        if (GlobalTimer <= 0 && globaltimer)
        {
            timer = Random.Range(1f, timerTime);

            StartCoroutine("TeleportOut");
            globaltimer = false;
        }

        if (TeleportValue >= 1 && !globaltimer)
        {
            print(transform.name + "Has Left");
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    IEnumerator TeleportIn()
    {
    
        yield return new WaitForSeconds(timer);
        // Add Teleport VFX
        TeleportValue = Mathf.Lerp(TeleportValue, 0f, 1f);
    }

    IEnumerator TeleportOut()
    {
        yield return new WaitForSeconds(timer);
        _CharacterAnimated.SetActive(false);
        _CharacterStill.SetActive(true);
        
        // Add Teleport VFX
        TeleportValue = Mathf.Lerp(TeleportValue, 1f, 1f);
    }
}
