using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public List<GameObject> collec = new List<GameObject>();

    public float score = 0;

    public TextMeshProUGUI text;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score + "/ 5";

        if (score == 5 || Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
