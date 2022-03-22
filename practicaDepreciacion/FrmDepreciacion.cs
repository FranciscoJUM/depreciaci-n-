using AppCore.Factories;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class FrmDepreci : Form
    {
        private Activo activo;
     
        public FrmDepreci(Activo Activo)
        {
            this.activo = Activo;
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(Depreciacion)).Cast<object>().ToArray());
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
            double total = 0;
            IDepreciacionModel depreciacion = FactoryDeducciones.FactoryDepreciacion((Depreciacion)comboBox1.SelectedIndex);
            List<double> depreciaciones = depreciacion.Depreciacion(activo);
            for(int i=0; i<depreciaciones.Count;i++)
            {
                richTextBox1.Text += $"Depreciacion: {i + 1}: {depreciaciones[i]}\n";
                total += depreciaciones[i];
            }
            richTextBox1.Text += $"Total: {total}\n";
            richTextBox1.Text += $"Valor residual: {activo.ValorResidual}";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            comboBox1.BackColor = Color.Black;
           comboBox1.ForeColor = Color.White;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            checkBox2.Checked = false;
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            comboBox1.BackColor = Color.White;
            comboBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            checkBox1.Checked = false;
        }
    }
}
