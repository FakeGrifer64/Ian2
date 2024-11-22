using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoController : MonoBehaviour
{
    public Text dialogueText;
    public Text yesOption;
    public Text noOption;
    public GameObject[] dialogueOptions;
    public string[] dialogueLines;
    private int currentLine = 0;

   
    void Start()
    {
        dialogueLines = new string[]
        {
            // Linhas de introdu��o
            "Ol�, eu sou a Esfinge", // Linha 0
            "voc� ir� passar pelo meu labirinto, independente de suas respostas", // Linha 1
            "mas ainda assim", // Linha 2
            "quero te testar.", // Linha 3
            "Vou te perguntar tr�s engimas,", // Linha 4
            "responda com calma.", // Linha 5
            "Para terminar nosso encontro", // Linha 6
            "voc� ter� de encontrar tr�s chaves pelo labirinto para sair", // Linha 7
            "Voc� est� pronto?", // Linha 8
            "Vamos come�ar.", // Linha 9

            // Primeiro
            "O que � que est� sempre na sua frente, mas n�o pode ser visto?", // Linha 10

            // Primeiro acerto
            "Parab�ns.", // Linha 11

            // Primeiro Errado
            "Errado.", // Linha 12

            // Continua��o
            "Vamos continuar", // Linha 13
            "O que pode ser quebrada, mas nunca segurada?", // Linha 14

            // Segundo acerto
            "Isso.", // Linha 15

            // Segundo Errado
            "Que pena.", // Linha 16

            // Continua��o 2
            "Proseguindo.", // Linha 17
            "Se h� tr�s, voc� tem tr�s. Se h� duas, voc� tem duas. Mas se h� uma, voc� n�o tem nenhuma. O que �?", // Linha 18

            // terceiro acerto
            "Muito bem.", // Linha 19

            // terceiro Errado
            "N�o.", // Linha 20
      
            // Linhas finais
            "Esperarei voc� no labirinto.", // Linha 21
            "Obrigado por ouvir.", // Linha 22
            "Boa sorte.", // Linha 23
        };

        ShowDialogueLine();
        dialogueOptions[1].SetActive(false);
        
    }

    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            ShowOptions();
        }
        else
        {
            EndDialogue();
        }
    }



    void ShowOptions()
    {
        dialogueOptions[0].SetActive(true);

        switch (currentLine)
        {
            case 0: // Introdu��o inicial
            case 9: // In�cio do jogo
                yesOption.text = "Sim";
                break;

            case 10:
                yesOption.text = "O futuro";
                noOption.text = "O vento";
                dialogueOptions[1].SetActive(true);
                break;

            case 11:
                yesOption.text = "Obrigado";
                dialogueOptions[1].SetActive(false);
                break;

            case 12:
                yesOption.text = "Droga";
                dialogueOptions[1].SetActive(false);
                break;

            case 13:
                yesOption.text = "Continue";
                dialogueOptions[1].SetActive(false);
                break;

            case 14:
                yesOption.text = "O sil�ncio";
                noOption.text = "A confian�a";
                dialogueOptions[1].SetActive(true);
                break;

            case 15:
                yesOption.text = "Isso!";
                dialogueOptions[1].SetActive(false);
                break;

            case 16:
                yesOption.text = "Caramba";
                dialogueOptions[1].SetActive(false);
                break;

            case 17:
                yesOption.text = "Pr�ximo";
                dialogueOptions[1].SetActive(false);
                break;

            case 18:
                yesOption.text = "Op��es";
                noOption.text = "Luvas";
                dialogueOptions[1].SetActive(true);
                break;

            case 19:
                yesOption.text = "Que bom!";
                dialogueOptions[1].SetActive(false);
                break;

            case 20:
                yesOption.text = "Chato";
                dialogueOptions[1].SetActive(false);
                break;

            case 21:
                yesOption.text = "At�";
                dialogueOptions[1].SetActive(false);
                break;

            case 22:
                yesOption.text = "Ok";
                dialogueOptions[1].SetActive(false);
                break;

            case 23:
                yesOption.text = "Agrade�o";
                dialogueOptions[1].SetActive(false);
                break;

            default:
                yesOption.text = "Sim";
                noOption.text = "N�o";
                currentLine++;
                break;
        }
    }

    void EndDialogue()
    {
        dialogueText.text = "O di�logo terminou.";

        yesOption.text = "Vamos para o labirinto";
        dialogueOptions[1].SetActive(false);

        dialogueOptions[0].SetActive(true);
    }

    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0:
                HandleYesOption();
                break;
            case 1:
                HandleNoOption();
                break;
        }

        ShowDialogueLine();
    }

    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 10:
                currentLine++;
                break;
            case 11:
                currentLine = 13;
                break;
            case 12:
                currentLine++;
                break;
            case 13:
                currentLine++;
                break;
            case 14:
                currentLine = 16;
                break;
            case 15:
                currentLine = 17;
                break;
            case 16:
                currentLine++;
                break;
            case 17:
                currentLine++;
                break;
            case 18:
                currentLine++;
                break;
            case 19:
                currentLine = 21;
                break;
            case 20:
                currentLine++;
                break;
            case 21:
                currentLine++;
                break;
            case 22:
                currentLine++;
                break;
            case 23:
                SceneManager.LoadScene("SampleScene");  
                break;

            default:
                currentLine++;
                break;
        }
    }

    void HandleNoOption()
    {
        switch (currentLine)
        {
            case 10:
                currentLine = 12;
                break;
            case 11:
                currentLine++;
                break;
            case 12:
                currentLine++;
                break;
            case 13:
                currentLine++;
                break;
            case 14:
                currentLine++;
                break;
            case 15:
                currentLine = 17;
                break;
            case 16:
                currentLine++;
                break;
            case 17:
                currentLine++;
                break;
            case 18:
                currentLine = 20;
                break;
            case 19:
                currentLine++;
                break;
            case 20:
                currentLine++;
                break;
            case 21:
                currentLine++;
                break;
            case 22:
                currentLine++;
                break;
            case 23:
                currentLine++;
                break;

            default:
                currentLine++;
                break;
        }
    }
 


}
