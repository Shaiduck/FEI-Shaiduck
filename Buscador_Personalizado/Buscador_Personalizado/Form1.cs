using System.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buscador_Personalizado;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace Buscador_Personalizado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var c = new WebClient();
            
            string json = c.DownloadString("https://www.googleapis.com/customsearch/v1?key=AIzaSyAVKuuo3Cshz28A9SdCy__cJKgawmCbV6E&cx=004574542526411257391:uex_alrtrvu&q="+busqueda.Text);

            Console.WriteLine(json);

            JavaScriptSerializer s1 = new JavaScriptSerializer();

            GoogleSearchResults result = s1.Deserialize<GoogleSearchResults>(json);
            Console.WriteLine(s1.Serialize(result));
            int x = 0;
            while (x < result.items.Length)
            {
                ResultadoBusqueda.Rows.Add(result.items[x].title, result.items[x].link, result.items[x].displayLink);
                x++;
            }
        }

        private void ResultadoBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sUrl = ResultadoBusqueda.Rows[e.RowIndex].Cells[1].Value.ToString();

            ProcessStartInfo sInfo = new ProcessStartInfo(sUrl);

            Process.Start(sInfo);
        }
    }
}
