using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using Metro_Desktop.Modelo;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using System.Device.Location;
using Metro_Desktop.Shortest_Path;


namespace Metro_Desktop
{
    class Deserializar
    {
        public static WebClient c = new WebClient();
        public static string json = c.DownloadString("http://equipo1.azurewebsites.net/ServiceRutas.svc/GetRutas");

        public static Ruta[] shake()
        {
            var c = new WebClient();
            JavaScriptSerializer JSC = new JavaScriptSerializer();
            Ruta[] rARutas = JSC.Deserialize<Ruta[]>(json);            
            foreach(Ruta r in rARutas)
            {
                Console.WriteLine(r.Nombre);
            }
            return rARutas;
        }

        public static Graph regresaPesos(Graph grafico)
        {
            Graph resultado = grafico;
            int contador = 0;
            int lineaactual = 1;
            GeoCoordinate distanciaAntes = new GeoCoordinate();
            GeoCoordinate distanciaActual = new GeoCoordinate();
            GeoCoordinate distanciaSiguiente = new GeoCoordinate();
            var c = new WebClient();
            JavaScriptSerializer serial = new JavaScriptSerializer();
            List<Ruta> listaRutas = serial.Deserialize<List<Ruta>>(json);
            List<PointLatLng> listaPuntos = new List<PointLatLng>();
            string nombrePunto;
            foreach (Ruta x in listaRutas)
            {
                if (x.Linea == lineaactual)
                {
                    nombrePunto = x.Nombre;
                    List<Dictionary<string, double>> prueba = new List<Dictionary<string, double>>();
                    Dictionary<string, double> pruebainterna = new Dictionary<string, double>();
                    //while (x.Nombre == nombrePunto)
                    //{
                        if (contador == 0)
                        {
                            distanciaAntes.Latitude = Convert.ToDouble(x.Latitud);
                            distanciaAntes.Longitude = Convert.ToDouble(x.Longitud);
                            distanciaActual.Latitude = Convert.ToDouble(x.Latitud);
                            distanciaActual.Longitude = Convert.ToDouble(x.Longitud);
                            //pruebainterna.Add(nombrePunto, distanciaAntes.GetDistanceTo(distanciaActual));
                            //prueba.Add(pruebainterna);
                        }
                        else if (contador == 1)
                        {
                            distanciaAntes = distanciaActual;
                            distanciaActual.Latitude = Convert.ToDouble(x.Latitud);
                            distanciaActual.Longitude = Convert.ToDouble(x.Longitud);
                            pruebainterna.Add(nombrePunto, distanciaAntes.GetDistanceTo(distanciaActual));
                            prueba.Add(pruebainterna);
                        }
                        else if (contador == 2)
                        {
                            distanciaActual.Latitude = Convert.ToDouble(x.Latitud);
                            distanciaActual.Longitude = Convert.ToDouble(x.Longitud);
                            distanciaAntes = distanciaActual;
                            pruebainterna.Add(nombrePunto, distanciaAntes.GetDistanceTo(distanciaActual));
                            prueba.Add(pruebainterna);
                        }
                        contador++;
                    //}
                    foreach (Dictionary<string, double> ejemplo in prueba)
                    {
                        grafico.add_vertex(nombrePunto, ejemplo);
                    }
                }
                lineaactual++;
            }
            return resultado;
        }

        public static Graph graficar(Graph g)
        {
            int linea = 1;
            int contador = 0;
            while (linea < 12)
            {
                List<PointLatLng> coordenadas = regresaCoordenadas(linea);
                List<String> nombres = regresaNombres(linea);
                GeoCoordinate inicia = new GeoCoordinate();
                GeoCoordinate termina = new GeoCoordinate();
                GeoCoordinate intermedio = new GeoCoordinate();
                while (contador < nombres.Count)
                {
                    if (contador == 0)
                    {
                        inicia.Latitude = coordenadas[contador].Lat;
                        inicia.Longitude = coordenadas[contador].Lng;
                        termina.Latitude = coordenadas[contador+1].Lat;
                        termina.Longitude = coordenadas[contador+1].Lng;
                        //try
                        //{
                        //    g.add_vertex(nombres[contador], new Dictionary<string, Double>() { { nombres[contador + 1], inicia.GetDistanceTo(termina) } });
                        //}
                        //catch
                        //{
                            g.add_vertex_repetido(nombres[contador], nombres[contador + 1], inicia.GetDistanceTo(termina));
                        //}
                    }
                    else if (contador == (nombres.Count - 1))
                    {
                        inicia.Latitude = coordenadas[contador].Lat;
                        inicia.Longitude = coordenadas[contador].Lng;
                        termina.Latitude = coordenadas[contador - 1].Lat;
                        termina.Longitude = coordenadas[contador - 1].Lng;
                        //try
                        //{
                        //    g.add_vertex(nombres[contador], new Dictionary<string, Double>() { { nombres[contador - 1], inicia.GetDistanceTo(termina) } });
                        //}
                        //catch
                        //{
                            g.add_vertex_repetido(nombres[contador], nombres[contador - 1], inicia.GetDistanceTo(termina));
                        //}
                    }
                    else
                    {
                        inicia.Latitude = coordenadas[contador - 1].Lat;
                        inicia.Longitude = coordenadas[contador - 1].Lng;
                        intermedio.Latitude = coordenadas[contador].Lat;
                        intermedio.Longitude = coordenadas[contador].Lng;
                        termina.Latitude = coordenadas[contador + 1].Lat;
                        termina.Longitude = coordenadas[contador + 1].Lng;
                        //try
                        //{
                        //    g.add_vertex(nombres[contador], new Dictionary<string, double>() { { nombres[contador - 1], inicia.GetDistanceTo(intermedio) }, { nombres[contador + 1], termina.GetDistanceTo(intermedio) } });
                        //}
                        //catch
                        //{
                            g.add_vertex_repetido(nombres[contador], nombres[contador - 1], inicia.GetDistanceTo(intermedio));
                            g.add_vertex_repetido(nombres[contador], nombres[contador + 1], termina.GetDistanceTo(intermedio));
                        //}
                    }
                    contador++;
                }
                linea++;
                contador = 0;
            }
            return g;
        }

        public static List<PointLatLng> regresaCoordenadas(int linea)
        {
            var c = new WebClient();
            JavaScriptSerializer serial = new JavaScriptSerializer();
            List<Ruta> listaRutas = serial.Deserialize<List<Ruta>>(json);
            List<PointLatLng> listaPuntos = new List<PointLatLng>();
            double latitud;
            double longitud;
            foreach (Ruta r in listaRutas)
            {
                if (r.Linea == linea)
                {
                    latitud = Convert.ToDouble(r.Latitud);
                    longitud = Convert.ToDouble(r.Longitud);
                    listaPuntos.Add(new PointLatLng(latitud, longitud));
                }
            }
            return listaPuntos;
        }

        public static List<String> regresaNombres()
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            List<Ruta> listaRutas = serial.Deserialize<List<Ruta>>(json);
            List<String> nombres = new List<String>();
            foreach (Ruta r in listaRutas)
            {
                //if (r.Linea == linea)
                //{
                    nombres.Add(r.Nombre);
                //}
            }

            return nombres;
        }
        
        public static List<String> regresaNombres(int linea)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            List<Ruta> listaRutas = serial.Deserialize<List<Ruta>>(json);
            List<String> nombres = new List<String>();
            foreach (Ruta r in listaRutas)
            {
                if (r.Linea == linea)
                {
                nombres.Add(r.Nombre);
                }
            }

            return nombres;
        }
    }
}
