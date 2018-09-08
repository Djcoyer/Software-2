using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2.Views.manager
{
    public interface IFormManager
    {
        void ShowForm<TForm>() where TForm : Form;
        void ShowForm<TForm>(int id) where TForm : Form;
        Form GetForm<TForm>() where TForm : Form;
    }
}
