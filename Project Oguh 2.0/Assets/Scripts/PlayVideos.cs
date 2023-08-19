using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideos : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private int videoClipIndex;

    void Awake() 
    {
        videoPlayer = GetComponent<VideoPlayer>();        
    }

    void Start()
    {
        videoPlayer.clip = videoClips[0];
    }

    public void PlayNextVideo()
    {
        videoClipIndex++;
        if (videoClipIndex>= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
    }

        public void PlayPreviousVideo()
    {
        videoClipIndex--;
        if (videoClipIndex>= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
