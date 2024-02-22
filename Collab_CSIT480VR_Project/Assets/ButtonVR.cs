using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonToArchery : MonoBehaviour
{
    public GameObject button;
    public FadeScreen fadeScreen;

    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            StartCoroutine(PlaySoundAndLoadScene());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    IEnumerator PlaySoundAndLoadScene()
    {
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length); // Wait for the duration of the sound clip
    }

    public void GoToScene(int sceneIndex)
    {
        if (!isPressed)
        {
            //onPress.Invoke();
            sound.Play();
            isPressed = true;
            SceneManager.LoadScene(sceneIndex); // Load the scene with the given index
        }
    }


}
