using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text checkpointText;
    public GameObject gameOverScreen;
    public GameObject gameCheckpointScreen;
    public GameObject heart3, heart2, heart1;
    public int lives = 3;
    public int levelOffset = 2;
    public bool isLevel2 = false;
    Dictionary<int, string> infoDictionary = new Dictionary<int, string>()
    {
        {1,"Civilizația antică grecească, cunoscută pentru influențele sale durabile, a fost epicentrul culturii, filosofiei și artei occidentale. Orașele-stat precum Atena și Sparta au dezvoltat sisteme politice unice, cu democrația ateniană ca exemplu de guvernare participativă." },
        {2,"Filosofii greci, precum Socrate, Platon și Aristotel, au pus bazele gândirii occidentale. Prin explorarea eticii, metafizicii și logicii, acești gânditori au influențat profund educația și cultura europeană. Școlile lor de gândire continuă să fie studiate pentru perspectivele oferite." },
        {3,"Arta și arhitectura grecească sunt renumite pentru frumusețea și simetria lor. Templul Parthenon și sculpturile lui Phidias reprezintă apogeul esteticii grecești. Stilurile arhitecturale doric, ionic și corintic au influențat puternic designul clădirilor în perioada clasică și a Renașteri." },
        {4,"Mitologia greacă, plină de zei, eroi și monștri, a oferit povești bogate în învățăminte morale și culturale. Epopeele lui Homer, „Iliada” și „Odiseea”, sunt capodopere literare care explorează teme precum onoarea, curajul și destinul." },
        {5,"Sportul și competițiile erau esențiale în Grecia antică, iar Jocurile Olimpice, inițiate în 776 î.Hr., reprezintă cel mai faimos exemplu. Aceste jocuri, dedicate zeilor și desfășurate la fiecare patru ani, reuneau sportivi din diverse cetăți-state și promovau pacea și unitatea între greci." },
        {6,"Moștenirea greacă a persistat prin scrierile literare, teatrul și filosofia sa. Tragici precum Eschil, Sofocle și Euripide au explorat complexitatea condiției umane în operele lor. Aceste creații literare au fost studiate și apreciate de-a lungul secolelor." },


        {7,"Egiptenii antici au dezvoltat un sistem sofisticat de scriere, hieroglifele, și au construit monumente remarcabile precum piramidele din Giza, care continuă să fascineze omenirea." },
        {8,"Religia era centrală pentru viața egiptenilor. Ei credeau într-o lume de apoi și își îngropau morții cu bunuri pentru această călătorie. Zeii și zeițele erau venerați și considerați responsabili pentru evenimentele naturale și umane." },
        {9,"Societatea egipteană era rigid structurată, cu faraoni la vârf, urmați de nobili, preoți, funcționari și fermieri. Femeile aveau anumite drepturi, cum ar fi dreptul de a conduce afaceri și de a deține proprietăți, dar nu aveau aceeași putere socială ca bărbații." },
        {10,"Egiptul antic era un centru al învățăturii și al înțelepciunii. Școli speciale pregăteau copiii pentru diferite ocupații, iar scribii erau deosebit de respectați pentru abilitățile lor în domeniul scrierii și contabilității." },
        {11,"Egiptenii erau cunoscuți pentru realizările lor în domeniul artei și arhitecturii. Sculpturile și picturile lor sunt faimoase pentru detaliile fine și simbolismul lor puternic. Arhitectura lor monumentală, cum ar fi templele și piramidele, reprezintă încă o enigmă pentru oamenii de știință." },
        {12,"Egiptenii antici au contribuit semnificativ la dezvoltarea medicinei, practicând chirurgie rudimentară și utilizând plante medicinale. Cunoștințele lor în domeniul embalsamării au fost remarcabile, iar mumificarea era o parte importantă a culturii funerare egiptene." },

        {13,"Japonia feudală, care a durat din secolul al XII-lea până la mijlocul secolului al XIX-lea, a fost caracterizată printr-o structură socială strictă și o guvernare dominată de samurai și shoguni. Shogunii, liderii militari supremi, dețineau puterea reală, în timp ce împărații aveau un rol ceremonial." },
        {14,"Samuraii erau războinici de elită, respectați pentru codul lor de onoare, Bushido. Aceștia erau loiali stăpânilor lor feudal, daimyo, și erau cunoscuți pentru abilitățile lor în artele marțiale și pentru devotamentul lor față de cauze nobile, punând onoarea și loialitatea mai presus de viață." },
        {15,"Daimyo erau stăpâni feudali puternici care dețineau mari domenii și aveau propriile armate de samurai. Aceștia aveau o influență semnificativă în cadrul politicii și economiei regionale și se angajau frecvent în războaie pentru a-și extinde puterea și teritoriile." },
        {16,"Agricultura era baza economiei în Japonia feudală. Țăranii, sau mujicii, cultivau pământurile daimyo-ilor și plăteau taxe în produse agricole. Deși statutul lor era unul modest, rolul lor era esențial pentru supraviețuirea și prosperitatea economică a societății." },
        {17,"Cultura japoneză a înflorit în perioada feudală, cu dezvoltări semnificative în literatură, teatru și arte. Teatrul Noh și Kabuki, ceremonia ceaiului și aranjamentele florale Ikebana au devenit elemente culturale importante, reflectând valorile estetice și filosofice ale epocii." },
        {18,"Izolaționismul a fost o caracteristică cheie a Japoniei feudale, mai ales în perioada Edo (1603-1868), sub shogunatul Tokugawa. Politica Sakoku a limitat drastic contactele cu străinii, permițând Japoniei să dezvolte o cultură unică și coezivă, protejată de influențele externe până la deschiderea forțată a țării în anii 1850.\r\n\r\n\r\n\r\n\r\n\r\n" }

    };




    [ContextMenu("Increase Score")]
    public void addScore()
    {   

        if(playerScore < 10)
        {
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
            if (playerScore % 3 ==0)
            {
                gameCheckpoint();
            }
        }
        else
        {   

            nextLevel();
        }
        
    }

    public void resume()
    {
        gameCheckpointScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [ContextMenu("Checkpoint")]
    public void gameCheckpoint()
    {
        checkLevel();
        checkpointText.text = infoDictionary[playerScore / 3 + levelOffset];
        gameCheckpointScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void checkLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            levelOffset = 12;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            levelOffset = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            levelOffset = 0;
        }
        
        
    }

    public void continueCheckpoint()
    {
        gameCheckpointScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void returnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void restartGame()
    {
        GameManager.Instance.ResetLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void showLives()
    {
        int lives = GameManager.Instance.lives;

        heart1.SetActive(lives >= 1);
        heart2.SetActive(lives >= 2);
        heart3.SetActive(lives >= 3);

        if (lives == 0)
        {
            gameOver();

        }
    }
    public void changeLives()
    {
        GameManager.Instance.LoseLife();
        showLives();
        restartLevel();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadPreviousLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadSceneAsync("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadSceneAsync("Level1");
        }
    }
}

