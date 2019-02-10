using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class VideoBehaviour : MonoBehaviour {

    public RawImage display;
    public AudioSource audioSource;    
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        videoPlayer.loopPointReached += ActivateClose;
    }

    /// <summary>
    /// Busca un video mp4 en el url dado
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public bool AssingVideoIfExists(string path, string extention = ".mp4")
    {
        bool exists = false;
        Debug.Log("video  " + path);
        if (File.Exists(path + extention))
        {
            exists = true;
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = path + extention;
        }
            
        return exists;
    }


    public void Play()
    {
        display.color = Color.black;
        videoPlayer.time = 0;
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        if (!videoPlayer.isPrepared)
            videoPlayer.Prepare();
        display.color = Color.white;
        audioSource.Play();
        display.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    public void ActivateClose(VideoPlayer videoPlayer)
    {
        videoPlayer.time = 0;
    }

    public void Stop()
    {
        videoPlayer.Stop();
        display.color = Color.black;
    }

    public void HideDisplay()
    {
        display.gameObject.SetActive(false);
        Stop();
    }

    public void ShowDisplay()
    {
        display.gameObject.SetActive(true);
    }

}
