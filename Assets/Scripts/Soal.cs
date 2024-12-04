using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OpsiJawaban
{
    A, B, C, D
}

[System.Serializable]
public class Soal
{
    public Sprite imgSoal;
    [TextArea] public string textSoal;
    public string opsiA;
    public string opsiB;
    public string opsiC;
    public string opsiD;
    public OpsiJawaban opsiJawaban;
}
