using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Mazegen
{
    public struct Room
    {
        public Point pos;
        public List<Dir> searchDirs;
        public HashSet<Room> directConnections;
        public Dictionary<Dir, bool> passages;

        public bool isEntry;
        public bool isExit;

        public Room(Point pos, bool entry = false, bool exit = false)
        {
            this.pos = pos;
            
            passages = new Dictionary<Dir, bool>();
            passages.Add(Dir.D, false);
            passages.Add(Dir.U, false);
            passages.Add(Dir.L, false);
            passages.Add(Dir.R, false);

            searchDirs = new List<Dir>();
            searchDirs.Add(Dir.D);
            searchDirs.Add(Dir.U);
            searchDirs.Add(Dir.L);
            searchDirs.Add(Dir.R);

            directConnections = new HashSet<Room>();
            isEntry = entry;
            isExit = exit;
        }
    }

    public enum Dir
    {
        U,
        D,
        R,
        L
    }

    public class Maze
    {
        public int nX;
        public int nY;

        public bool[,] h;
        public bool[,] v;

        public Room[,] rooms;

        public Point startPoint;
        public Point endPoint;

        public HashSet<Room> tree = new HashSet<Room>();

        public Maze(int nX, int nY)
        {
            this.nX = nX;
            this.nY = nY;

            h = new bool[nX, nY];
            v = new bool[nX, nY];

            rooms = new Room[nX, nY];
            for (int i = 0; i < nX; ++i)
                for (int j = 0; j < nY; ++j)
                    rooms[i, j] = new Room(new Point(i, j));

            for (int i = 0; i < nX; ++i)
                for (int j = 0; j < nY; ++j)
                    h[i, j] = v[i, j] = false;

            for(int i = 0; i < nX; ++i)
                h[i, 0] = h[i, nY - 1] = true;

            for (int j = 0; j < nY; ++j)
                v[0, j] = v[nX - 1, j] = true;
        }

        public Maze Seal()
        {
            for (int i = 0; i < nX; ++i)
                for (int j = 0; j < nY; ++j)
                {
                    h[i, j] = true;
                    v[i, j] = true;
                }
            return this;
        }

        public void SetStart(int x, int y)
        {
            rooms[x, y].isEntry = true;
            this.tree.Clear();
            this.tree.Add(rooms[x, y]);
            this.startPoint = new Point(x, y);
        }

        public void SetEnd(int x, int y)
        {
            rooms[x, y].isExit = true;
            this.endPoint = new Point(x, y);
        }

        public bool CanPass(int x, int y, Dir d)
        {
            switch(d)
            {
                case Dir.U:
                    return h[x, y];
                case Dir.D:
                    return h[x, y + 1];
                case Dir.L:
                    return v[x, y];
                case Dir.R:
                    return v[x + 1, y];
                default:
                    return false;
            }
        }

        public bool CanConnect(Room start, Dir d)
        {
            Room? dest = FindRoom(start, d);

            return dest == null ? false : !IsRoomInTree((Room)dest);
        }

        public bool IsRoomInTree(Room r)
        {
            return this.tree.Contains(r);
        }

        public Room? FindRoom(Room prev, Dir dir)
        {
            Room dest = new Room();

            try
            {
                switch (dir)
                {
                    case Dir.U:
                        dest = this.rooms[prev.pos.X, prev.pos.Y - 1];
                        break;
                    case Dir.D:
                        dest = this.rooms[prev.pos.X, prev.pos.Y + 1];
                        break;
                    case Dir.L:
                        dest = this.rooms[prev.pos.X - 1, prev.pos.Y];
                        break;
                    case Dir.R:
                        dest = this.rooms[prev.pos.X + 1, prev.pos.Y];
                        break;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }

            return dest;
        }

        public void ResolveWalls()
        {
            for (int ix = 0; ix < this.nX; ++ix)
                for (int iy = 0; iy < this.nY; ++iy)
                {
                    h[ix, iy] = !rooms[ix, iy].passages[Dir.U];
                    v[ix, iy] = !rooms[ix, iy].passages[Dir.L];
                }
        }
    }
}
