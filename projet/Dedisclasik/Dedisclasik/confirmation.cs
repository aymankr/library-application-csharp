using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dedisclasik
{
    public partial class confirmation : Form
    {
        public confirmation(String nom)
        {
            Titre.Text = nom + 'o';
        }
    }
}
