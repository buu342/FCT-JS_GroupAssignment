/****************************************************************
                         SceneDirector.cs
    
A script which handles the scene.
****************************************************************/

using UnityEngine;

public class SceneDirectorMultiplayer : MonoBehaviour
{
    enum MusicType
    {
        None,
        Calm,
        Tense,
        LessCalm
    }
    
    private MonsterAI m_Monster = null;
    private MusicManager m_Music = null;
    private MusicType m_MusicType = MusicType.None;
    private float m_CurrentSkyboxRotation = 0.0f;
    
    /*==============================
        Start
        Called when the scene director is initialized
    ==============================*/
    
    void Start()
    {
        this.GetComponent<ProcGennerMultiplayer>().GenerateScene();
        this.m_Music = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        this.m_Music.StopMusic();
        this.m_Music.PlaySong("Music/Calm", true, true);
        this.m_MusicType = MusicType.Calm;
    }
    
    void Update()
    {
        this.m_CurrentSkyboxRotation += 0.01f*Time.timeScale;
        RenderSettings.skybox.SetFloat("_Rotation", this.m_CurrentSkyboxRotation);
    }
   
    void FixedUpdate()
    {
        if (this.m_Monster != null)
        {
            if (this.m_Monster.monsterState == MonsterAI.MonsterState.ChasingPlayer && !this.GetMusicTense())
                this.SetMusicTense(true);
            else if (this.m_Monster.monsterState == MonsterAI.MonsterState.Patrolling && this.GetMusicTense())
                this.SetMusicTense(false);
        }
    }
    
    /*==============================
        SetMonster
        Checks if the music is tense
        @return Checks whether the music is tense or not
    ==============================*/
    
    public void SetMonster(GameObject monster)
    {
        if (monster != null)
            this.m_Monster = monster.GetComponent<MonsterAI>();
        else
            this.m_Monster = null;
    }

    /*==============================
        GetMusicTense
        Checks if the music is tense
        @return Checks whether the music is tense or not
    ==============================*/
    
    public bool GetMusicTense()
    {
        return (this.m_MusicType == MusicType.Tense);
    }
    

    /*==============================
        SetMusicTense
        Sets the music to be tense
        @param Whether to set the music to be tense or not
    ==============================*/
    
    public void SetMusicTense(bool enable)
    {
        if (enable)
        {
            this.m_Music.PlaySong("Music/Tense", true, true, true);
            this.m_MusicType = MusicType.Tense;
        }
       else if (!enable && this.m_MusicType != MusicType.LessCalm)
        {
            this.m_Music.PlaySong("Music/LessCalm", true, true, true);
            this.m_MusicType = MusicType.LessCalm;
        }
    }
}