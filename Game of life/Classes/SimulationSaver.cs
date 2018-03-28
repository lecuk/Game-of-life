using System;
using System.Collections.Generic;
using System.IO;
using System.Messaging;
using System.Windows.Forms;

namespace Game_of_life.Classes
{
    static class SimulationSaver
    {
        public static void Save(Simulation simulation, string filePath)
        {
            SimulationOptions options = simulation.GetCurrentOptions();
            int width = simulation.width;
            int height = simulation.height;
            int pointCount;

            List<Point> pointsToSave = new List<Point>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Point p = new Point(x, y);

                    if (simulation.GetCellState(p))
                    {
                        pointsToSave.Add(p);
                    }
                } 
            }
            pointCount = pointsToSave.Count;

            FileStream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            
            writer.Write(width);
            writer.Write(height);
            writer.Write(options.connectEdges);
            for (int i = 0; i <= 8; i++)
            {
                writer.Write(options.birthConditions[i]);
            }
            for (int i = 0; i <= 8; i++)
            {
                writer.Write(options.killConditions[i]);
            }

            writer.Write(pointCount);

            foreach(Point p in pointsToSave)
            {
                writer.Write(p.x);
                writer.Write(p.y);
            }

            writer.Flush();
            writer.Close();
        }

        public static Simulation Load(string path)
        {
            int width, height;
            bool connectEdges;

            bool[] birthConditions = new bool[9];
            bool[] killConditions = new bool[9];

            List<Point> pointsToAdd = new List<Point>();

            FileStream stream;
            try
            {
                stream = new FileStream(path, FileMode.Open);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            BinaryReader reader = new BinaryReader(stream);
            width = reader.ReadInt32();
            height = reader.ReadInt32();
            connectEdges = reader.ReadBoolean();

            for(int i = 0; i <= 8; i++)
            {
                birthConditions[i] = reader.ReadBoolean();
            }
            for (int i = 0; i <= 8; i++)
            {
                killConditions[i] = reader.ReadBoolean();
            }

            int pointCount = reader.ReadInt32();

            while (pointCount > 0)
            {
                int x = reader.ReadInt32();
                int y = reader.ReadInt32();
                Point p = new Point(x, y);
                pointsToAdd.Add(p);
                pointCount--;
            }

            SimulationOptions options = new SimulationOptions(60, birthConditions, killConditions, connectEdges);
            Simulation simulation = new Simulation(width, height, options, pointsToAdd);
            
            reader.Close();

            return simulation;
        }
    }
}
