using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSong : MonoBehaviour
{
    [SerializeField]
    private Song songCategory;

    public bool snapped;

    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (songCategory)
        {
            case Song.chill:
                break;
            case Song.calm:
                break;
            case Song.energetic:
                break;
            case Song.aggressive:
                break;
        }
        

    }

    public void SongSelect()
    {
        switch (songCategory)
        {
            case Song.chill:
                CurrentSong.songPlaying = 0;
                break;
            case Song.calm:
                CurrentSong.songPlaying = 1;
                break;
            case Song.energetic:
                CurrentSong.songPlaying = 2;
                break;
            case Song.aggressive:
                CurrentSong.songPlaying = 3;
                break;
        }


    }

    

}
