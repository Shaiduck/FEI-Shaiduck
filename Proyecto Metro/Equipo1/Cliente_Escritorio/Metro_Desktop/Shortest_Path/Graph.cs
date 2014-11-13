﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro_Desktop.Shortest_Path
{
    public class Graph
    {
            Dictionary<string, Dictionary<string, Double>> vertices = new Dictionary<string, Dictionary<string, Double>>();

            public Graph()
            {
            }

            public void add_vertex(string name, Dictionary<string, Double> edges)
            {
                vertices[name] = edges;
            }

            public void add_vertex_repetido(string name, string name_interno, Double peso)
            {
                try
                {
                    vertices[name].Add(name_interno, peso);
                }
                catch
                {
                    Dictionary<String, Double> x = new Dictionary<String, Double>();
                    x.Add(name_interno,peso);
                    vertices[name] = x;
                }
            }

            public List<string> shortest_path(string start, string finish)
            {
                var previous = new Dictionary<string, string>();
                var distances = new Dictionary<string, int>();
                var nodes = new List<string>();
                List<string> path = null;
                foreach (var vertex in vertices)
                {
                    if (vertex.Key == start)
                    {
                        distances[vertex.Key] = 0;
                    }
                    else
                    {
                        distances[vertex.Key] = int.MaxValue;
                    }
                    nodes.Add(vertex.Key);
                }
                while (nodes.Count != 0)
                {
                    nodes.Sort((x, y) => distances[x] - distances[y]);
                    var smallest = nodes[0];
                    nodes.Remove(smallest);
                    if (smallest == finish)
                    {
                        path = new List<string>();
                        while (previous.ContainsKey(smallest))
                        {
                            path.Add(smallest);
                            smallest = previous[smallest];
                        }
                        break;
                    }
                    if (distances[smallest] == int.MaxValue)
                    {
                        break;
                    }
                    foreach (var neighbor in vertices[smallest])
                    {
                        var alt = distances[smallest] + neighbor.Value;

                        if (alt < distances[neighbor.Key])
                        {
                            distances[neighbor.Key] = Convert.ToInt16(alt);
                            previous[neighbor.Key] = smallest;
                        }
                    }
                }
                return path;
            }
        }
}