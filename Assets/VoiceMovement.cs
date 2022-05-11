using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions =
        new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("acelera", acelera);
        actions.Add("retrocede", retrocede);
        actions.Add("derecha", derecha);
        actions.Add("izquierda", izquierda);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();


    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void acelera(){
            transform.Translate(0, 0, 1);
    }

    private void retrocede()
    {
        transform.Translate(0, 0, -1);
    }

    private void derecha()
    {
        transform.Translate(1, 0, 0);
    }

    private void izquierda()
    {
        transform.Translate(-1, 0, 0);
    }
}
