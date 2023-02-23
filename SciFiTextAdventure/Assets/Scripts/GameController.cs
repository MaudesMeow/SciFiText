using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> ineractionDescriptionInRoom = new List<string>();
    List<string> actionLog = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }


    public void DisplayRoomText()
    {
        UnpackRoom();
        string joinedInteractionDescriptions = string.Join("\n", ineractionDescriptionInRoom.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;
        LogStringWithReturn(combinedText);
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
