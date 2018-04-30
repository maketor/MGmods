using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {
    public static string musica = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\3DMagicGame\\" + "\\Music\\";
    public enum SeekDir { backward,forward}
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();
    [SerializeField] [HideInInspector] private int currentIndex = 0;

    private FileInfo[] soundFiles;
    private List<string> validExtensions = new List<string> { ".ogg", ".mp3", ".wav" };
    private string absolutePath;



    void Start () {
        if (Application.isEditor) absolutePath = musica;
        if (source == null) source = gameObject.AddComponent<AudioSource>();
        ReloadSound();
	}


    void OnGUI()
    {
        if (GUILayout.Button("Previous"))
        {
            Seek(SeekDir.backward);
            PlayCurrent();
        }
        if (GUILayout.Button("Play current"))
        {
            PlayCurrent();
        }
        if (GUILayout.Button("Next"))
        {
            Seek(SeekDir.forward);
            PlayCurrent();
        }
        if (GUILayout.Button("Reload"))
        {
            ReloadSound();
        }
    }

    void Seek(SeekDir d)
    {
        if (d == SeekDir.forward) currentIndex = (currentIndex + 1) % clips.Count;
        else
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = clips.Count - 1; 
        }
    }

    void PlayCurrent()
    {
        source.clip = clips[currentIndex];
        source.Play();
    }


    void ReloadSound()
    {
        clips.Clear();
        var info = new DirectoryInfo(absolutePath);
        soundFiles = info.GetFiles()
            .Where(f => IsValidFileType(f.Name))
            .ToArray();
        foreach (var s in soundFiles)
        {
            StartCoroutine(LoadFiles(s.FullName));
        }
    }

    IEnumerator LoadFiles(string path)
    {
        WWW www = new WWW(path);
        print("loading " + path);
        AudioClip clip = www.GetAudioClip();

        //while (!clip.isReadyToPlay)
        while(clip.loadState == AudioDataLoadState.Loaded)
            yield return www;

        print("done loading");
        clip.name = Path.GetFileName(path);
        clips.Add(clip);
    }

    bool IsValidFileType(string filename)
    {
        return validExtensions.Contains(Path.GetExtension(filename));
    }
}
