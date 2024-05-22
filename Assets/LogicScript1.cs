using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LogicScript1 : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text checkpointText;
    public GameObject gameOverScreen;
    public GameObject gameCheckpointScreen;
    public int levelOffset = 0;
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
        {12,"Egiptenii antici au contribuit semnificativ la dezvoltarea medicinei, practicând chirurgie rudimentară și utilizând plante medicinale. Cunoștințele lor în domeniul embalsamării au fost remarcabile, iar mumificarea era o parte importantă a culturii funerare egiptene." }
    };




    [ContextMenu("Increase Score")]
    public void addScore()
    {
        if (playerScore < 10)
        {
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
            if (playerScore % 3 == 0)
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
        checkpointText.text = infoDictionary[playerScore / 3 + levelOffset];
        gameCheckpointScreen.SetActive(true);
        Time.timeScale = 0;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

