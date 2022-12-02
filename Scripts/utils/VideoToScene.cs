using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoToScene : MonoBehaviour
{
    VideoPlayer video;
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += VideoEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void VideoEnd(UnityEngine.Video.VideoPlayer vp)
    {  
        SceneManager.LoadScene(1);
    }
}
