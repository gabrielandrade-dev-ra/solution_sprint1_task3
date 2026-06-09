using UnityEngine;

/// <summary>
/// Ponte entre a UI e o modelo 3D Mug_LowPoly.
/// Nesta etapa: apenas referências e assinaturas dos métodos públicos.
/// </summary>
public class MugModelController : MonoBehaviour
{
    [Header("Referências do Modelo")]
    [Tooltip("Transform raiz do objeto manipulável (Mug_LowPoly).")]
    [SerializeField] private Transform _modelTransform;

    [Tooltip("MeshRenderer do filho que exibe a malha da caneca (ex.: Cube).")]
    [SerializeField] private MeshRenderer _meshRenderer;

    [Header("Configuração de Escala (para uso futuro)")]
    [Tooltip("Escala mínima quando o Slider estiver em 0.")]
    [SerializeField] private float _minScale = 0.5f;

    [Tooltip("Escala máxima quando o Slider estiver em 1.")]
    [SerializeField] private float _maxScale = 2.0f;

  // ── Métodos públicos chamados pela UI ──────────────────────────

    /// <summary>Chamado pelo Slider (On Value Changed). Valor normalizado 0–1.</summary>
    public void SetScale(float normalizedValue) { }

    /// <summary>Chamado pelo Toggle (On Value Changed). Liga/desliga a visibilidade.</summary>
    public void SetVisible(bool isVisible) { }

    /// <summary>Chamado pelo Button (On Click). Restaura posição, rotação e escala iniciais.</summary>
    public void ResetTransform() { }
}