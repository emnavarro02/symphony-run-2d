using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button pause;

    [SerializeField]
    private Button resume;

    [SerializeField]
    private Button mute;

    [SerializeField]
    private Button unMute;

    [SerializeField]
    private GameObject pauseObject;

    [SerializeField]
    private GameObject resumeObject;

    [SerializeField]
    private GameObject muteObject;

    [SerializeField]
    private GameObject unMuteObject;

    // Start is called before the first frame update
    void Start()
    {
        resumeObject.SetActive(false);
        unMuteObject.SetActive(false);
        //pause.onClick.AddListener(() => Pause());
    }

    // Update is called once per frame
    void Update()
    {
        //pause.onClick.AddListener(() => Pause());
    }

    public void Main()
    {
        pause.onClick.AddListener(() => Pause());
        resume.onClick.AddListener(() => Resume());
        mute.onClick.AddListener(() => Mute());
        unMute.onClick.AddListener(() => ActiveSound());

    }

    public void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = 0f;
        pauseObject.SetActive(false);
        resumeObject.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseObject.SetActive(true);
        resumeObject.SetActive(false);
    }

    public void Mute()
    {
        AudioListener.volume = 0;
        muteObject.SetActive(false);
        unMuteObject.SetActive(true);
    }

    public void ActiveSound()
    {
        AudioListener.volume = 1;
        muteObject.SetActive(true);
        unMuteObject.SetActive(false);
    }
}
