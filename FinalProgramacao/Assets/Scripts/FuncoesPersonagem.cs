using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class FuncoesPersonagem : MonoBehaviour
{
    [Header("TEXTOS")]
    public TextMeshProUGUI txtTempo;
    public TextMeshProUGUI txtQtd;
    private bool isTimerActive = true;
    private float tempo = 0;
    private int chaves;

    [Header("GAMEOBJECTS")]
    [SerializeField] GameObject porta;

    [Header("TRILHA SONORA")]
    [SerializeField] public AudioClip trilhaSonora;
    [SerializeField] public AudioClip chavesom;
    [SerializeField] public AudioClip portasom;
    [SerializeField] private AudioSource source;

    [Header("CAMERAS")]
    [SerializeField] private Camera CameraCostas;
    [SerializeField] private Camera Camera1P;

    private Vector3 playerP;
    private Vector3 dragaoP;

    private GameObject dragao;
    private NavMeshAgent dragaoNMA;

    private bool tocouNoDragao;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        dragao = GameObject.FindGameObjectWithTag("dragao");
        dragaoNMA = dragao.GetComponent<NavMeshAgent>();

        playerP = gameObject.transform.position;
        dragaoP = dragao.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (chaves == 3)
        {
            Destroy(porta);
            source.clip = portasom;
            StopTimer();
            source.Play();
        }

        if (isTimerActive)
        {
            tempo += Time.deltaTime;
            txtTempo.text = "Tempo: " + tempo;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            trocadecamera(true);
        }

        if (!Input.GetKeyDown(KeyCode.Z))
        {
            trocadecamera(false);
        }

        if (tocouNoDragao)
        {
            dragaoNMA.enabled = false;
            gameObject.transform.position = playerP;
            dragao.transform.position = dragaoP;
            dragaoNMA.enabled = true;
            tocouNoDragao = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chave")
        {
            source.clip = chavesom;
            source.Play();
            Destroy(collision.gameObject);
            chaves = chaves + 1;
            txtQtd.text = "Chaves encontradas: " + chaves + " de 3";
            Debug.Log(chaves);
        }

        if (collision.gameObject.tag == "dragao")
        {
            tocouNoDragao = true;
        }

        if (collision.gameObject.tag == "Finish")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void trocadecamera(bool ativarCameraCostas)
    {
        if (ativarCameraCostas)
        {
            CameraCostas.depth = 3;
            Camera1P.enabled = false;
        }
        else
        {
            CameraCostas.depth = 0;
            Camera1P.enabled = true;
        }
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

}
