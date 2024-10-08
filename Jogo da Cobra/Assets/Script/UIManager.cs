using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public Slider speedSlider;
    public InputField gridSizeInput;
    public TextMeshProUGUI speedValueText;

    void Start()
    {
        // Inicializa valores padrões na UI
        speedSlider.onValueChanged.AddListener(delegate { UpdateSpeedValue(); });
    }

    void UpdateSpeedValue()
    {
        speedValueText.text = speedSlider.value.ToString("F2");
    }

    public void StartGame()
    {
        // Define as configurações do jogo a partir da UI
        int gridSize = int.Parse(gridSizeInput.text);
        GameManager.instance.gridSize = gridSize;
        SceneManager.LoadScene("GameScene");
    }
}
