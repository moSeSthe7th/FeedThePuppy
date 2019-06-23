using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorButtons : MonoBehaviour
{
    private Text levelText;
    private int levelNumber;
    private string levelNumberStr;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponentInChildren<Text>();
        levelNumberStr = levelText.text;
        int.TryParse(levelNumberStr,out levelNumber);
        
    }

    
    public void LevelSelectorButtonPressed()
    {
        DataScript.currentLevel = levelNumber;
        PlayerPrefs.SetInt("Current Level", DataScript.currentLevel);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
