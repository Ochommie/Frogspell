using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        var lastSceneIndex = SceneManager.sceneCount - 1;
        var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
        SceneManager.UnloadSceneAsync(lastLoadedScene);
        var barrier = GameObject.FindGameObjectWithTag("Barrier");
        GameObject.DestroyImmediate(barrier);
        var guard = GameObject.FindGameObjectWithTag("Guard");
        guard.GetComponent<GuardController>().hasPassed = true;
    }

   void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;

   
    }

    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }

           
        }

    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {

            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }

    }
}
