using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerSoal : MonoBehaviour
{
    [Header("UI Input Username")]
    public GameObject inputUsernameUI;

    [Header("UI Kuis")]
    public GameObject soalUI;
    public RawImage imageSoalUI;
    public TMP_Text textSoalUI;
    public TMP_Text textOpsiA;
    public TMP_Text textOpsiB;
    public TMP_Text textOpsiC;
    public TMP_Text textOpsiD;
    public GameObject popUpJawabanUI;
    public TMP_Text textPopUpHeaderJawaban;
    public TMP_Text textPopUpJawaban;

    [Header("UI Score")]
    public GameObject scoreUI;

    [Header("Debug")]
    public int nomorSoal;
    public int jumlahSoal;
    public int jumlahBenar;
    public float score;

    [Header("Daftar Soal")]
    public List<Soal> daftarSoal = new List<Soal>();

    private void Start()
    {
        inputUsernameUI.SetActive(true);
        soalUI.SetActive(false);
        popUpJawabanUI.SetActive(false);
        scoreUI.SetActive(false);
    }

    private void Update()
    {
        Soal currentSoal = daftarSoal[nomorSoal - 1];
        imageSoalUI.texture = currentSoal.imgSoal.texture;
        textSoalUI.text = currentSoal.textSoal;
        textOpsiA.text = currentSoal.opsiA;
        textOpsiB.text = currentSoal.opsiB;
        textOpsiC.text = currentSoal.opsiC;
        textOpsiD.text = currentSoal.opsiD;
        score = (float)jumlahBenar / (float)jumlahSoal * (float)100;
    }

#region Button Methods

    public void MulaiKuis()
    {
        nomorSoal = 1;
        jumlahSoal = daftarSoal.Count;
        jumlahBenar = 0;

        inputUsernameUI.SetActive(false);
        soalUI.SetActive(true);
        popUpJawabanUI.SetActive(false);
        scoreUI.SetActive(false);
    }

    public void PilihOpsiA()
    {
        CekJawaban(OpsiJawaban.A);
    }

    public void PilihOpsiB()
    {
        CekJawaban(OpsiJawaban.B);
    }

    public void PilihOpsiC()
    {
        CekJawaban(OpsiJawaban.C);
    }

    public void PilihOpsiD()
    {
        CekJawaban(OpsiJawaban.D);
    }

    public void Lanjut()
    {
        if (nomorSoal >= daftarSoal.Count)
        {
            inputUsernameUI.SetActive(false);
            soalUI.SetActive(false);
            scoreUI.SetActive(true);
        }
        else
        {
            nomorSoal++;
        }

        soalUI.SetActive(true);
        popUpJawabanUI.SetActive(false);
    }

#endregion

    private void CekJawaban(OpsiJawaban opsiJawaban)
    {
        // benar
        if(daftarSoal[nomorSoal - 1].opsiJawaban == opsiJawaban)
        {
            Debug.Log("Benar!");
            textPopUpHeaderJawaban.text = "Jawaban Benar!";
            jumlahBenar++;
        }
        // salah
        else
        {
            textPopUpHeaderJawaban.text = "Jawaban Salah!";
            Debug.Log("Salah!");
        }

        switch (daftarSoal[nomorSoal - 1].opsiJawaban)
        {
            case OpsiJawaban.A:
                textPopUpJawaban.text = $"Jawaban yang Benar Adalah\n{daftarSoal[nomorSoal-1].opsiA}";
                break;
            case OpsiJawaban.B:
                textPopUpJawaban.text = $"Jawaban yang Benar Adalah\n{daftarSoal[nomorSoal-1].opsiB}";
                break;
            case OpsiJawaban.C:
                textPopUpJawaban.text = $"Jawaban yang Benar Adalah\n{daftarSoal[nomorSoal-1].opsiC}";
                break;
            case OpsiJawaban.D:
                textPopUpJawaban.text = $"Jawaban yang Benar Adalah\n{daftarSoal[nomorSoal-1].opsiD}";
                break;
        }
        
        // show pop up jawaban
        soalUI.SetActive(false);
        popUpJawabanUI.SetActive(true);
    }
}
