using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game
{
    internal sealed class NodeView : MonoBehaviour
    {
        [SerializeField] private Color _hoverColor;
        [SerializeField] private Color _notBuildColor;

        private Renderer _rend;
        private Color _startColor;
        private LevelView _levelView;


        // for build turret
        public Action BuildTurretOnNode;
        public TurretView TurretOnNode { get; set; }


        // for upgrade turret
        public Action<NodeView> UpradeTurretOnNode;


        private void Start()
        {
            _rend = GetComponent<Renderer>();
            _startColor = _rend.material.color;
        }

        public void Init(LevelView levelView)
        {
            _levelView = levelView;
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            UpradeTurretOnNode.Invoke(this);
            if (TurretOnNode != null)
            {
                return;
            }
            _levelView.SelecteNode(this);
            BuildTurretOnNode?.Invoke();
        }

        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            _rend.material.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            _rend.material.color = _startColor;
        }
    }
}
