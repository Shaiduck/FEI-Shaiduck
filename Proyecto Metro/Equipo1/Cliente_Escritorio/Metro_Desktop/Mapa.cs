using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using Metro_Desktop.Modelo;
using Metro_Desktop.Shortest_Path;

namespace Metro_Desktop
{
    public partial class Mapa : Form
    {
        Graph grafico = new Graph();
        GMapOverlay overlayOne;
        public static Ruta[] llenado = Deserializar.shake();
        GMapOverlay salidaActual;
        GMapOverlay destinoActual;

        public Mapa()
        {
            InitializeComponent();
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            String latitud;
            String longitud;
            generaGrafico(grafico);
            foreach (Ruta r in llenado)
            {
                Salida.Items.Add(r.Nombre);
                Salida.ValueMember = r.Id.ToString();
                Salida.DisplayMember = r.Nombre;
                Destino.Items.Add(r.Nombre);
                Destino.ValueMember = r.Id.ToString();
                Destino.DisplayMember = r.Nombre;
            }
        }

        private void mapExplorer_Load(object sender, EventArgs e)
        {
            DibujaMapa();
            //DibujaTodosMarcadores();
            DibujaTodasLineas();
        }

        private void DibujaMapa()
        {
            mapExplorer.Position = new PointLatLng(19.408478, -99.103074);
            mapExplorer.MapProvider = GMapProviders.GoogleTerrainMap;
            mapExplorer.MinZoom = 3;
            mapExplorer.MaxZoom = 17;
            mapExplorer.Zoom = 10;
            mapExplorer.Manager.Mode = AccessMode.ServerAndCache;
            overlayOne = new GMapOverlay(mapExplorer, "OverlayOne");
            mapExplorer.Overlays.Add(overlayOne);
        }

        private GMapOverlay DibujaMarcadorInicio(GMapOverlay actual, double latitud, double longitud, String name)
        {
            mapExplorer.Overlays.Remove(actual);
            GMapOverlay overlayMarcador = new GMapOverlay(mapExplorer, "OverlayMarcador");
            mapExplorer.Overlays.Remove(overlayMarcador);
            PointLatLng nuevo = new PointLatLng(latitud, longitud);
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen nuevoMarcador = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(nuevo);
            nuevoMarcador.ToolTipText = name;
            overlayMarcador.Markers.Add(nuevoMarcador);
            mapExplorer.Overlays.Add(overlayMarcador);
            return overlayMarcador;
        }

        private GMapOverlay DibujaMarcadorFinal(GMapOverlay actual, double latitud, double longitud, String name)
        {
            mapExplorer.Overlays.Remove(actual);
            GMapOverlay overlayMarcador = new GMapOverlay(mapExplorer, "OverlayMarcador");
            mapExplorer.Overlays.Remove(overlayMarcador);
            PointLatLng nuevo = new PointLatLng(latitud, longitud);
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed nuevoMarcador = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(nuevo);
            nuevoMarcador.ToolTipText = name;
            overlayMarcador.Markers.Add(nuevoMarcador);
            mapExplorer.Overlays.Add(overlayMarcador);
            return overlayMarcador;
        }

        private void DibujaTodosMarcadores()
        {
            GMapOverlay overlayMarcadores = new GMapOverlay(mapExplorer, "OverlayMarcadores");
            List<GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen> Lista_Marcadores = new List<GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen>();
            int numero_linea = 1;
            List<String> Lista_Nombres = Deserializar.regresaNombres();
            int indice = 0;
            while (numero_linea < 12)
            {
                foreach (PointLatLng x in Deserializar.regresaCoordenadas(numero_linea))
                {
                    //Lista_Marcadores.Add(new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(x));
                    //overlayMarcadores.Markers.Add(new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(x));
                    GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen z = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(x);
                    z.ToolTipText = Lista_Nombres[indice];
                    overlayMarcadores.Markers.Add(z);
                    indice++;
                }
                numero_linea++;
            }
            mapExplorer.Overlays.Add(overlayMarcadores);
        }

        private void DibujaTodasLineas()
        {
            List<GMapRoute> resultado = arregloLineas();
            GMapOverlay lineas = new GMapOverlay(mapExplorer, "lineas");
            foreach (GMapRoute x in resultado)
            {
                lineas.Routes.Add(x);
            }
            mapExplorer.Overlays.Add(lineas);
        }

        private void generaGrafico(Graph g)
        {
            grafico = Deserializar.graficar(grafico);
        }

        private List<GMapRoute> arregloLineas()
        {
            List<GMapRoute> rutas_lineas = new List<GMapRoute>();
            int lineas = 1;
            while (lineas < 12)
            {
                foreach (PointLatLng coordenadas in Deserializar.regresaCoordenadas(lineas))
                {
                    GMapRoute agrega = new GMapRoute(Deserializar.regresaCoordenadas(lineas), "Linea " + lineas.ToString());

                    switch (lineas)
                    {
                        case (1):
                            agrega.Stroke = new Pen(Color.Pink, 3);
                            break;
                        case (2):
                            agrega.Stroke = new Pen(Color.Blue, 3);
                            break;
                        case (3):
                            agrega.Stroke = new Pen(Color.LightSeaGreen, 3);
                            break;
                        case (4):
                            agrega.Stroke = new Pen(Color.GreenYellow, 3);
                            break;
                        case (5):
                            agrega.Stroke = new Pen(Color.Yellow, 3);
                            break;
                        case (6):
                            agrega.Stroke = new Pen(Color.Red, 3);
                            break;
                        case (7):
                            agrega.Stroke = new Pen(Color.Orange, 3);
                            break;
                        case (8):
                            agrega.Stroke = new Pen(Color.ForestGreen, 3);
                            break;
                        case (9):
                            agrega.Stroke = new Pen(Color.Black, 3);
                            break;
                        case (10):
                            agrega.Stroke = new Pen(Color.Purple, 3);
                            break;
                        case (11):
                            agrega.Stroke = new Pen(Color.Gray, 3);
                            break;
                    }
                    rutas_lineas.Add(agrega);
                }
                lineas++;
            }
            return rutas_lineas;
        }

        private void Salida_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Ruta r in llenado)
            {
                if (r.Nombre == Salida.SelectedItem)
                {
                    salida_Ubica.Text = "( " + r.Latitud + ", " + r.Longitud + ")";
                    salidaActual = DibujaMarcadorInicio(salidaActual, Convert.ToDouble(r.Latitud),Convert.ToDouble(r.Longitud), r.Nombre);
                    break;
                }
            }
        }

        private void Destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Ruta r in llenado)
            {
                if (r.Nombre == Destino.SelectedItem)
                {
                    destino_Ubica.Text = "( " + r.Latitud + ", " + r.Longitud + ")";
                    destinoActual = DibujaMarcadorFinal(destinoActual, Convert.ToDouble(r.Latitud), Convert.ToDouble(r.Longitud), r.Nombre);
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ruta_Corta.Items.Clear();
            Ruta_Txt.Text = "La ruta de " + Salida.SelectedItem.ToString() + " a " + Destino.SelectedItem.ToString() + " es: ";
            try
            {
                //grafico.shortest_path(Salida.SelectedItem.ToString(), Destino.SelectedItem.ToString()).ForEach(x => Console.WriteLine(x));
                
                grafico.shortest_path(Destino.SelectedItem.ToString(), Salida.SelectedItem.ToString()).ForEach(x => ruta_Corta.Items.Add(x));
            }
            catch
            {
            }
        }
    }
}
