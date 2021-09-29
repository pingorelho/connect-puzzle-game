using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class WorldSceneControllScript : MonoBehaviour
{
    public Animator transition;

    public Database Database;

    public GameObject EasyButton;
    public GameObject MediumButton;
    public GameObject HardButton;

    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;

    public Color EasyColor;
    public Color MediumColor;
    public Color HardColor;

    public Color LockedColor;

    public string SelectedWorld;

    public GameObject MainMenu;
    public GameObject WorldSelectMenu;
    public GameObject LevelSelectMenu;


    // Start is called before the first frame update
    void Start()
    {
        SetUi();

        //This would have to be changed when adding more worlds to the scene and to the database
        if (!Database.EasyWorlds[0].WorldIsCompleted)
        {
            HardButton.GetComponent<Button>().enabled = false;
            HardButton.GetComponent<Image>().color = LockedColor;

            MediumButton.GetComponent<Button>().enabled = false;
            MediumButton.GetComponent<Image>().color = LockedColor;
        }
        else if (!Database.MediumWorlds[0].WorldIsCompleted)
        {
            HardButton.GetComponent<Button>().enabled = false;
            HardButton.GetComponent<Image>().color = LockedColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUi()
    {
        if (CrossSceneController.BackFromLevel)
        {
            SelectWorld(CrossSceneController.CurrentWorld); //should just update the crossscenecontroller directly
            UpdateLevelButtonsDisplay();
            MainMenu.SetActive(false);
            LevelSelectMenu.SetActive(true);
        }
        CrossSceneController.BackFromLevel = false;
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelAnim());
    }

    IEnumerator LoadLevelAnim()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);
    }

    public void SelectWorld(string world)
    {
        SelectedWorld = world;
        CrossSceneController.CurrentWorld = world;
    }

    public void SelectLevel(int level)
    {
        CrossSceneController.CurrentLevel = level;
    }

    //Set the level buttons to locked or available with the correct color from the selected world
    public void UpdateLevelButtonsDisplay()
    {
        switch (SelectedWorld)
        {
            case "easy":
                Level1Button.GetComponent<Image>().color = EasyColor;
                Level2Button.GetComponent<Image>().color = EasyColor;
                Level3Button.GetComponent<Image>().color = EasyColor;

                if (!Database.EasyWorlds[0].WorldLevels[0].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;

                    Level2Button.GetComponent<Button>().enabled = false;
                    Level2Button.GetComponent<Image>().color = LockedColor;
                }
                else if (!Database.EasyWorlds[0].WorldLevels[1].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;
                }
                break;
            case "medium":
                Level1Button.GetComponent<Image>().color = MediumColor;
                Level2Button.GetComponent<Image>().color = MediumColor;
                Level3Button.GetComponent<Image>().color = MediumColor;

                if (!Database.MediumWorlds[0].WorldLevels[0].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;

                    Level2Button.GetComponent<Button>().enabled = false;
                    Level2Button.GetComponent<Image>().color = LockedColor;
                }
                else if (!Database.MediumWorlds[0].WorldLevels[1].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;
                }
                break;
            case "hard":
                Level1Button.GetComponent<Image>().color = HardColor;
                Level2Button.GetComponent<Image>().color = HardColor;
                Level3Button.GetComponent<Image>().color = HardColor;

                if (!Database.HardWorlds[0].WorldLevels[0].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;

                    Level2Button.GetComponent<Button>().enabled = false;
                    Level2Button.GetComponent<Image>().color = LockedColor;
                }
                else if (!Database.HardWorlds[0].WorldLevels[1].LevelIsCompleted)
                {
                    Level3Button.GetComponent<Button>().enabled = false;
                    Level3Button.GetComponent<Image>().color = LockedColor;
                }
                break;
            default:
                break;
        }
    }
}
