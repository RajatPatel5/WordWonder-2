using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class Word : MonoBehaviour
{
    public TextMeshProUGUI HeaderText;
    public TextMeshProUGUI Rock_1;
    public TextMeshProUGUI Rock_2;
    public TextMeshProUGUI Rock_3;

    List<List<string>> wordLists = new List<List<string>>();
    List<Transform> cellList = new List<Transform>();
    bool[,] filledCells;
    int gridRows = 11;
    int gridColumns = 15;
    private Button firstClickedButton;
    private Button lastClickedButton;
    private Vector2Int firstClickedIndices;
    private Vector2Int lastClickedIndices;
    public AnimationController Rock1_Animation;
    public AnimationController Rock2_Animation;
    public AnimationController Rock3_Animation;
    List<Transform> GlowCellList = new List<Transform>();
    public GameObject Glow;
    public float Count;
    public Timer Script_Timer;
    public StarAnimation StarAnimation_Script_1;
    public StarAnimation StarAnimation_Script_2;
    public StarAnimation StarAnimation_Script_3;



    void Start()
    {
        
        filledCells = new bool[gridRows, gridColumns];

        wordLists.Add(new List<string>() { "aUDI", "hONDA", "bMW" });
        wordLists.Add(new List<string>() { "aSUS", "hP", "dELL" });
        wordLists.Add(new List<string>() { "jAPAN", "uSA", "uK" });
        wordLists.Add(new List<string>() { "mANGO", "gRAPES", "aPPLE" });
        wordLists.Add(new List<string>() { "rAJKOT", "jAIPUR", "sURAT" });

        int randomIndex = Random.Range(0, wordLists.Count);
        List<string> randomList = wordLists[randomIndex];
        string listName = GetNameByIndex(randomIndex);
        HeaderText.text = listName;
        Rock_1.text = randomList[0];
        Rock_2.text = randomList[1];
        Rock_3.text = randomList[2];

        foreach (Transform child in transform)
        {
            Button button = child.GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(button));
            cellList.Add(child);
        }

        Horizontally(Rock_1.text);
        vertically(Rock_2.text);
        Horizontally(Rock_3.text);
        FillRemainingGrid();
    }

    private void Update()
    {
        if(Count == 3)
        {
            Script_Timer.enabled = false;
            UiManager.instance.OpenPopUp(GamePopUp.Win);
            if(Script_Timer.Time_remaining >= 30 && Script_Timer.Time_remaining <= 59)
            {
                StarAnimation_Script_1.enabled = true;
               
                StarAnimation_Script_2.enabled = true;
               
                StarAnimation_Script_3.enabled = true;
            }
            else if (Script_Timer.Time_remaining >= 15 && Script_Timer.Time_remaining <= 29)
            {
                StarAnimation_Script_1.enabled = true;
              
                StarAnimation_Script_2.enabled = true;
            }
            else
            {
                StarAnimation_Script_1.enabled = true;

            }
        }
    }

    void OnButtonClick(Button button)
    {
        if (firstClickedButton == null)
        {
            firstClickedButton = button;
            firstClickedIndices = GetButtonIndices(button);
        }
        else
        {
            lastClickedButton = button;
            lastClickedIndices = GetButtonIndices(button);

            Debug.Log("First Clicked: " + firstClickedIndices);
            Debug.Log("Last Clicked: " + lastClickedIndices);

            if (firstClickedIndices.y == lastClickedIndices.y)
            {
                int startIndex = Mathf.Min(firstClickedIndices.x, lastClickedIndices.x);
                int endIndex = Mathf.Max(firstClickedIndices.x, lastClickedIndices.x);
                string verticalWord = "";

                for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex++)
                {
                    int cellIndex = rowIndex * gridColumns + firstClickedIndices.y;

                    TextMeshProUGUI cellText = cellList[cellIndex].GetComponentInChildren<TextMeshProUGUI>();
                    verticalWord += cellText.text;

                    // Store the references of buttons between first and last clicked buttons
                    GlowCellList.Add(cellList[cellIndex]);


                    if (verticalWord == Rock_1.text)
                    {
                        Debug.Log(Rock_1.text + " match");
                        Rock1_Animation.BrickAnimation();
                        Onglow();
                        Count++;

                    }
                   else if (verticalWord == Rock_2.text)
                    {
                        Debug.Log(Rock_2.text + " match");
                        Rock2_Animation.BrickAnimation();
                        Onglow();
                        Count++;
                    }
                    else if (verticalWord == Rock_3.text)
                    {
                        Debug.Log(Rock_3.text + " match");
                        Rock3_Animation.BrickAnimation();
                        Onglow();
                        Count++;
                    }
                  
                    
                }
                GlowCellList.Clear();

                Debug.Log("Vertical Word: " + verticalWord);
            }
            else if (firstClickedIndices.x == lastClickedIndices.x)
            {
                int startIndex = Mathf.Min(firstClickedIndices.y, lastClickedIndices.y);
                int endIndex = Mathf.Max(firstClickedIndices.y, lastClickedIndices.y);
                string horizontalWord = "";

                for (int colIndex = startIndex; colIndex <= endIndex; colIndex++)
                {
                    int cellIndex = firstClickedIndices.x * gridColumns + colIndex;
                    TextMeshProUGUI cellText = cellList[cellIndex].GetComponentInChildren<TextMeshProUGUI>();
                    horizontalWord += cellText.text;

                    // Store the references of buttons between first and last clicked buttons
                    GlowCellList.Add(cellList[cellIndex]);

                    if (horizontalWord == Rock_1.text)
                    {
                        Debug.Log(Rock_1.text + " match");
                        Rock1_Animation.BrickAnimation();
                        Onglow();
                        Count++;



                    }
                    else if (horizontalWord == Rock_2.text)
                    {
                        Debug.Log(Rock_2.text + " match");
                        Rock2_Animation.BrickAnimation();
                        Onglow();
                        Count++;

                    }
                    else if (horizontalWord == Rock_3.text)
                    {
                        Debug.Log(Rock_3.text + " match");
                        Rock3_Animation.BrickAnimation();
                        Onglow();
                        Count++;
                    }
                   
                }

                GlowCellList.Clear();

                Debug.Log("Horizontal Word: " + horizontalWord);
            }

            firstClickedButton = null;
            lastClickedButton = null;
        }
    }




    Vector2Int GetButtonIndices(Button button)
    {
        int index = cellList.IndexOf(button.transform);
        int row = index / gridColumns;
        int col = index % gridColumns;
        return new Vector2Int(row, col);
    }

    void Horizontally(string word)
    {
        bool foundValidPosition = false;

        while (!foundValidPosition)
        {
            int rowIndex = Random.Range(0, gridRows);
            int colIndex = Random.Range(0, gridColumns);

            if (colIndex + word.Length <= gridColumns && CheckConsecutiveEmptyCells(rowIndex, colIndex, word.Length))
            {
                foundValidPosition = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!filledCells[rowIndex, colIndex + i])
                    {
                        TextMeshProUGUI cellText = cellList[rowIndex * gridColumns + colIndex + i].GetComponentInChildren<TextMeshProUGUI>();
                        cellText.text = word[i].ToString();
                        filledCells[rowIndex, colIndex + i] = true;
                    }
                    else
                    {
                        foundValidPosition = false;
                        break;
                    }
                }
            }
        }
    }

    void vertically(string word)
    {
        bool foundValidPosition = false;

        while (!foundValidPosition)
        {
            int rowIndex = Random.Range(0, gridRows);
            int colIndex = Random.Range(0, gridColumns);

            if (rowIndex + word.Length <= gridRows && CheckConsecutiveEmptyCells(rowIndex, colIndex, word.Length))
            {
                foundValidPosition = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!filledCells[rowIndex + i, colIndex])
                    {
                        TextMeshProUGUI cellText = cellList[(rowIndex + i) * gridColumns + colIndex].GetComponentInChildren<TextMeshProUGUI>();
                        cellText.text = word[i].ToString();
                        filledCells[rowIndex + i, colIndex] = true;
                    }
                    else
                    {
                        foundValidPosition = false;
                        break;
                    }
                }
            }
        }
    }

    bool CheckConsecutiveEmptyCells(int startRow, int startCol, int length)
    {
        int consecutiveEmptyCount = 0;
        for (int row = startRow; row < gridRows; row++)
        {
            for (int col = startCol; col < gridColumns; col++)
            {
                if (!filledCells[row, col])
                {
                    consecutiveEmptyCount++;
                    if (consecutiveEmptyCount >= length)
                    {
                        return true;
                    }
                }
                else
                {
                    consecutiveEmptyCount = 0;
                }
            }
            startCol = 0;
        }
        return false;
    }

    void FillRemainingGrid()
    {
        for (int row = 0; row < gridRows; row++)
        {
            for (int col = 0; col < gridColumns; col++)
            {
                if (!filledCells[row, col])
                {
                    TextMeshProUGUI cellText = cellList[row * gridColumns + col].GetComponentInChildren<TextMeshProUGUI>();
                    cellText.text = GetRandomLetter();
                    filledCells[row, col] = true;
                }
            }
        }
    }

    string GetRandomLetter()
    {
        char randomChar = (char)Random.Range('A', 'Z');
        return randomChar.ToString();
    }

    string GetNameByIndex(int index)
    {
        switch (index)
        {
            case 0:
                return "Car";
            case 1:
                return "Company";
            case 2:
                return "Country";
            case 3:
                return "Fruit";
            case 4:
                return "City";
            default:
                return "Unknown";
        }
    }

    public void Onglow()
    {
        for (int i = 0; i < GlowCellList.Count; i++)
        {
            GlowCellList[i].GetComponent<Cell>().Enableglow();
        }
    }

}

