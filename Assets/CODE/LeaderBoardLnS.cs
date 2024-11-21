using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace LeaderboardCreator
{
    public class LeaderBoardLnS : MonoBehaviour
    {
        [SerializeField] private TMP_Text PersonalText;
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private InputField _usernameInputField;


// ------------------------------------------------------------
        //[SerializeField] private ExampleGame _exampleGame;
        
      
// ------------------------------------------------------------

        private void Start()
        {
            LoadEntries();
            LoadPersonal();
        }
        void LoadPersonal()
        {
            Leaderboards.MergeBall.GetPersonalEntry( entriess=>
            {
                 PersonalText.text=$"{entriess.Rank}. {entriess.Username}\t{entriess.Score} Pt.";
            }
           
            );
        }

        private void LoadEntries()
        {
            
        
            Leaderboards.MergeBall.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username}\t{entries[i].Score} Pt.";
            });
            Debug.Log("LOADED SCOREBOARD");
        }
        
        public void UpEntry(String Name,int Score)
        {
            Leaderboards.MergeBall.UploadNewEntry(Name, Score, isSuccessful =>
            {
                if (isSuccessful)
                {
                    LoadEntries();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                    
            });
           // 
        }
    }
}
