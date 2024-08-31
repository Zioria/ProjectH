using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NCP files Achive")]
public class NPC : ScriptableObject
{
    public Sprite sprite;
    public string name;
    [TextArea(3, 15)]
    public string[] dialogue;
    [TextArea(3, 15)]
    public string[] playerDialogue;
}
