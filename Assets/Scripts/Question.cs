using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnswerOption
{
    A, B, C, D
}

[System.Serializable]
public class Question
{
    public Sprite imageQuestion;
    [TextArea] public string textQuestion;
    public string textOptionA;
    public string textOptionB;
    public string textOptionC;
    public string textOptionD;
    public AnswerOption correctOption;
}
