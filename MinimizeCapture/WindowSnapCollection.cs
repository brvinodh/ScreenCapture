using System;
using System.Collections.Generic;

namespace MinimizeCapture
{
	internal class WindowSnapCollection : List<WindowSnap>
	{
		private const string READONLYEXCEPTIONTEXT = "The Collection is marked as Read-Only and it cannot be modified";

		private readonly bool asReadonly;

		[ThreadStatic]
		private static IntPtr checkHWnd;

		public bool ReadOnly
		{
			get
			{
				return this.asReadonly;
			}
		}

		public WindowSnapCollection(WindowSnap[] items, bool asReadOnly)
		{
			base.AddRange(items);
			base.TrimExcess();
			this.asReadonly = asReadOnly;
		}

		public WindowSnapCollection()
		{
			this.asReadonly = false;
		}

		public void Add(WindowSnap item)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Add(item);
		}

		public void AddRange(IEnumerable<WindowSnap> collection)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.AddRange(collection);
		}

		public new void Clear()
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Clear();
		}

		public bool Contains(IntPtr hWnd)
		{
			if (this.GetWindowSnap(hWnd) != null)
			{
				return true;
			}
			return false;
		}

		public WindowSnapCollection GetAllMinimized()
		{
			return (WindowSnapCollection)base.FindAll(new Predicate<WindowSnap>(WindowSnapCollection.IsMinimizedPredict));
		}

		public WindowSnap GetWindowSnap(IntPtr hWnd)
		{
			WindowSnapCollection.checkHWnd = hWnd;
			return base.Find(new Predicate<WindowSnap>(WindowSnapCollection.IshWndPredict));
		}

		public void Insert(int index, WindowSnap item)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Insert(index, item);
		}

		public void InsertRange(int index, IEnumerable<WindowSnap> collection)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.InsertRange(index, collection);
		}

		private static bool IshWndPredict(WindowSnap ws)
		{
			if (ws.Handle == WindowSnapCollection.checkHWnd)
			{
				return true;
			}
			return false;
		}

		private static bool IsMinimizedPredict(WindowSnap ws)
		{
			if (ws.IsMinimized)
			{
				return true;
			}
			return false;
		}

		public void Remove(WindowSnap item)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Remove(item);
		}

		public void RemoveAll(Predicate<WindowSnap> match)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.RemoveAll(match);
		}

		public new void RemoveAt(int index)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.RemoveAt(index);
		}

		public new void RemoveRange(int index, int count)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.RemoveRange(index, count);
		}

		public new void Reverse(int index, int count)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Reverse(index, count);
		}

		public new void Reverse()
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Reverse();
		}

		public new void Sort()
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Sort();
		}

		public void Sort(Comparison<WindowSnap> comparison)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Sort(comparison);
		}

		public void Sort(IComparer<WindowSnap> compare)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Sort(compare);
		}

		public void Sort(int index, int count, IComparer<WindowSnap> compare)
		{
			if (this.asReadonly)
			{
				this.ThrowAReadonlyException();
			}
			base.Sort(index, count, compare);
		}

		private void ThrowAReadonlyException()
		{
			throw new Exception("The Collection is marked as Read-Only and it cannot be modified");
		}

		public void Update(WindowSnap item)
		{
			lock (this)
			{
				this.Remove(this.GetWindowSnap(item.Handle));
				this.Add(item);
			}
		}
	}
}