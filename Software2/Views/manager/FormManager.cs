using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleInjector;
using Software2.Views.manager;

namespace Software2
{
    public class FormManager : IFormManager
    {
        private readonly Container container;
        private readonly Dictionary<Type, Form> OpenedForms;

        public FormManager(Container container)
        {
            this.container = container;
            this.OpenedForms = new Dictionary<Type, Form>();
        }

        public void ShowForm<TForm>() where TForm : Form
        {
            Form form;
            if (this.OpenedForms.ContainsKey(typeof(TForm)))
            {
                form = this.OpenedForms[typeof(TForm)];
            }
            else
            {
                form = this.GetForm<TForm>();
                this.OpenedForms.Add(form.GetType(), form);
                form.Closed += (s, e) => this.OpenedForms.Remove(form.GetType());
            }

            form.Show();
        }

        public void ShowForm<TForm>(int id) where TForm : Form
        {
            Form form;
            if (this.OpenedForms.ContainsKey(typeof(TForm)))
            {
                form = this.OpenedForms[typeof(TForm)];
            }
            else
            {
                form = this.GetForm<TForm>();
                this.OpenedForms.Add(form.GetType(), form);
                form.Closed += (s, e) => this.OpenedForms.Remove(form.GetType());
            }
            form.Show();
        }

        private Form GetForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }
}
