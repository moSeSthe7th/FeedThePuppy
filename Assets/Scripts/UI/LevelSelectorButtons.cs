using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorButtons : MonoBehaviour
{
    private Text levelText;
    private int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponentInChildren<Text>();
        levelNumber = int.Parse(levelText.text);
    }

    
    public void LevelSelectorButtonPressed()
    {
        DataScript.currentLevel = levelNumber;
        PlayerPrefs.SetInt("Current Level", DataScript.currentLevel);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
