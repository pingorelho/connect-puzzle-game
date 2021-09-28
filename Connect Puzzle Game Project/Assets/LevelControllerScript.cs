using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelControllerScript : MonoBehaviour
{
    public HardLevelScriptableObject LevelPrefab;
    public Level Level;
    public GameObject SquarePrefab;
    public GameObject SourcePrefab;
    public GameObject DestinationPrefab;

    public Color SourceColor1;
    public Color SourceColor2;
    public Color SourceColor3;
    public Color SourceColor4;
    public Color SourceColor5;
    public Color SourceColor6;

    public Color NullColor;

    public float XSpaceBetweenSquares;
    public float YSpaceBetweenSquares;

    public float Xoffset;
    public float Yoffset;

    public Color ActiveColor;

    public int ConnectedPaths = 0;
    public List<Color> CompletedColors;

    // Start is called before the first frame update
    void Start()
    {
        Level = LevelPrefab.Level;
        BuildGrid();
        CreateDisplay();

        ActiveColor = NullColor;
        CompletedColors = new List<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        //On click
        if (Input.GetMouseButtonDown(0))
        {
            //Check to see if clicking a source and if so pick up the color
            SetActiveLightSourceColor();
        }

        //Drop color on release
        if (Input.GetMouseButtonUp(0))
        {
            ActiveColor = NullColor;
        }

        //If holding a color and holding down click
        if (Input.GetMouseButton(0))
        {
            if (ActiveColor != NullColor)
            {
                ChangeSquareColor();
            }
        }
    }

    public void ChangeSquareColor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(mousePos, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                //If its an untouched empty square or destination or the same colored source
                if (hit.collider.GetComponent<SpriteRenderer>().color == SquarePrefab.GetComponent<SpriteRenderer>().color || hit.collider.GetComponent<SpriteRenderer>().color == ActiveColor)
                {
                    if (hit.collider.tag == "empty" || hit.collider.tag == "destination")
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = ActiveColor;

                        if (hit.collider.tag == "destination")
                        {
                            ConnectedPaths++;
                            CompletedColors.Add(ActiveColor);
                            ActiveColor = NullColor;
                        }
                    }
                }
                else //Else drop color
                {
                    ActiveColor = NullColor;
                }
            }
        }
    }

    public bool CheckIfColorIsCompleted(Collider collider)
    {
        foreach (Color color in CompletedColors)
        {
            if (collider.GetComponent<SpriteRenderer>().color == color)
            {
                return true;
            }
        }
        return false;
    }

    public void SetActiveLightSourceColor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(mousePos, Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                //If its a source and it hasnt been connected to a destination yet
                if (hit.collider.tag == "source" && !CheckIfColorIsCompleted(hit.collider))
                {
                    ActiveColor = hit.collider.GetComponent<SpriteRenderer>().color;
                }
            }
        }
    }

    public void CreateDisplay() {

        float xstartingpos, ystartingpos;

        xstartingpos = Xoffset - (Level.Width / 2) * XSpaceBetweenSquares;
        ystartingpos = Yoffset - (Level.Height / 2) * YSpaceBetweenSquares;

        Vector2 newposition = new Vector2(xstartingpos, ystartingpos);

        int sourcesPlacedCounter = 0;

        for (int i = 0; i < Level.Height; i++)
        {
            for (int j = 0; j < Level.Width; j++)
            {
                if (Level.LevelGrid[j, i] == 0)
                {
                    GameObject square = Instantiate(SquarePrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
                    square.transform.SetParent(this.GetComponent<Transform>(), false);

                    square.GetComponent<Transform>().localPosition = new Vector3(newposition.x, newposition.y, 10);
                }
                else if (Level.LevelGrid[j, i] == -1)
                {
                    GameObject square = Instantiate(DestinationPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
                    square.transform.SetParent(this.GetComponent<Transform>(), false);

                    square.GetComponent<Transform>().localPosition = new Vector3(newposition.x, newposition.y, 10);
                }
                else
                {
                    GameObject square = Instantiate(SourcePrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
                    square.transform.SetParent(this.GetComponent<Transform>(), false);

                    square.GetComponent<Transform>().localPosition = new Vector3(newposition.x, newposition.y, 10);

                    switch (sourcesPlacedCounter)
                    {
                        case 0: square.GetComponent<SpriteRenderer>().color = SourceColor1;break;
                        case 1: square.GetComponent<SpriteRenderer>().color = SourceColor2;break;
                        case 2: square.GetComponent<SpriteRenderer>().color = SourceColor3;break;
                        case 3: square.GetComponent<SpriteRenderer>().color = SourceColor4;break;
                        case 4: square.GetComponent<SpriteRenderer>().color = SourceColor5;break;
                        case 5: square.GetComponent<SpriteRenderer>().color = SourceColor6;break;
                        default:
                            break;
                    }
                    sourcesPlacedCounter++;
                }
                newposition.x += XSpaceBetweenSquares;
            }
            newposition.x = xstartingpos;
            newposition.y += YSpaceBetweenSquares;
        }
    }

    public void BuildGrid()
    {
        int Width = LevelPrefab.Level.Width;
        int Height = LevelPrefab.Level.Height;
        //Initialize grid array
        Level.LevelGrid = new int[Width, Height];

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                //Populate grid with 0s
                Level.LevelGrid[i, j] = 0;
            }
        }

        int iteration = 1;
        foreach (Vector2Int position in LevelPrefab.Level.LightSources)
        {
            Level.LevelGrid[position.x, position.y] = iteration;
            iteration++;
        }

        foreach (Vector2Int position in LevelPrefab.Level.Destinations)
        {
            Level.LevelGrid[position.x, position.y] = -1;
        }

    }
}
