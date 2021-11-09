using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Structures.Graphs
{
    class Graph<T> : IGraph<T>
	{
		private Dictionary<Vector2, int> _indexes;

		private IList<IList<bool>> _adjacencyMatrix;

		public Graph()
		{
			_indexes = new Dictionary<Vector2, int>();
			_adjacencyMatrix = new List<IList<bool>>();
		}

        public int GetCount()
		{
			return _indexes.Count;
		}

        public bool Insert(Vector2 position, T data)
		{
			if (_indexes.ContainsKey(position))
			{
				return false;
			}

			_indexes.Add(position, GetCount());
			_adjacencyMatrix.Add(new List<bool>());

			for (int i = 0; i < GetCount(); i++)
			{
				if (i < GetCount() - 1)
				{
					_adjacencyMatrix[i].Add(false);
				}
				_adjacencyMatrix[GetCount() - 1].Add(false);
			}

			return true;
		}

		public bool Insert(T data)
		{
			if (data is Entity entity)
			{
				return Insert(entity.GetAnchor(), data);
			}

			return false;
		}

		public bool Remove(Vector2 position)
		{
			if (!_indexes.ContainsKey(position))
			{
				return false;
			}

			for (int i = 0; i < GetCount(); i++)
			{
				_adjacencyMatrix[i].RemoveAt(_indexes[position]);
			}

			_adjacencyMatrix.RemoveAt(_indexes[position]);
			_indexes.Remove(position);

			return true;
		}

		public bool Remove(T data)
		{
			if (data is Entity entity)
			{
				return Remove(entity.GetAnchor());
			}

			return false;
		}

		public bool AddEdge(Vector2 position1, Vector2 position2)
		{
			return ChangeEdge(position1, position2, true);
		}

		public bool AddEdge(Vector2 position1, T data)
		{
			if (data is Entity entity)
			{
				return AddEdge(position1, entity.GetAnchor());
			}

			return false;
		}

		public bool AddEdge(T data, Vector2 position2)
		{
			if (data is Entity entity)
			{
				return AddEdge(entity.GetAnchor(), position2);
			}

			return false;
		}

		public bool AddEdge(T data1, T data2)
		{
			if (data1 is Entity entity1 && data2 is Entity entity2)
			{
				return AddEdge(entity1.GetAnchor(), entity2.GetAnchor());
			}

			return false;
		}

		public bool RemoveEdge(Vector2 position1, Vector2 position2)
		{
			return ChangeEdge(position1, position2, false);
		}

		public bool RemoveEdge(Vector2 position1, T data)
		{
			if (data is Entity entity)
			{
				return RemoveEdge(position1, entity.GetAnchor());
			}

			return false;
		}

		public bool RemoveEdge(T data, Vector2 position2)
		{
			if (data is Entity entity)
			{
				return RemoveEdge(entity.GetAnchor(), position2);
			}

			return false;
		}

		public bool RemoveEdge(T data1, T data2)
		{
			if (data1 is Entity entity1 && data2 is Entity entity2)
			{
				return RemoveEdge(entity1.GetAnchor(), entity2.GetAnchor());
			}

			return false;
		}

		public bool CheckEdge(Vector2 start, Vector2 end)
		{
			return _adjacencyMatrix[_indexes[start]][_indexes[end]];
		}

		public bool CheckEdge(Vector2 start, T end)
		{
			if (end is Entity entity)
			{
				return CheckEdge(start, entity.GetAnchor());
			}

			return false;
		}

		public bool CheckEdge(T start, Vector2 end)
		{
			if (start is Entity entity)
			{
				return CheckEdge(entity.GetAnchor(), end);
			}

			return false;
		}

		public bool CheckEdge(T start, T end)
		{
			if (start is Entity entity1 && end is Entity entity2)
			{
				return CheckEdge(entity1.GetAnchor(), entity2.GetAnchor());
			}

			return false;
		}

		private bool ChangeEdge(Vector2 position1, Vector2 position2, bool state)
		{
			if (!_indexes.ContainsKey(position1) || !_indexes.ContainsKey(position2))
			{
				return false;
			}

			_adjacencyMatrix[_indexes[position1]][_indexes[position2]] = state;
			_adjacencyMatrix[_indexes[position2]][_indexes[position1]] = state;

			return true;
		}

		private string IdFromPosition(Vector2 position)
		{
			return $"{position.X}-{position.Y}";
		}
    }
}
