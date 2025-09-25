using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class MateriaDetalle : Form
    {
        private MateriaDTO materia;
        private FormMode mode;

        public MateriaDTO Materia
        {
            get { return materia; }
            set
            {
                materia = value;
                // this.SetCurso();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                //SetFormMode(value);
            }
        }
        public MateriaDetalle()
        {
            InitializeComponent();
        }


    }
}
