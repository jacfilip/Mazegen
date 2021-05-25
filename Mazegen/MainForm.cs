using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Mazegen
{

    public partial class MainForm : Form
    {
        Point mazeSize;

        
        public Point pxMazeSize = new Point(800, 600);
        public int pxPerCell = 10;

        int brushWidth = 1;
        Point pxMazeOffset = new Point(10, 10);
        public double complexity = 0.85;

        public Maze m;
        public List<Room> path;
        int rngSeed;
        Random rng;

        bool showPath = true;

        public MainForm()
        {
            InitializeComponent();
        }

        public void SetMaze(int x, int y, double complexity, Point start, Point end, bool solved)
        {
            this.mazeSize = new Point(x, y);
            this.complexity = complexity;

            m = CreateMaze(x, y, Math.Round(complexity, 3));
            m.SetStart(start.X, start.Y);
            m.SetEnd(end.X, end.Y);

            this.pxMazeSize.X = x * pxPerCell;
            this.pxMazeSize.Y = y * pxPerCell;

            this.main_panel.Size = new Size(pxMazeSize);

            if (path != null)
            {
                this.path.Clear();
                this.path = null;
            }
            if (solved)
                this.path = SolveMaze(m);

            this.Text = "Mazegen - Maze no. " + rngSeed + "/" + 1000 * complexity + " (" + mazeSize.X + "x" + mazeSize.Y + ")";
            this.main_panel.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_panel_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, brushWidth);

            if (m != null)
            {
                DrawMaze(this.m, e, p);
                e.Graphics.DrawRectangle(new Pen(p.Color, p.Width * 4), new Rectangle(0, 0, pxMazeSize.X, pxMazeSize.Y));
            }
        }

        private Maze CreateBlankMaze(int x, int y)
        {
            return new Maze(x, y);
        }

        private Maze CreateSealedMaze(int x, int y)
        {
            return CreateBlankMaze(x, y).Seal();
        }

        private void DrawMaze(Maze m, PaintEventArgs e, Pen p)
        {
            for(int ix = 0; ix < m.nX; ++ix)
                for(int iy = 0; iy < m.nY; ++iy)
                {
                    if (m.h[ix, iy])
                        e.Graphics.DrawLine(p, ix * pxPerCell, iy * pxPerCell, (ix + 1) * pxPerCell, iy * pxPerCell);
                    if (m.v[ix, iy])
                        e.Graphics.DrawLine(p, ix * pxPerCell, iy * pxPerCell, ix * pxPerCell, (iy + 1) * pxPerCell);
                }
            e.Graphics.FillRectangle(Brushes.ForestGreen, new Rectangle(m.startPoint.X * pxPerCell, m.startPoint.Y * pxPerCell, pxPerCell, pxPerCell));
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(m.endPoint.X * pxPerCell, m.endPoint.Y * pxPerCell, pxPerCell, pxPerCell));
            int[] x = { 2 };
            if(path != null && showPath)
            {
                PointF[] pts = new PointF[path.Count];
                for (int i = 0; i < path.Count; i++)
                    pts[i] = new PointF(path[i].pos.X * pxPerCell + pxPerCell / 2, path[i].pos.Y * pxPerCell + pxPerCell / 2);

                e.Graphics.DrawLines(new Pen(Brushes.Red), pts);
            }
        }

        private Maze CreateMaze(int x, int y, double chanceToStay = 0.0)
        {
            Maze m = CreateSealedMaze(x, y);
            List<Room> roomsToSearch = new List<Room>();

            for (int ix = 0; ix < x; ++ix)
                for (int iy = 0; iy < y; ++iy)
                {
                    if(ix == 0)
                    {
                        m.rooms[ix, iy].searchDirs.Remove(Dir.L);
                    }
                    if (ix == x - 1)
                    {
                        m.rooms[ix, iy].searchDirs.Remove(Dir.R);
                    }
                    if (iy == 0)
                    {
                        m.rooms[ix, iy].searchDirs.Remove(Dir.U);
                    }
                    if (iy == y - 1)
                    {
                        m.rooms[ix, iy].searchDirs.Remove(Dir.D);
                    }

                }

            Point start = new Point(0, 0);
            m.SetStart(start.X, start.Y);
            m.SetEnd(x - 1, y - 1);

            roomsToSearch.Add(m.rooms[start.X, start.Y]);

            rngSeed = new Random().Next(0, 1000000);
            rng = new Random(rngSeed);

            int next = 0;
            while (roomsToSearch.Count > 0)
            {
                next = rng.NextDouble() < chanceToStay ? roomsToSearch.Count - 1 : rng.Next(0, roomsToSearch.Count);

                if (roomsToSearch[next].searchDirs.Count > 0)
                {
                    int d = rng.Next(0, roomsToSearch[next].searchDirs.Count);

                    if (m.CanConnect(roomsToSearch[next], roomsToSearch[next].searchDirs[d]))
                    {
                        Room r = (Room)m.FindRoom(roomsToSearch[next], roomsToSearch[next].searchDirs[d]);
                        roomsToSearch[next].directConnections.Add(r);
                        r.directConnections.Add(roomsToSearch[next]);
                        roomsToSearch.Add(r);
                        r.searchDirs.Remove(OppositeDir(roomsToSearch[next].searchDirs[d]));
                        m.tree.Add(r);
                        roomsToSearch[next].passages[roomsToSearch[next].searchDirs[d]] = true;
                        r.passages[OppositeDir(roomsToSearch[next].searchDirs[d])] = true;
                    }
                    roomsToSearch[next].searchDirs.RemoveAt(d);
                    if (roomsToSearch[next].searchDirs.Count == 0)
                        roomsToSearch.RemoveAt(next);
                }
            }

            m.ResolveWalls();

            return m;
        }

        public List<Room> SolveMaze(Maze m)
        {
            List<Room> visited = new List<Room>();
            Dictionary<Room, Tuple<Room?, HashSet<Room>>> branches = new Dictionary<Room, Tuple<Room?, HashSet<Room>>>();
            List<Room> path = new List<Room>();

            Room nxt = m.rooms[m.startPoint.X, m.startPoint.Y];
            path.Add(nxt);
            Room? prev = null;
            branches.Add(nxt, Tuple.Create(prev, nxt.directConnections));
            visited.Add(nxt);

            while (!nxt.isExit)
            {
                if(!branches.ContainsKey(nxt))
                    branches.Add(nxt, Tuple.Create(prev, nxt.directConnections));

                if (branches[nxt].Item2.Any(r => !visited.Contains(r)))
                    foreach (Room r in branches[nxt].Item2)
                    {
                        if (!visited.Contains(r))
                        {
                            prev = nxt;
                            nxt = r;
                            path.Add(nxt);
                            visited.Add(nxt);
                            break;
                        }
                    }
                else
                {
                    path.Remove(nxt);
                    nxt = branches[nxt].Item1 ?? throw new Exception("Cannot find path. Maze no.: " + rngSeed);
                }
            }
            return path;
        }

        public Dir OppositeDir(Dir d)
        {
            switch(d)
            {
                case Dir.U:
                    return Dir.D;
                case Dir.D:
                    return Dir.U;
                case Dir.R:
                    return Dir.L;
                case Dir.L:
                    return Dir.R;
            }
            return Dir.U;
        }

        private void ExitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", "Quitting Mazegen", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                Application.Exit();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MazeOptionsForm(this)).ShowDialog();
        }

        private void GenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShowPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showPath = this.showPathToolStripMenuItem.Checked;
            if (this.showPath && this.path == null)
                SolveMaze(m);
            this.main_panel.Invalidate();
        }

        private void SolveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m != null && path == null)
                path = SolveMaze(m);
            main_panel.Invalidate();
        }

        private void ExportToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m == null)
                return;

            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.DefaultExt = "xml";
            saveFile.Filter = "XML file (*.xml)|*.xml|Text file (*.txt)|*.txt";
            saveFile.ShowDialog();

            if (saveFile.FileName == "")
                return;

            StreamWriter sw = new StreamWriter(saveFile.FileName);
            XmlWriter xw = XmlWriter.Create(sw, null);

            xw.WriteStartDocument();
            xw.WriteStartElement("maze");
            xw.WriteAttributeString("X", m.nX.ToString());
            xw.WriteAttributeString("Y", m.nY.ToString());
            xw.WriteAttributeString("Sx", m.startPoint.X.ToString());
            xw.WriteAttributeString("Sy", m.startPoint.Y.ToString());
            xw.WriteAttributeString("Ex", m.endPoint.X.ToString());
            xw.WriteAttributeString("Ey", m.endPoint.Y.ToString());
            xw.WriteAttributeString("id", this.rngSeed.ToString() + "/" + (this.complexity * 100).ToString());

            for (int ix = 0; ix < m.nX; ix++)
                for (int iy = 0; iy < m.nY; iy++)
                {
                    xw.WriteStartElement("item");
                    xw.WriteAttributeString("x", ix.ToString());
                    xw.WriteAttributeString("y", iy.ToString());
                    xw.WriteAttributeString("h", m.h[ix, iy] ? "1" : "0");
                    xw.WriteAttributeString("v", m.v[ix, iy] ? "1" : "0");
                    xw.WriteEndElement();
                }
            xw.WriteEndDocument();
            xw.Close();
            sw.Close();

            MessageBox.Show("Exported with a success!", "Export finished");
        }

        private void SolveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m != null && path == null)
                path = SolveMaze(m);
            main_panel.Invalidate();
        }
    }
}
