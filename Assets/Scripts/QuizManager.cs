using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("UI Name Input")]
    public GameObject nameInputUI;
    public TMP_InputField inputFieldName;

    [Header("UI Quiz")]
    public GameObject quizUI;
    public RawImage questionImage;
    public TMP_Text questionText;
    public TMP_Text optionAText;
    public TMP_Text optionBText;
    public TMP_Text optionCText;
    public TMP_Text optionDText;

    [Header("UI Correction")]
    public GameObject correctionUI;
    public TMP_Text correctionHeaderText;
    public TMP_Text correctAnswerText;

    [Header("UI Leadboard")]
    public GameObject leaderboardUI;

    [Header("Debug")]
    public string username;
    public int currentQuestion;
    public int numberOfQuestion;
    public int numberOfCorrect;
    public float score;

    [Header("Question List")]
    public List<Question> questions = new List<Question>();

    private void Start()
    {
        nameInputUI.SetActive(true);
        quizUI.SetActive(false);
        correctionUI.SetActive(false);
        leaderboardUI.SetActive(false);
    }

#region Button Methods

    public void StartQuiz()
    {
        username = inputFieldName.text;
        currentQuestion = 0;
        numberOfQuestion = questions.Count;
        numberOfCorrect = 0;
        UpdateQuestion();

        nameInputUI.SetActive(false);
        quizUI.SetActive(true);
        correctionUI.SetActive(false);
        leaderboardUI.SetActive(false);
    }

    public void SelectOptionA()
    {
        CheckAnswer(AnswerOption.A);
    }

    public void SelectOptionB()
    {
        CheckAnswer(AnswerOption.B);
    }

    public void SelectOptionC()
    {
        CheckAnswer(AnswerOption.C);
    }

    public void SelectOptionD()
    {
        CheckAnswer(AnswerOption.D);
    }

    public void NextQuestion()
    {
        currentQuestion++;

        if (currentQuestion >= questions.Count)
        {
            nameInputUI.SetActive(false);
            quizUI.SetActive(false);
            correctionUI.SetActive(false);
            leaderboardUI.SetActive(true);
        }
        else
        {
            UpdateQuestion();
            quizUI.SetActive(true);
            correctionUI.SetActive(false);
        }
    }

    // move to main menu scene
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

#endregion

    private void UpdateQuestion()
    {
        // set as current question
        Question question = questions[currentQuestion];

        if(question.imageQuestion != null)
        {
            questionImage.gameObject.SetActive(true);
            questionImage.texture = question.imageQuestion.texture;
        }
        else
        {
            questionImage.gameObject.SetActive(false);
        }

        questionText.text = question.textQuestion;

        optionAText.text = question.textOptionA;
        optionBText.text = question.textOptionB;
        optionCText.text = question.textOptionC;
        optionDText.text = question.textOptionD;
    }

    private void CheckAnswer(AnswerOption option)
    {
        // right answer
        if(questions[currentQuestion].correctOption == option)
        {
            Debug.Log("Correct!");
            correctionHeaderText.text = "Correct!";
            numberOfCorrect++;
        }
        // wrong answer
        else
        {
            correctionHeaderText.text = "Wrong!";
            Debug.Log("Wrong!");
        }

        score = (float)numberOfCorrect / (float)numberOfQuestion * (float)100;
        Debug.Log($"Current Score: {score}");

        // show correction UI
        switch (questions[currentQuestion].correctOption)
        {
            case AnswerOption.A:
                correctAnswerText.text = $"The right answer is\n[{questions[currentQuestion].textOptionA}]";
                break;
            case AnswerOption.B:
                correctAnswerText.text = $"The right answer is\n[{questions[currentQuestion].textOptionB}]";
                break;
            case AnswerOption.C:
                correctAnswerText.text = $"The right answer is\n[{questions[currentQuestion].textOptionC}]";
                break;
            case AnswerOption.D:
                correctAnswerText.text = $"The right answer is\n[{questions[currentQuestion].textOptionD}]";
                break;
        }
        quizUI.SetActive(false);
        correctionUI.SetActive(true);
    }
}
