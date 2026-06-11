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
    [SerializeField] private float _maxScale = 20.0f;

    private Vector3 _initialLocalPosition;
    private Quaternion _initialLocalRotation;
    private Vector3 _initialLocalScale;

    private void Awake()
    {
        if(_modelTransform == null)
        {
            return;
        }

        _initialLocalPosition = _modelTransform.localPosition;
        _initialLocalRotation = _modelTransform.localRotation;
        _initialLocalScale = _modelTransform.localScale;
    }

  // ── Métodos públicos chamados pela UI ──────────────────────────

    /// <summary>Chamado pelo Slider (On Value Changed). Valor normalizado 0–1.</summary>
    public void SetScale(float normalizedValue)
    { 
        
        if (_modelTransform == null)
        {
            return;
        }

        float t = Mathf.Clamp01(normalizedValue);
        float scale = Mathf.Lerp(_minScale, _maxScale, t);

        _modelTransform.localScale = Vector3.one * scale;
    }

    /// <summary>Chamado pelo Toggle (On Value Changed). Liga/desliga a visibilidade.</summary>
    public void SetVisible(bool isVisible) 
    {

        if(_meshRenderer == null)
        {
            return;
        }

        _meshRenderer.enabled = isVisible;
     }

    /// <summary>Chamado pelo Button (On Click). Restaura posição, rotação e escala iniciais.</summary>
    public void ResetTransform() 
    {
        
        if (_modelTransform == null)
        {
            return;
        }

        _modelTransform.localPosition = _initialLocalPosition;
        _modelTransform.localRotation = _initialLocalRotation;
        _modelTransform.localScale = _initialLocalScale;
    }

    #if UNITY_EDITOR
        [ContextMenu("Teste: SetScale mínimo (0)")]
        private void TestScaleMin() => SetScale(0f);

        [ContextMenu("Teste: SetScale máximo (1)")]
        private void TestScaleMax() => SetScale(1f);

        [ContextMenu("Teste: SetVisible false")]
        private void TestHide() => SetVisible(false);

        [ContextMenu("Teste: SetVisible true")]
        private void TestShow() => SetVisible(true);

        [ContextMenu("Teste: ResetTransform")]
        private void TestReset() => ResetTransform();
    #endif
}