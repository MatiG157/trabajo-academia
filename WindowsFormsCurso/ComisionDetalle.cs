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
    public partial class ComisionDetalle : Form
    {
        private ComisionDTO comision;
        private FormMode mode;

        public ComisionDTO Comision
        {
            get { return comision; }
            set
            {
                comision = value;
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
        public ComisionDetalle()
        {
            InitializeComponent();
        }
    }
}
