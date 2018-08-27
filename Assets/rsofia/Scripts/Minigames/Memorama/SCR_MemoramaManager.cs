using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Minijuegos
{
    public class SCR_MemoramaManager : SCR_MinigameManager
    {

        public GameObject cartaPrefab;
        
        private SCR_MemoramaCard[] cartas;
        private List<SCR_MemoramaCard> currentTurnedCards = new List<SCR_MemoramaCard>();
        public static bool isGameOn = false;


        private int scorePerPair = 10;
        bool[,] gridCartas;
        int fila, columna;

        private void Start()
        {
            nivelDificultad = SCR_CreateMinigamWith.nivelDificultadGlobal;
            categoria = SCR_CreateMinigamWith.categoriaGlobal;

            cartas = FindObjectsOfType<SCR_MemoramaCard>();
            minigame = GetComponent<SCR_Minigame>();

            CreateProceduralLevel();
            SetMaxPossibleScore();
            UpdateScore();

        }

        #region CARD DISPLAY
        public void AddACard(SCR_MemoramaCard _card)
        {
            currentTurnedCards.Add(_card);
            if (currentTurnedCards.Count > 2)
            {
                SCR_MemoramaCard firstCard = currentTurnedCards[0];
                currentTurnedCards.Remove(currentTurnedCards[0]);
                firstCard.Turn();               
            }

            if(currentTurnedCards.Count == 2)
            {
                if (currentTurnedCards[0].connection.frontSource == currentTurnedCards[1].frontSource)
                {
                    currentTurnedCards[0].Match(currentTurnedCards[1]);
                    Debug.Log("Same sprite");
                }
                //Check if shown cards arent a match (if they are a match, it's automatically check inside each MemoramaCard)
                else if (currentTurnedCards[0].connection != currentTurnedCards[1])
                {
                    minigame.RestLife();
                    //Voltear las dos
                    currentTurnedCards[0].Turn();
                    currentTurnedCards[1].Turn();
                    currentTurnedCards.Clear();
                }
                
#if UNITY_EDITOR
                else
                    Debug.Log("1. Connections do match!");
#endif
            }
        }
        
        public bool IsCardTurned(SCR_MemoramaCard _card)
        {
            return currentTurnedCards.Find(x => _card);
        }
        public void RemoveACard(SCR_MemoramaCard _card)
        {
            currentTurnedCards.Remove(_card);
        }
        #endregion

        #region SCORE
        public override void AddScore()
        {
            score += scorePerPair;
            UpdateScore();
        }

        public override void SetMaxPossibleScore()
        {
            if (cartas.Length > 0)
                maxPossibleScore = ((int)(cartas.Length / 2) * scorePerPair);
            else
                maxPossibleScore = 0;
        }

        #endregion

        public override void CheckIfGameWon()
        {
            base.CheckIfGameWon();
            int activeCards = 0;
            foreach(SCR_MemoramaCard card in cartas)
            {
                if (card.gameObject.activeSelf)
                    activeCards++;
            }
            if(activeCards == 0)
            {
                minigame.GameOver("Game Won!", true);
                isGameOn = false;
            }
        }

        public override void CreateProceduralLevel()
        {
            base.CreateProceduralLevel();
            isGameOn = false;
            int numberOfCards = 2;

            Debug.Log(Application.dataPath);
            //Nivel de dificultad
            switch(nivelDificultad)
            {
                case NIVEL_DIFICULTAD.PRINCIPIANTE:
                    {
                        numberOfCards = 6;
                        SetTimeLimit(false);
                    }
                    break;
                case NIVEL_DIFICULTAD.INTERMEDIO:
                    {
                        numberOfCards = 12;
                        SetTimeLimit(true, 120);
                        
                    }
                    break;
                case NIVEL_DIFICULTAD.AVANZADO:
                    {
                        numberOfCards = 16;
                        SetTimeLimit(true, 100);
                    }
                    break;
                case NIVEL_DIFICULTAD.PROFESIONAL:
                    {
                        numberOfCards = 24;
                        SetTimeLimit(true, 120);
                    }
                    break;
                default:
#if UNITY_EDITOR
                    Debug.Log("Sin nivel de dificultad");
#endif
                    break;
            }

            GameObject cartaTemp;
            string fileURL = Application.dataPath + "/Archivos/Memorama/" + categoria.ToString() + "/";
            string[] files = Directory.GetFiles(fileURL);
            List<string> parLista = new List<string>();
            foreach(string file in files)
            {
                if(!file.Contains("_gesto") && !file.Contains(".meta"))
                {
                    parLista.Add(file);
                }
            }
            cartas = new SCR_MemoramaCard[numberOfCards];
            IniciarGrid(numberOfCards);

            for(int i = 0; i < numberOfCards-1; i+=2)
            {
                //Get Random from categoria
                int randomCard = Random.Range(0, parLista.Count - 1);
                fileURL = parLista[randomCard];
                Debug.Log("File URL " + fileURL);

                cartaTemp = Instantiate(cartaPrefab);
                cartas[i] = cartaTemp.GetComponent<SCR_MemoramaCard>();
                cartas[i].Init();
                cartas[i].frontSource = fileURL;
                StartCoroutine(ImportSprite(fileURL, cartas[i]));
                AcomodarEnGrid(cartaTemp.transform);

                //connection
                fileURL = fileURL.Replace(".jpg", "_gesto.jpg");
                cartaTemp = Instantiate(cartaPrefab);
                cartas[i+1] = cartaTemp.GetComponent<SCR_MemoramaCard>();
                cartas[i + 1].frontSource = fileURL;
                StartCoroutine(ImportSprite(fileURL, cartas[i+1]));
                AcomodarEnGrid(cartas[i + 1].transform);
                cartas[i].connection = cartas[i + 1];
            }

            ShowCardsForAFewSeconds();
        }        

        IEnumerator ImportSprite(string url, SCR_MemoramaCard _card)
        {
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            WWW www = new WWW("file://"+url);
            yield return www;
            //Debug.Log("Finished" + url);
            //Debug.Log("Bytes downloaded" + www.bytesDownloaded);
            www.LoadImageIntoTexture(tex);
            _card.front = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }

        void IniciarGrid(int numberOfCards)
        {
            switch (numberOfCards)
            {
                case 6:
                    fila = 2; columna = 3;
                    Camera.main.transform.position = new Vector3(0.8f, 1.8f, -10);
                    break;
                case 12:
                    fila = 3; columna = 4;
                    Camera.main.transform.position = new Vector3(1.5f, 2.5f, -10);
                    break;
                case 16:
                    fila = 4; columna = 4;
                    Camera.main.transform.position = new Vector3(2.5f, 2.5f, -10);
                    break;
                case 24:
                    fila = 6; columna = 4;
                    Camera.main.transform.position = new Vector3(4.5f, 2.5f, -10);
                    break;
                default:
                    fila = columna = 1;
                    break;
            }

            gridCartas = new bool[fila, columna];
        }

        protected void AcomodarEnGrid(Transform _objToPlaceInGrid)
        {           
            bool foundSomething = false;
            int randFila = Random.Range(0, fila-1);
            int randCol = Random.Range(0, columna - 1);
            int maxTurns = 5;
            do
            {
                if (!gridCartas[randFila, randCol])
                {
                    _objToPlaceInGrid.position = new Vector3(1.8f * randFila, 1.5f * randCol, 0);
                    gridCartas[randFila, randCol] = true;
                    foundSomething = true;
                }
                maxTurns--;
                randFila = Random.Range(0, fila - 1);
                randCol = Random.Range(0, columna - 1);
            } while (!foundSomething && maxTurns > 0);
            
            if(!foundSomething)
            {
                for (int i = 0; i < columna; i++)
                {
                    if (!gridCartas[randFila, i])
                    {
                        _objToPlaceInGrid.position = new Vector3(1.8f * randFila, 1.5f * i, 0);
                        gridCartas[randFila, i] = true;
                        foundSomething = true;
                        break;
                    }
                }

                if (!foundSomething)
                {
                    for (int i = 0; i < fila; i++)
                    {
                        if (foundSomething)
                            break;

                        for (int j = 0; j < columna; j++)
                        {
                            if (!gridCartas[i, j])
                            {
                                _objToPlaceInGrid.position = new Vector3(1.8f * i, 1.5f * j, 0);
                                gridCartas[i, j] = true;
                                foundSomething = true;
                                break;
                            }
                        }
                    }
                }
            }
                


        }

        private void ShowCardsForAFewSeconds()
        {
            StartCoroutine(WaitToStart());
        }

        IEnumerator WaitToStart()
        {
            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i].Turn();
            }
            yield return new WaitForSeconds(2.5f);

            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i].Turn();
            }

            isGameOn = true;
            BeginCountdown();
        }

    }
}

