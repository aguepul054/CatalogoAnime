using CatalogoAnime.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class Form2 : Form
    {
        private DataGridView dataGridView;

      
            public Form2(List<Anime> lstANime)
            {
                dataGridView = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    AutoGenerateColumns = true
                };

                dataGridView.DataSource = lstANime;

                this.Controls.Add(dataGridView);
            }
        

    }
}
