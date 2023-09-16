using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    internal sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private Transform _startGame;
        [SerializeField] private Transform _endGame;
        [SerializeField] private NodeView[] _nodes;
        [SerializeField] private ShopView _shopView;
        [SerializeField] private WaveSpawnerView _waveSpanerView;
        [SerializeField] private PlayerStatisticsView _playerStatisticsView;
        [SerializeField] private PauseMenuView _pauseMenuView;

        private NodeView _selectaedNode;
        private TurretView _selectedTurretOnNode;

        public Transform[] WayPoints => _wayPoints; 
        public Transform StartGame => _startGame; 
        public Transform EndGame => _endGame;
        public NodeView[] NodesView => _nodes;
        public ShopView ShopView => _shopView;
        public WaveSpawnerView WaveSpawnerView => _waveSpanerView;
        public PlayerStatisticsView PlayerStatisticsView => _playerStatisticsView;
        public NodeView SelectedNode => _selectaedNode;
        public TurretView SelectedTurretOnNode => _selectedTurretOnNode;
        public PauseMenuView PauseMenuView => _pauseMenuView;


        public void SelecteNode(NodeView node)
        {
            _selectaedNode = node;
        }

        public void SelectTurretOnNode(TurretView turret)
        {
            _selectedTurretOnNode = turret;
        }

    }
}
